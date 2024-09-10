using System;
using System.Windows.Forms;

namespace MRK.Views
{
    public partial class SettingsView : UserControl, IView
    {
        public string ViewName => "Settings";

        private static MainWindow MainWindow => MainWindow.Instance;

        public SettingsView()
        {
            InitializeComponent();
        }

        public void OnViewShow()
        {
            var config = MainWindow.Config;
            cbHighlight.Checked = config.Highlight;
            cbCodes.Checked = config.ShowCode;
            cbOpen.Checked = config.ShowOpenOnly;
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
            return true;
        }
    }
}
