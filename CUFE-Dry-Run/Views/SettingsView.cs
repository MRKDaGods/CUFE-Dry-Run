﻿using MRK.Models;
using System;
using System.Windows.Forms;

namespace MRK.Views
{
    public partial class SettingsView : UserControl, IView
    {
        private enum UpdateState
        {
            CheckForUpdates,
            CheckingForUpdates,
            UpdateAvailable,
            Error,
            NoAvailableUpdates,
            Downloading
        }

        private UpdateState _updateState;
        private UpdateState _prevState;

        private UpdateState CurrentUpdateState
        {
            get => _updateState;
            set
            {
                _prevState = _updateState;
                _updateState = value;

                RefreshUpdateState();
            }
        }

        private string SelectedChannel
        {
            get => cbChannel.SelectedIndex switch
            {
                0 => "main",
                1 => "dev",
                _ => "unk"
            };
        }

        public string ViewName => "Settings";
        public UpdateData? NewUpdateData { get; set; }

        private static MainWindow MainWindow => MainWindow.Instance;

        public SettingsView()
        {
            InitializeComponent();

            bUpdateAction.Click += OnUpdateActionClick;

            cbChannel.SelectedIndex = 0;
        }

        public void OnViewShow()
        {
            var config = MainWindow.Config;
            cbHighlight.Checked = config.Highlight;
            cbCodes.Checked = config.ShowCode;
            cbOpen.Checked = config.ShowOpenOnly;

            RefreshUpdateState();
        }

        public void OnViewHide()
        {
            var config = MainWindow.Config;

            // check dirty
            if (config.ShowCode != cbCodes.Checked || config.ShowOpenOnly != cbOpen.Checked)
            {
                Console.WriteLine("SettingsView dirty, requesting timetable rebuild");
                MainWindow.GetView<TimeTableView>()!.RequestRebuild();
            }

            config.Highlight = cbHighlight.Checked;
            config.ShowCode = cbCodes.Checked;
            config.ShowOpenOnly = cbOpen.Checked;
        }

        public bool CanHideView()
        {
            return CurrentUpdateState != UpdateState.Downloading;
        }

        private void OnUpdateActionClick(object? sender, EventArgs e)
        {
            switch (CurrentUpdateState)
            {
                case UpdateState.CheckForUpdates:
                case UpdateState.Error:
                case UpdateState.NoAvailableUpdates:
                    // check for update
                    CurrentUpdateState = UpdateState.CheckingForUpdates;
                    _prevState = UpdateState.CheckForUpdates; // force

                    CheckForUpdates();
                    break;

                case UpdateState.UpdateAvailable:
                    // download
                    CurrentUpdateState = UpdateState.Downloading;
                    DownloadNewUpdate();
                    break;

                case UpdateState.Downloading:
                    break;
            }
        }

        public async void CheckForUpdates(UpdateData? updateData = null)
        {
            if (updateData == null)
            {
                updateData = await UpdateManager.Instance.CheckForUpdates(SelectedChannel);
                if (updateData == null)
                {
                    CurrentUpdateState = UpdateState.NoAvailableUpdates;
                    return;
                }
            }

            NewUpdateData = updateData;
            CurrentUpdateState = UpdateState.UpdateAvailable;
        }

        private async void DownloadNewUpdate()
        {
            if (NewUpdateData == null)
            {
                CurrentUpdateState = UpdateState.CheckForUpdates;
                return;
            }

            var res = await UpdateManager.Instance.DownloadUpdate(NewUpdateData.Value, SelectedChannel);
            if (res)
            {
                MessageBox.Show(this,
                    "Update has been installed, restarting...",
                    "Updated Installed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                CurrentUpdateState = UpdateState.Error;
            }
        }

        private void RefreshUpdateState()
        {
            bUpdateAction.Enabled = CurrentUpdateState is not (UpdateState.Downloading or UpdateState.CheckingForUpdates); // disable when downloading
            bUpdateAction.Text = CurrentUpdateState switch
            {
                UpdateState.CheckForUpdates or UpdateState.Error or UpdateState.NoAvailableUpdates => "Check for updates",
                UpdateState.UpdateAvailable => "Download update",
                UpdateState.Downloading => "Downloading",
                _ => "",
            };

            pbarUpdate.Visible = CurrentUpdateState == UpdateState.Downloading;

            lUpdateStatus.Visible = CurrentUpdateState != UpdateState.CheckForUpdates;
            lUpdateStatus.Text = CurrentUpdateState switch
            {
                UpdateState.UpdateAvailable => $"A new update ({NewUpdateData?.Semester} {NewUpdateData?.LastUpdated:G}) was found!\nDownload it?",
                UpdateState.Downloading => "Download in progress",
                UpdateState.CheckingForUpdates => "Checking for updates...",
                UpdateState.Error => $"An error has occured while {_prevState}",
                UpdateState.NoAvailableUpdates => "No updates available",
                _ => "",
            };
        }
    }
}