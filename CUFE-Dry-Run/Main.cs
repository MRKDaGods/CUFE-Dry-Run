using MRK.Models;
using MRK.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MRK
{
    public partial class Main : ScaledForm
    {
        private const int HorizontalSpacing = 5;
        private const int VerticalSpacing = 10;

        private readonly static Color LectureColor = Color.FromArgb(0, 0, 128);
        private readonly static Color TutorialColor = Color.FromArgb(0, 128, 128);

        private readonly CourseManager _courseManager;
        private readonly List<CourseButton> _courseButtons;
        private readonly Config _config;

        private readonly List<IView> _views;
        private IView? _currentView;

        public CourseManager CourseManager => _courseManager;
        public List<CourseButton> CourseButtons => _courseButtons;

#nullable disable
        public static Main Instance { get; set; }
#nullable enable

        public Main() : base(true)
        {
            AllocConsole();

            Instance = this;
            InitializeComponent();

            //load config
            try
            {
                using var fstream = new FileStream("config", FileMode.Open);
                using var reader = new BinaryReader(fstream);

                _config = Config.Deserialize(reader);
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
            //_prefabs = [dayPrefab, timePrefab, coursePrefab];
            _courseButtons = [];

            CenterControl(lHoveredCourse);

            // views
            _views = [];
            RegisterView<TimeTableView>(bNavTimeTable);
            RegisterView<CoursesView>(bNavCourses);

            // default view
            SwitchToView(_views[0]);
        }

        #region Form Events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //foreach (Control control in courseCont.Controls)
            //{
            //    if (_prefabs.Contains(control))
            //    {
            //        control.Hide();
            //    }
            //}

            //lLoading.Visible = true;
            //bPref.Enabled = false;

            //Task.Delay(500)
            //    .ContinueWith(_ => InitializeCourses());
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

        protected override void ScaleForm()
        {
            // scale to 80% of screen
            var bounds = Screen.FromControl(this).Bounds;
            Size = new Size((int)(0.8 * bounds.Width), (int)(0.8 * bounds.Height));
        }

        #endregion

        private void RegisterView<T>(Button navigator) where T : IView, new()
        {
            var viewInstance = new T();
            _views.Add(viewInstance);

            var control = (viewInstance as Control)!;
            control.Hide(); // hide by def

            // add to view container
            panelViewContainer.Controls.Add(control);

            // navigation event handler
            navigator.Click += (o, e) => SwitchToView(viewInstance);
        }

        private void SwitchToView(IView view)
        {
            if (_currentView != null)
            {
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

        private void OnCourseListDoubleClick(object? sender, EventArgs e)
        {
            MessageBox.Show("Copied to clipboard");
        }

        private void OnScreenshotClick(object? sender, EventArgs e)
        {
            //var oldSz = courseCont.Size;
            //courseCont.Size = courseCont.DisplayRectangle.Size;

            //var bmp = new Bitmap(courseCont.Width, courseCont.Height);

            //courseCont.DrawToBitmap(bmp, new Rectangle(0, 0, courseCont.Width, courseCont.Height));

            //var imgName = string.Join("_", $"Timetable-{DateTime.Now:G}.png".Split(Path.GetInvalidFileNameChars()));

            //bmp.Save(imgName, ImageFormat.Png);
            //bmp.Dispose();

            //courseCont.Size = oldSz;

            //MessageBox.Show($"Saved timetable to {imgName}");
        }

        private void InitializeCourses()
        {
            var updateData = UpdateManager.Instance.UpdateData;

            try
            {
                _courseManager.ParseCourses(updateData?.Resource ?? CourseResources.EmbeddedList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing courses\n{ex}");
            }

            Invoke(() =>
            {
                if (updateData != null)
                {
                    lTitle.Text = string.Join(' ', "Cryn -", updateData.Value.Semester,
                                                    updateData.Value.LastUpdated.ToString("G"));
                }

                //bPref.Enabled = true;
                //lLoading.Visible = false;

                LayoutTimeTable();

                lCourseList.Text = "Courses loaded";

                CheckEmptyCoursesLabel();
            });
        }

        private void OnOpenToggled(object? sender, EventArgs e)
        {
            LayoutTimeTable();
            CheckClashes();
        }

        private void CheckEmptyCoursesLabel()
        {
            //var any = _courseManager.HasAvailableCourseRecords(cbOpen.Checked);

            //if (!any)
            //{
            //    lLoading.Text = "Select atleast one course to continue";
            //}

            //lLoading.Visible = !any;
        }

        private void OnPrefsClick(object? sender, EventArgs e)
        {
            new Preferences((dirty) =>
            {
                if (dirty)
                {
                    LayoutTimeTable();

                    CheckClashes();
                    UpdateCourseList();

                    CheckEmptyCoursesLabel();
                }

            }, _courseManager).ShowDialog();
        }

        public void SetHoveredRecord(CourseButton sender, bool value)
        {
            if (value && !cbHighlight.Checked)
            {
                return;
            }

            var record = sender.Record;

            lHoveredCourse.Text = $"[{sender.Record.ParseFormat}] [{sender.Record.Course.Code}] " + sender.Button.Text.Replace("\n", " ");

            _courseButtons.ForEach(button =>
            {
                button.SetHoveredStatus(value && button.Record.Course == record.Course,
                    button.Record.Group == record.Group);
            });
        }

        private void LayoutTimeTable()
        {
            //courseCont.AutoScrollPosition = Point.Empty;

            //_courseButtons.Clear();

            //courseCont.SuspendLayout();

            ////dispose old list
            //var removeBuffer = new List<Control>();
            //foreach (Control control in courseCont.Controls)
            //{
            //    if (_prefabs.Contains(control))
            //    {
            //        control.Hide();
            //    }
            //    else
            //    {
            //        removeBuffer.Add(control);
            //    }
            //}

            ////remove disposed 
            //foreach (Control control in removeBuffer)
            //{
            //    courseCont.Controls.Remove(control);
            //    control.Dispose();
            //}

            //var availableRecs = _courseManager.GetAvailableCourseRecords(cbOpen.Checked);
            ////calc min max, etc

            //SortedDictionary<CourseRecordDay, CourseSpan> recs = new(new CourseDayComparer());
            //foreach (var record in availableRecs)
            //{
            //    if (!recs.TryGetValue(record.Day, out CourseSpan? value))
            //    {
            //        value = [];
            //        recs[record.Day] = value;
            //    }

            //    value.AddCourseRecord(record);
            //}

            //int dx = dayPrefab.Location.X;
            //int dy = dayPrefab.Location.Y;
            //int c = 0;
            //int maxHeight = 0;

            ////render !!!
            //foreach (var pair in recs)
            //{
            //    //some courses end at others' start time
            //    //hour, List<rowIndex>
            //    Dictionary<int, HashSet<int>> timeSpanOffsets = [];
            //    List<SpanRange> ranges = [];

            //    int periodCount = pair.Value.GetPeriodCount();
            //    int width = periodCount * timePrefab.Size.Width;
            //    int absHeight = dayPrefab.Size.Height + timePrefab.Size.Height;
            //    int maxCHeight = 0;

            //    var day = new Label
            //    {
            //        BackColor = dayPrefab.BackColor,
            //        ForeColor = dayPrefab.ForeColor,
            //        BorderStyle = dayPrefab.BorderStyle,
            //        Font = dayPrefab.Font,
            //        Size = new Size(width, dayPrefab.Size.Height),
            //        Anchor = dayPrefab.Anchor,
            //        Text = pair.Key.ToString(),
            //        Location = new Point(dx, dy),
            //        AutoSize = dayPrefab.AutoSize,
            //        TextAlign = dayPrefab.TextAlign,
            //    };

            //    courseCont.Controls.Add(day);

            //    for (int i = 0; i < periodCount; i++)
            //    {
            //        int hr = pair.Value.MinFrom!.Value.Hours + i;

            //        var time = new Label
            //        {
            //            BackColor = timePrefab.BackColor,
            //            ForeColor = timePrefab.ForeColor,
            //            BorderStyle = timePrefab.BorderStyle,
            //            Font = timePrefab.Font,
            //            Size = new Size(timePrefab.Size.Width, timePrefab.Size.Height),
            //            Anchor = timePrefab.Anchor,
            //            Text = $"{hr}:00\n{hr}:50",
            //            Location = new Point(dx + timePrefab.Size.Width * i, dy + timePrefab.Location.Y),
            //            AutoSize = timePrefab.AutoSize,
            //            TextAlign = timePrefab.TextAlign,
            //        };

            //        courseCont.Controls.Add(time);

            //        if (pair.Value.TryGetValue(new TimeSpan(hr, 0, 0), out var courses))
            //        {
            //            int cdy = 0;
            //            int crsIdx = 0; //course placement index (y-axis)
            //            foreach (var crs in courses)
            //            {
            //                //check for timespan y offset for the current hour
            //                while (timeSpanOffsets.ContainsKey(hr) && timeSpanOffsets[hr].Contains(crsIdx))
            //                {
            //                    cdy += coursePrefab.Size.Height;
            //                    crsIdx++;
            //                }

            //                //how many periods does this course span?
            //                int periodsSpanned = crs.To.Hours - crs.From.Hours + 1;

            //                var initialLoc = new Point(dx + coursePrefab.Size.Width * i, dy + cdy + coursePrefab.Location.Y);
            //                var size = new Size(coursePrefab.Size.Width * periodsSpanned, coursePrefab.Size.Height);

            //                while (true)
            //                {
            //                    //find intersecting range if applicable
            //                    var range = ranges.Find(r => r.CrsIdx == crsIdx && RectOverlaps(new Rectangle(r.Location, r.Size), new Rectangle(initialLoc, size)));

            //                    if (range == null) break;

            //                    cdy += coursePrefab.Size.Height;
            //                    crsIdx++;

            //                    initialLoc = new Point(dx + coursePrefab.Size.Width * i, dy + cdy + coursePrefab.Location.Y);
            //                }

            //                var button = new Button
            //                {
            //                    BackColor = crs.Type == CourseRecordType.Lecture ? LectureColor : TutorialColor,
            //                    ForeColor = coursePrefab.ForeColor,
            //                    FlatStyle = coursePrefab.FlatStyle,
            //                    Font = coursePrefab.Font,
            //                    Size = size,
            //                    Anchor = coursePrefab.Anchor,
            //                    Text = $"{(cbCode.Checked ? crs.Course.Code : crs.Course.Name)}\n{crs.Type.ToString()[..3].ToUpper()} " +
            //                    $"G{crs.Group} " +
            //                    $"({crs.Enrolled}/{crs.ClassSize}) " +
            //                    //(crs.CourseDefinition.IsNewSystem ? "[NEW] " : "") +
            //                    ((crs.Course.Flags & CourseFlags.MultipleLectures) != 0 ? "[M]" : ""),
            //                    Location = new Point(dx + coursePrefab.Size.Width * i, dy + cdy + coursePrefab.Location.Y),
            //                    AutoSize = coursePrefab.AutoSize,
            //                    TextAlign = coursePrefab.TextAlign,
            //                };

            //                ranges.Add(new SpanRange
            //                {
            //                    CrsIdx = crsIdx,
            //                    Location = button.Location,
            //                    Size = button.Size
            //                });

            //                button.FlatAppearance.BorderSize = coursePrefab.FlatAppearance.BorderSize;
            //                button.FlatAppearance.BorderColor = coursePrefab.FlatAppearance.BorderColor;

            //                courseCont.Controls.Add(button);

            //                tooltip.SetToolTip(button, button.Text);

            //                cdy += coursePrefab.Size.Height;

            //                _courseButtons.Add(new CourseButton(button, crs));

            //                int finishHr = crs.To.Hours;
            //                if (!timeSpanOffsets.TryGetValue(finishHr, out var value))
            //                {
            //                    value = [];
            //                    timeSpanOffsets[finishHr] = value;
            //                }

            //                value.Add(crsIdx);

            //                crsIdx++;
            //            }

            //            if (cdy > maxCHeight)
            //            {
            //                maxCHeight = cdy;
            //            }
            //        }
            //    }

            //    absHeight += maxCHeight;

            //    dx += width + HorizontalSpacing;

            //    if (absHeight > maxHeight)
            //    {
            //        maxHeight = absHeight;
            //    }

            //    c++; //max 2 days per row
            //    if (c == 2)
            //    {
            //        c = 0;
            //        dx = dayPrefab.Location.X;
            //        dy += maxHeight + VerticalSpacing;
            //        maxHeight = 0;
            //    }
            //}

            //courseCont.ResumeLayout(true);
        }

        public void CheckClashes()
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

        public void UpdateCourseList()
        {
            Dictionary<Course, BoxedTuple<CourseRecord?, CourseRecord?>> list = [];

            var selectedRecs = _courseManager.GetSelectedCourseRecords();
            foreach (var rec in selectedRecs)
            {
                if (!list.TryGetValue(rec.Course, out var value))
                {
                    value = new BoxedTuple<CourseRecord?, CourseRecord?>(null, null);
                    list[rec.Course] = value;
                }

                if (rec.Type == CourseRecordType.Lecture)
                {
                    value.Item1 = rec;
                }
                else
                {
                    value.Item2 = rec;
                }
            }

            string str = "";
            bool flag = false;
            foreach (var pair in list)
            {
                if (flag) str += " - ";

                string lec = pair.Value.Item1?.Group.ToString() ?? "NA";
                string tut = pair.Value.Item2?.Group.ToString() ?? "NA";

                str += $"{pair.Key.Name} ({lec}{(pair.Value.Item1?.Course.IsGen ?? false ? "" : $"/{tut}")})";

                flag = true;
            }

            lCourseList.Text = str;
        }

        private static bool RectOverlaps(Rectangle rectA, Rectangle rectB)
        {
            return Math.Max(rectA.Left, rectB.Left) < Math.Min(rectA.Right, rectB.Right)
                && Math.Max(rectA.Top, rectB.Top) < Math.Min(rectA.Bottom, rectB.Bottom);
        }

        private static void CenterControl(Control c)
        {
            c.Location = new Point(c.Parent!.Size.Width / 2 - c.Width / 2, c.Location.Y);
        }

        [LibraryImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static partial bool AllocConsole();
    }
}