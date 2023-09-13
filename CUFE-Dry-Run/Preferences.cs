namespace MRK
{
    public partial class Preferences : Form
    {
        private readonly CourseManager _manager;
        private bool _dirty;

        public Preferences(Action<bool> onClose, CourseManager manager)
        {
            InitializeComponent();

            //since this is designed on 2560x1440, scale accordingly
            var bounds = Screen.FromControl(this).Bounds;
            Size = new Size((int)(Size.Width * (bounds.Width / 2560f)), (int)(Size.Height * (bounds.Height / 1440f)));

            CenterToScreen();

            _dirty = false;

            _manager = manager;

            bExit.Click += (_, _) =>
            {
                onClose?.Invoke(_dirty);
                Close();
            };

            bSearch.Click += OnSeachClick;

            bClr.Click += (_, _) => Search("");
            bCmp.Click += (_, _) => Search("CMPS");
            bMth.Click += (_, _) => Search("MTHS");
            bGen.Click += (_, _) => Search("GENS");
            bEecs.Click += (_, _) => Search("EECS");

            RenderCourseList(manager.CourseDefs);
        }

        private void OnSeachClick(object? sender, EventArgs e)
        {
            var q = tbSearch.Text.Trim().ToLower();
            var list = _manager.CourseDefs.Where(x => x.Code.ToLower().Contains(q)).ToList();
            if (list.Count == 0)
            {
                MessageBox.Show("No courses found!");
                return;
            }

            RenderCourseList(list);
        }

        private void Search(string q)
        {
            tbSearch.Text = q;
            OnSeachClick(null, EventArgs.Empty);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = PointToClient(pos);

                if (pos.Y < Main.CaptionHeight)
                {
                    m.Result = (IntPtr)2;  // HTCAPTION
                    return;
                }

                if (pos.X >= ClientSize.Width - Main.GripHeight && pos.Y >= ClientSize.Height - Main.GripHeight)
                {
                    m.Result = (IntPtr)17; // HTBOTTOMRIGHT
                    return;
                }
            }

            base.WndProc(ref m);
        }

        private void RenderCourseList(List<CourseDefinition> defs)
        {
            lTitle.Text = $"Course Preferences ({defs.Count})";

            courseCont.SuspendLayout();

            //remove if exists
            courseCont.Controls.Remove(coursePrefab);

            //dispose old list
            foreach (Control control in courseCont.Controls)
            {
                control.Dispose();
            }

            courseCont.Controls.Clear();

            int dy = coursePrefab.Location.Y;
            
            foreach (var course in defs.OrderBy(x => !x.Checked).ThenBy(x => x.Code))
            {
                var p = new Panel
                {
                    BackColor = coursePrefab.BackColor,
                    ForeColor = coursePrefab.ForeColor,
                    Size = coursePrefab.Size,
                    AutoScroll = coursePrefab.AutoScroll,
                    Anchor = coursePrefab.Anchor,
                    Location = new Point(coursePrefab.Location.X, dy)
                };

                var cb = new CheckBox
                {
                    BackColor = cbPrefab.BackColor,
                    ForeColor = cbPrefab.ForeColor,
                    Size = cbPrefab.Size,
                    Anchor = cbPrefab.Anchor,
                    Text = cbPrefab.Text,
                    Location = cbPrefab.Location,
                    AutoSize = cbPrefab.AutoSize,
                    Checked = course.Checked
                };

                cb.CheckedChanged += (_, _) => { course.Checked = cb.Checked; _dirty = true; };

                var code = new Label
                {
                    BackColor = codePrefab.BackColor,
                    ForeColor = codePrefab.ForeColor,
                    Font = codePrefab.Font,
                    Size = codePrefab.Size,
                    Anchor = codePrefab.Anchor,
                    Text = course.Code,
                    Location = codePrefab.Location,
                    AutoSize = codePrefab.AutoSize
                };

                var name = new Label
                {
                    BackColor = namePrefab.BackColor,
                    ForeColor = namePrefab.ForeColor,
                    Font = namePrefab.Font,
                    Size = namePrefab.Size,
                    Anchor = namePrefab.Anchor,
                    Text = course.Name,
                    Location = namePrefab.Location,
                    AutoSize = namePrefab.AutoSize
                };

                p.Controls.Add(cb);
                p.Controls.Add(code);
                p.Controls.Add(name);

                courseCont.Controls.Add(p);

                dy += coursePrefab.Size.Height;
            }

            courseCont.ResumeLayout(true);
        }
    }
}
