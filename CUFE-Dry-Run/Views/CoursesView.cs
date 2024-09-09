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
    public partial class CoursesView : UserControl, IView
    {
        public string ViewName => "Courses";

        public CoursesView()
        {
            InitializeComponent();
        }

        public void OnViewShow()
        {
            Console.WriteLine("View shown lol");
        }

        public void OnViewHide()
        {
            Console.WriteLine("View hidden lol");
        }
    }
}
