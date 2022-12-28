namespace MRK
{
    public partial class Main : Form
    {
        class CourseSpan : Dictionary<TimeSpan, List<CourseRecord>>
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

        class CourseButton
        {
            private readonly Button _button;
            private bool _clashing;

            public CourseRecord Record { get; init; }
            public bool IsClashing => _clashing && Record.Selected;

            public CourseButton(Button button, CourseRecord record)
            {
                _button = button;
                Record = record;

                _button.Click += (_, _) => OnClick();
            }

            /// <summary>
            /// UI ONLY
            /// </summary>
            private void SetSelected(bool selected)
            {
                _button.FlatAppearance.BorderColor = selected ? Color.GreenYellow : Color.White;
                _button.Font = new Font(_button.Font, selected ? FontStyle.Bold : FontStyle.Regular);

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
        }

        class BoxedTuple<T1, T2>
        {
            public T1? Item1 { get; set; }
            public T2? Item2 { get; set; }
        }

        public const int GripHeight = 16;
        public const int CaptionHeight = 64;

        private const int HorizontalSpacing = 5;
        private const int VerticalSpacing = 10;

        private readonly static Color LectureColor = Color.FromArgb(255, 64, 64, 64);
        private readonly static Color TutorialColor = Color.DarkCyan;

        private readonly CourseManager _courseManager;
        private readonly HashSet<Control> _prefabs;
        private readonly List<CourseButton> _courseButtons;

        private static Main? Instance { get; set; }

        public Main()
        {
            Instance = this;

            InitializeComponent();

            bExit.Click += (_, _) => Application.Exit();
            bPref.Click += OnPrefsClick;

            _courseManager = new CourseManager();
            _prefabs = new HashSet<Control> { dayPrefab, timePrefab, coursePrefab };
            _courseButtons = new List<CourseButton>();

            _courseManager.ParseCourses(CourseResources.EmbeddedList);

            LayoutTimeTable();
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
                }

            }, _courseManager).Show();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = PointToClient(pos);

                if (pos.Y < CaptionHeight)
                {
                    m.Result = (IntPtr)2;  // HTCAPTION
                    return;
                }

                if (pos.X >= ClientSize.Width - GripHeight && pos.Y >= ClientSize.Height - GripHeight)
                {
                    m.Result = (IntPtr)17; // HTBOTTOMRIGHT
                    return;
                }
            }

            base.WndProc(ref m);
        }

        private void LayoutTimeTable()
        {
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

            var availableRecs = _courseManager.GetAvailableCourseRecords();
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

                            var button = new Button
                            {
                                BackColor = crs.CourseType == CourseType.Lecture ? LectureColor : TutorialColor,
                                ForeColor = coursePrefab.ForeColor,
                                FlatStyle = coursePrefab.FlatStyle,
                                Font = coursePrefab.Font,
                                Size = new Size(coursePrefab.Size.Width * periodsSpanned, coursePrefab.Size.Height),
                                Anchor = coursePrefab.Anchor,
                                Text = $"{crs.CourseDefinition.Name}\n{crs.CourseType.ToString()[..3].ToUpper()} G{crs.Group}",
                                Location = new Point(dx + coursePrefab.Size.Width * i, dy + cdy + coursePrefab.Location.Y),
                                AutoSize = coursePrefab.AutoSize,
                                TextAlign = coursePrefab.TextAlign,
                            };

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
            Dictionary<CourseDefinition, BoxedTuple<CourseRecord?, CourseRecord?>> list = new();

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
                str += $"{pair.Key.Name} ({lec}/{tut})";

                flag = true;
            }

            lCourseList.Text = str;
        }
    }
}