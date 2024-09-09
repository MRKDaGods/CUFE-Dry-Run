using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MRK.Views
{
    public partial class TimeTableView : UserControl, IView
    {
        public string ViewName => "Time Table";

        public TimeTableView()
        {
            InitializeComponent();
        }

        public void OnViewHide()
        {
        }

        public void OnViewShow()
        {
        }
    }
}
