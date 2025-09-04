using MRK.Models;
using MRK.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MRK
{
    public partial class MainWindow : ScaledForm
    {
        private readonly Config _config;

        private readonly Dictionary<Type, IView> _views;
        private IView? _currentView;
        private Action? _screenshotHandler;

        public Config Config => _config;

        public string TitleText
        {
            set
            {
                lTitle.Text = value;
            }
        }

        public IView? CurrentView => _currentView;

#nullable disable
        public static MainWindow Instance { get; set; }
#nullable enable

        public MainWindow()
        {
            // enable console
            Utils.InitializeConsole();

            // apply patch
            Patch.PatchButtonFocusCues();

            Instance = this;
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;

            //load config
            try
            {
                using var fstream = new FileStream("config", FileMode.Open);
                using var reader = new BinaryReader(fstream);

                _config = Config.Deserialize(reader);
            }
            catch
            {
                _config = new();
            }

            // Load update if exists
            UpdateManager.Instance.LoadUpdate(string.Empty);

            bExit.Click += (_, _) => Application.Exit();
            bScreenshot.Click += OnScreenshotClick;

            lFooterBar.MouseClick += OnFooterBarClick;
            lFooterBar.DoubleClick += OnFooterBarDoubleClick;

            //Utils.CenterControl(lFooterBar);
            Utils.CenterControl(panelLegend);

            // views
            _views = [];
            RegisterView<TimeTableView>(bNavTimeTable);
            RegisterView<CoursesView>(bNavCourses);
            RegisterView<SettingsView>(bNavSettings);

            // timetable default view
            SwitchToView(_views[typeof(TimeTableView)]);
        }

        #region Form Events

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (_currentView != null)
            {
                _currentView.OnViewHide();
            }

            using (var fstream = new FileStream("config", FileMode.Create))
            using (var writer = new BinaryWriter(fstream))
            {
                _config.Serialize(writer);
            }

            base.OnFormClosed(e);
        }

        protected override void ScaleForm()
        {
            // scale to 80% of screen
            var bounds = Screen.FromControl(this).Bounds;
            Size = new Size((int)(0.8 * bounds.Width), (int)(0.8 * bounds.Height));
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // check for updates
            Task.Run(() => UpdateManager.Instance.CheckForUpdates("main"))
                .ContinueWith(res => OnUpdateFound(res.Result));
        }

        #endregion

        private void RegisterView<T>(Button navigator) where T : IView, new()
        {
            var viewInstance = new T();
            _views[typeof(T)] = viewInstance;

            var control = (viewInstance as Control)!;
            control.Hide(); // hide by def

            // add to view container
            panelViewContainer.Controls.Add(control);
            control.Dock = DockStyle.Fill;

            // navigation event handler
            navigator.Click += (o, e) => SwitchToView(viewInstance);
        }

        private void SwitchToView(IView view)
        {
            if (_currentView == view) return;

            if (_currentView != null)
            {
                if (!_currentView.CanHideView())
                {
                    return;
                }

                _currentView.OnViewHide();
                ((Control)_currentView).Hide();
            }

            _currentView = view;

            // Update view title
            lViewTitle.Text = _currentView.ViewName;

            // show view
            ((Control)_currentView).Show();
            _currentView.OnViewShow();
        }

        public T? GetView<T>() where T : IView
        {
            return _views.TryGetValue(typeof(T), out var view) ? (T)view : default;
        }

        private void OnScreenshotClick(object? sender, EventArgs e)
        {
            _screenshotHandler?.Invoke();
        }

        private void OnFooterBarDoubleClick(object? sender, EventArgs e)
        {
            if ((ModifierKeys & Keys.Control) == Keys.Control)
            {
                var crsView = GetView<CoursesView>()!;
                NativeCourseHandler.Handle(CourseManager.Instance.GetSelectedCourseRecords(), crsView.SearchText);
            }
            else
            {
                Clipboard.SetText(lFooterBar.Text.Replace("", "-"));
            }
        }

        private void OnFooterBarClick(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right
                && _currentView is TimeTableView { InitializationState: TimeTableView.CoursesInitializationState.Initialized })
            {
                new ImportCourseListWindow().ShowDialog();
            }
        }

        private async void OnUpdateFound(UpdateData? update)
        {
            if (update == null) return;

            var res = MessageBox.Show(this,
                $"A new update ({update}) was found!\nDownload it?",
                "New Update Available",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                // go to settings

                // wait till we can hide current view
                var settings = GetView<SettingsView>()!;
                if (_currentView != settings)
                {
                    while (!(_currentView?.CanHideView() ?? true))
                    {
                        await Task.Delay(100);
                    }
                }

                Invoke(() =>
                {
                    settings.CheckForUpdates(update);
                    SwitchToView(settings);
                });
            }
        }

        public void SetStatusBarText(string text)
        {
            lStatusBar.Text = text;
        }

        public void SetFooterBarText(string text, Color? col = null, string? tooltipPrefix = null)
        {
            lFooterBar.Text = text;
            lFooterBar.ForeColor = col ?? Color.White;

            tooltip.SetToolTip(lFooterBar,
                string.Concat(!string.IsNullOrEmpty(tooltipPrefix) ? $"{tooltipPrefix}\n" : string.Empty, text.Replace(" ", "\n")));
        }

        public void SetScreenshotButtonState(bool visible, Action? handler)
        {
            bScreenshot.Visible = visible;
            _screenshotHandler = handler;
        }

        public void SetLegendVisible(bool visible)
        {
            panelLegend.Visible = visible;
        }
    }
}