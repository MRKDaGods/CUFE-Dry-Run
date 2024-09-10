using MRK.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MRK
{
    public partial class Preferences : ScaledForm
    {
        private readonly CourseManager _manager;
        private bool _dirty;

        public Preferences(Action<bool> onClose, CourseManager manager)
        {
            InitializeComponent();

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

            bUpdate.Click += OnUpdateClick;

            RenderCourseList(manager.Courses);
        }

        private void OnUpdateClick(object? sender, EventArgs e)
        {
            OpenFileDialog ofd = new()
            {
                Filter = "DryRun update file|*.dryupd"
            };

            if (ofd.ShowDialog() != DialogResult.OK) return;

            var result = UpdateManager.Instance.LoadUpdate(ofd.FileName, true);

            MessageBox.Show(result ? "Update successful, restarting..." : "Invalid update file");
        }

        private void OnSeachClick(object? sender, EventArgs e)
        {
            var q = tbSearch.Text.Trim().ToLower();
            var list = _manager.Courses.Where(x => x.Code.ToLower().Contains(q)).ToList();
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

        private void RenderCourseList(List<Course> defs)
        {
            lTitle.Text = $"Course Preferences ({defs.Count})";

            courseCont.SuspendLayout();

            courseCont.AutoScrollPosition = Point.Empty;

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
                    Width = courseCont.Width,
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

                var flagStr = "";
                var flagsMax = (int)Enum.GetValues<CourseFlags>().Max();

                int flag;

                for (int i = 0; (flag = (int)Math.Pow(2, i)) <= flagsMax; i++)
                {
                    if ((course.Flags & (CourseFlags)flag) != 0)
                    {
                        flagStr += $" [{(CourseFlags)flag}] ";
                    }
                }

                var extra = new Label
                {
                    BackColor = extraPrefab.BackColor,
                    ForeColor = extraPrefab.ForeColor,
                    Font = extraPrefab.Font,
                    Size = extraPrefab.Size,
                    Anchor = extraPrefab.Anchor,
                    Text = $"LEC ({course.LectureCount}) TUT ({course.TutorialCount}) {flagStr}",
                    Location = extraPrefab.Location,
                    AutoSize = extraPrefab.AutoSize
                };

                p.Controls.Add(cb);
                p.Controls.Add(code);
                p.Controls.Add(name);
                p.Controls.Add(extra);

                courseCont.Controls.Add(p);

                dy += coursePrefab.Size.Height;
            }

            courseCont.ResumeLayout(true);
        }
    }
}
