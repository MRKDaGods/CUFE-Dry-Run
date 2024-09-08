using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using MRK.Models;

namespace MRK
{
    public partial class Main : MRKForm
    {
        private class CourseSpan : Dictionary<TimeSpan, List<CourseRecord>>
        {
            public TimeSpan? MinFrom { get; private set; }
            public TimeSpan? MaxTo { get; private set; }

            public void AddCourseRecord(CourseRecord record)
            {
                if (!ContainsKey(record.From))
                {
                    this[record.From] = new List<CourseRecord>();
                }

                this[record.From].Add(record);

                if (!MinFrom.HasValue || record.From < MinFrom)
                {
                    MinFrom = record.From;
                }

                if (!MaxTo.HasValue || record.To > MaxTo)
                {
                    MaxTo = record.To;
                }
            }

            public int GetPeriodCount()
            {
                //8->8:50 period
                //9->9:50 period, etc
                if (!MinFrom.HasValue || !MaxTo.HasValue) return 0;

                return MaxTo.Value.Hours - MinFrom.Value.Hours + 1;
            }
        }

        private class CourseButton
        {
            private readonly Button _button;
            private bool _clashing;
            private readonly Color _backColor;
            private bool _selected;

            public CourseRecord Record { get; init; }
            public bool IsClashing => _clashing && Record.Selected;
            public Button Button => _button;
            public Color BackColor => _selected ? Color.OrangeRed : _backColor;

            public CourseButton(Button button, CourseRecord record)
            {
                _button = button;
                Record = record;

                _button.MouseEnter += (_, _) => Instance!.SetHoveredRecord(this, true);
                _button.MouseLeave += (_, _) => Instance!.SetHoveredRecord(this, false);

                _backColor = _button.BackColor;

                _button.Click += (_, _) => OnClick();
            }

            /// <summary>
            /// UI ONLY
            /// </summary>
            private void SetSelected(bool selected)
            {
                _selected = selected;

                _button.FlatAppearance.BorderColor = selected ? Color.GreenYellow : Color.White;
                _button.Font = new Font(_button.Font, selected ? FontStyle.Bold : FontStyle.Regular);

                _button.BackColor = BackColor;
                _button.ForeColor = Color.White;
            }

            private void OnClick()
            {
                Instance!._courseManager.SelectCourseRecord(Record, out var deselected);

                if (deselected != null)
                {
                    var other = Instance._courseButtons.Find(x => x.Record == deselected);
                    other?.SetSelected(false);
                }

                if (deselected != Record)
                {
                    SetSelected(true);
                }

                Instance.CheckClashes();
                Instance.UpdateCourseList();
            }

            public void SetClashing(bool clashing)
            {
                _clashing = clashing;

                if (_clashing)
                {
                    _button.FlatAppearance.BorderColor = Color.Red;
                    _button.Font = new Font(_button.Font, FontStyle.Bold | FontStyle.Strikeout);
                    _button.ForeColor = Color.Red;
                }
                else
                {
                    SetSelected(Record.Selected);
                }
            }

            public void SetHoveredStatus(bool hovered, bool sameGroup)
            {
                _button.BackColor = hovered ? Color.FromArgb(sameGroup ? 255 : 128, 123, 220, 93) : BackColor;
            }
        }

        private class BoxedTuple<T1, T2>
        {
            public T1? Item1 { get; set; }
            public T2? Item2 { get; set; }
        }

        private class SpanRange
        {
            public int CrsIdx;
            public Point Location;
            public Size Size;
        }

        private const int HorizontalSpacing = 5;
        private const int VerticalSpacing = 10;

        private readonly static Color LectureColor = Color.FromArgb(0, 0, 128);
        private readonly static Color TutorialColor = Color.FromArgb(0, 128, 128);

        private readonly CourseManager _courseManager;
        private readonly HashSet<Control> _prefabs;
        private readonly List<CourseButton> _courseButtons;
        private readonly Config _config;

        private static Main? Instance { get; set; }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public Main()
        {
            Instance = this;

            AllocConsole();

            InitializeComponent();

            //scale
            ScaleForm();

            //center
            CenterToScreen();

            //load config
            try
            {
                using (var fstream = new FileStream("config", FileMode.Open))
                using (var reader = new BinaryReader(fstream))
                {
                    _config = Config.Deserialize(reader);
                }
            }
            catch
            {
                _config = new Config
                {
                    //by default
                    Highlight = true
                };
            }

            //load update if exists
            UpdateManager.Instance.LoadUpdate(null);

            //config entries
            cbHighlight.Checked = _config.Highlight;
            cbCode.Checked = _config.ShowCode;
            cbOpen.Checked = _config.ShowOpenOnly;

            bExit.Click += (_, _) => Application.Exit();
            bPref.Click += OnPrefsClick;
            bScreenshot.Click += OnScreenshotClick;

            cbOpen.CheckedChanged += OnOpenToggled;
            cbCode.CheckedChanged += OnOpenToggled;

            lCourseList.DoubleClick += OnCourseListDoubleClick;

            _courseManager = new CourseManager();
            _prefabs = new HashSet<Control> { dayPrefab, timePrefab, coursePrefab };
            _courseButtons = new List<CourseButton>();

            CenterControl(lHoveredCourse);
            CenterControl(panelToolbar);
            CenterControl(bScreenshot);
        }

        private void OnCourseListDoubleClick(object? sender, EventArgs e)
        {
            MessageBox.Show("Copied to clipboard");
        }

        private void OnScreenshotClick(object? sender, EventArgs e)
        {
            var oldSz = courseCont.Size;
            courseCont.Size = courseCont.DisplayRectangle.Size;

            Bitmap bmp = new Bitmap(courseCont.Width, courseCont.Height);

            courseCont.DrawToBitmap(bmp, new Rectangle(0, 0, courseCont.Width, courseCont.Height));

            var imgName = string.Join("_", $"Timetable-{DateTime.Now:G}.png".Split(Path.GetInvalidFileNameChars()));

            bmp.Save(imgName, ImageFormat.Png);
            bmp.Dispose();

            courseCont.Size = oldSz;

            MessageBox.Show($"Saved timetable to {imgName}");
        }

        private static void CenterControl(Control c)
        {
            c.Location = new Point(c.Parent.Size.Width / 2 - c.Width / 2, c.Location.Y);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            foreach (Control control in courseCont.Controls)
            {
                if (_prefabs.Contains(control))
                {
                    control.Hide();
                }
            }

            lLoading.Visible = true;
            bPref.Enabled = false;

            //var updateData = UpdateManager.Instance.UpdateData;
            //_courseManager.ParseCourses(updateData?.Resource ?? CourseResources.EmbeddedList);

            Task.Delay(500).ContinueWith(_ =>
            {
                //parse in another thread
                var updateData = UpdateManager.Instance.UpdateData;
                try
                {
                    _courseManager.ParseCourses(updateData?.Resource ?? CourseResources.EmbeddedList);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"New format exception? {ex}");
                }

                Invoke(() =>
                {
                    if (updateData != null)
                    {
                        lLastUpdated.Text = "FALL 2024 " + updateData.Value.LastUpdated.ToString("G");
                    }

                    bPref.Enabled = true;
                    lLoading.Visible = false;

                    LayoutTimeTable();

                    lCourseList.Text = "Courses loaded";

                    CheckEmptyCoursesLabel();
                });
            });
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            using (var fstream = new FileStream("config", FileMode.Create))
            using (var writer = new BinaryWriter(fstream))
            {
                _config.Highlight = cbHighlight.Checked;
                _config.ShowCode = cbCode.Checked;
                _config.ShowOpenOnly = cbOpen.Checked;

                _config.Serialize(writer);
            }

            base.OnFormClosed(e);
        }

        private void OnOpenToggled(object? sender, EventArgs e)
        {
            LayoutTimeTable();
            CheckClashes();
        }

        private void CheckEmptyCoursesLabel()
        {
            var any = _courseManager.HasAvailableCourseRecords(cbOpen.Checked);

            if (!any)
            {
                lLoading.Text = "Select atleast one course to continue";
            }

            lLoading.Visible = !any;
        }

        private void OnPrefsClick(object? sender, EventArgs e)
        {
            Enabled = false;
            new Preferences((dirty) =>
            {
                Enabled = true;

                if (dirty)
                {
                    LayoutTimeTable();

                    CheckClashes();
                    UpdateCourseList();

                    CheckEmptyCoursesLabel();
                }

            }, _courseManager).Show();
        }

        private void SetHoveredRecord(CourseButton sender, bool value)
        {
            if (value && !cbHighlight.Checked)
            {
                return;
            }

            var record = sender.Record;

            lHoveredCourse.Text = $"[{sender.Record.ParseFormat}] [{sender.Record.CourseDefinition.Code}] " + sender.Button.Text.Replace("\n", " ");

            _courseButtons.ForEach(button =>
            {
                button.SetHoveredStatus(value && button.Record.CourseDefinition == record.CourseDefinition,
                    button.Record.Group == record.Group);
            });
        }

        private static bool RectOverlaps(Rectangle rectA, Rectangle rectB)
        {
            return Math.Max(rectA.Left, rectB.Left) < Math.Min(rectA.Right, rectB.Right)
                && Math.Max(rectA.Top, rectB.Top) < Math.Min(rectA.Bottom, rectB.Bottom);
        }

        private void LayoutTimeTable()
        {
            courseCont.AutoScrollPosition = Point.Empty;

            _courseButtons.Clear();

            courseCont.SuspendLayout();

            //dispose old list
            var removeBuffer = new List<Control>();
            foreach (Control control in courseCont.Controls)
            {
                if (_prefabs.Contains(control))
                {
                    control.Hide();
                }
                else
                {
                    removeBuffer.Add(control);
                }
            }

            //remove disposed 
            foreach (Control control in removeBuffer)
            {
                courseCont.Controls.Remove(control);
                control.Dispose();
            }

            var availableRecs = _courseManager.GetAvailableCourseRecords(cbOpen.Checked);
            //calc min max, etc

            SortedDictionary<CourseDay, CourseSpan> recs = new(new CourseDayComparer());
            foreach (var record in availableRecs)
            {
                if (!recs.ContainsKey(record.Day))
                {
                    recs[record.Day] = new CourseSpan();
                }

                recs[record.Day].AddCourseRecord(record);
            }

            int dx = dayPrefab.Location.X;
            int dy = dayPrefab.Location.Y;
            int c = 0;
            int maxHeight = 0;

            //render !!!
            foreach (var pair in recs)
            {
                //some courses end at others' start time
                //hour, List<rowIndex>
                Dictionary<int, HashSet<int>> timeSpanOffsets = new();
                List<SpanRange> ranges = new();

                int periodCount = pair.Value.GetPeriodCount();
                int width = periodCount * timePrefab.Size.Width;
                int absHeight = dayPrefab.Size.Height + timePrefab.Size.Height;
                int maxCHeight = 0;

                var day = new Label
                {
                    BackColor = dayPrefab.BackColor,
                    ForeColor = dayPrefab.ForeColor,
                    BorderStyle = dayPrefab.BorderStyle,
                    Font = dayPrefab.Font,
                    Size = new Size(width, dayPrefab.Size.Height),
                    Anchor = dayPrefab.Anchor,
                    Text = pair.Key.ToString(),
                    Location = new Point(dx, dy),
                    AutoSize = dayPrefab.AutoSize,
                    TextAlign = dayPrefab.TextAlign,
                };

                courseCont.Controls.Add(day);

                for (int i = 0; i < periodCount; i++)
                {
                    int hr = pair.Value.MinFrom!.Value.Hours + i;

                    var time = new Label
                    {
                        BackColor = timePrefab.BackColor,
                        ForeColor = timePrefab.ForeColor,
                        BorderStyle = timePrefab.BorderStyle,
                        Font = timePrefab.Font,
                        Size = new Size(timePrefab.Size.Width, timePrefab.Size.Height),
                        Anchor = timePrefab.Anchor,
                        Text = $"{hr}:00\n{hr}:50",
                        Location = new Point(dx + timePrefab.Size.Width * i, dy + timePrefab.Location.Y),
                        AutoSize = timePrefab.AutoSize,
                        TextAlign = timePrefab.TextAlign,
                    };

                    courseCont.Controls.Add(time);

                    if (pair.Value.TryGetValue(new TimeSpan(hr, 0, 0), out var courses))
                    {
                        int cdy = 0;
                        int crsIdx = 0; //course placement index (y-axis)
                        foreach (var crs in courses)
                        {
                            //check for timespan y offset for the current hour
                            while (timeSpanOffsets.ContainsKey(hr) && timeSpanOffsets[hr].Contains(crsIdx))
                            {
                                cdy += coursePrefab.Size.Height;
                                crsIdx++;
                            }

                            //how many periods does this course span?
                            int periodsSpanned = crs.To.Hours - crs.From.Hours + 1;

                            var initialLoc = new Point(dx + coursePrefab.Size.Width * i, dy + cdy + coursePrefab.Location.Y);
                            var size = new Size(coursePrefab.Size.Width * periodsSpanned, coursePrefab.Size.Height);

                            while (true)
                            {
                                //find intersecting range if applicable
                                var range = ranges.Find(r => r.CrsIdx == crsIdx && RectOverlaps(new Rectangle(r.Location, r.Size), new Rectangle(initialLoc, size)));

                                if (range == null) break;

                                cdy += coursePrefab.Size.Height;
                                crsIdx++;

                                initialLoc = new Point(dx + coursePrefab.Size.Width * i, dy + cdy + coursePrefab.Location.Y);
                            }

                            var button = new Button
                            {
                                BackColor = crs.CourseType == CourseType.Lecture ? LectureColor : TutorialColor,
                                ForeColor = coursePrefab.ForeColor,
                                FlatStyle = coursePrefab.FlatStyle,
                                Font = coursePrefab.Font,
                                Size = size,
                                Anchor = coursePrefab.Anchor,
                                Text = $"{(cbCode.Checked ? crs.CourseDefinition.Code : crs.CourseDefinition.Name)}\n{crs.CourseType.ToString()[..3].ToUpper()} " +
                                $"G{crs.Group} " +
                                $"({crs.Enrolled}/{crs.ClassSize}) " +
                                //(crs.CourseDefinition.IsNewSystem ? "[NEW] " : "") +
                                ((crs.CourseDefinition.Flags & CourseFlags.MultipleLectures) != 0 ? "[M]" : ""),
                                Location = new Point(dx + coursePrefab.Size.Width * i, dy + cdy + coursePrefab.Location.Y),
                                AutoSize = coursePrefab.AutoSize,
                                TextAlign = coursePrefab.TextAlign,
                            };

                            ranges.Add(new SpanRange
                            {
                                CrsIdx = crsIdx,
                                Location = button.Location,
                                Size = button.Size
                            });

                            button.FlatAppearance.BorderSize = coursePrefab.FlatAppearance.BorderSize;
                            button.FlatAppearance.BorderColor = coursePrefab.FlatAppearance.BorderColor;

                            courseCont.Controls.Add(button);

                            tooltip.SetToolTip(button, button.Text);

                            cdy += coursePrefab.Size.Height;

                            _courseButtons.Add(new CourseButton(button, crs));

                            int finishHr = crs.To.Hours;
                            if (!timeSpanOffsets.ContainsKey(finishHr))
                            {
                                timeSpanOffsets[finishHr] = new HashSet<int>();
                            }

                            timeSpanOffsets[finishHr].Add(crsIdx);

                            crsIdx++;
                        }

                        if (cdy > maxCHeight)
                        {
                            maxCHeight = cdy;
                        }
                    }
                }

                absHeight += maxCHeight;

                dx += width + HorizontalSpacing;

                if (absHeight > maxHeight)
                {
                    maxHeight = absHeight;
                }

                c++; //max 2 days per row
                if (c == 2)
                {
                    c = 0;
                    dx = dayPrefab.Location.X;
                    dy += maxHeight + VerticalSpacing;
                    maxHeight = 0;
                }
            }

            courseCont.ResumeLayout(true);
        }

        private void CheckClashes()
        {
            var selectedRecs = _courseManager.GetSelectedCourseRecords();
            foreach (var rec in selectedRecs)
            {
                var cb = _courseButtons.Find(x => x.Record == rec);
                if (cb == null) continue;

                var clashes = _courseManager.FindClashingCourseRecords(rec);
                cb.SetClashing(clashes.Count > 0);

                if (clashes.Count > 0)
                {
                    clashes.ForEach(x => _courseButtons.Find(y => y.Record == x)?.SetClashing(true));
                }
            }
        }

        private void UpdateCourseList()
        {
            Dictionary<Course, BoxedTuple<CourseRecord?, CourseRecord?>> list = new();

            var selectedRecs = _courseManager.GetSelectedCourseRecords();
            foreach (var rec in selectedRecs)
            {
                if (!list.ContainsKey(rec.CourseDefinition))
                {
                    list[rec.CourseDefinition] = new BoxedTuple<CourseRecord?, CourseRecord?> { Item1 = null, Item2 = null };
                }

                if (rec.CourseType == CourseType.Lecture)
                {
                    list[rec.CourseDefinition].Item1 = rec;
                }
                else
                {
                    list[rec.CourseDefinition].Item2 = rec;
                }
            }

            string str = "";
            bool flag = false;
            foreach (var pair in list)
            {
                if (flag) str += " - ";

                string lec = pair.Value.Item1?.Group.ToString() ?? "NA";
                string tut = pair.Value.Item2?.Group.ToString() ?? "NA";

                str += $"{pair.Key.Name} ({lec}{(pair.Value.Item1?.CourseDefinition.IsGen ?? false ? "" : $"/{tut}")})";

                flag = true;
            }

            lCourseList.Text = str;
        }
    }
}