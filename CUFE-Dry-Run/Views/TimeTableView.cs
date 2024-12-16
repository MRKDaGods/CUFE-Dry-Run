using MRK.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MRK.Views
{
    public partial class TimeTableView : UserControl, IView
    {
        public enum CoursesInitializationState
        {
            None,
            Initializing,
            Initialized
        }

        private const string ImportCourseListFooterText = "Right click the footer bar to import course list";

        private const int HorizontalSpacing = 0;
        private const int VerticalSpacing = 10;

        private readonly static Color LectureColor = Color.FromArgb(52, 73, 94);
        private readonly static Color TutorialColor = Color.FromArgb(44, 120, 115);
        private static readonly Color ClosedColor = Color.FromArgb(8, 8, 8);

        private CoursesInitializationState _initializationState;
        private bool _rebuildRequested;

        private readonly Control[] _prefabs;
        private readonly List<CourseButton> _courseButtons;
        private bool _legendState;

        private Panel? _courseContainer;

        public string ViewName => "Time Table";

        public List<CourseButton> CourseButtons => _courseButtons;
        public CoursesInitializationState InitializationState => _initializationState;

        private static MainWindow MainWindow => MainWindow.Instance;
        private static CourseManager CourseManager => CourseManager.Instance;
        private static Config Config => MainWindow.Config;

        public TimeTableView()
        {
            InitializeComponent();

            _prefabs = [dayPrefab, timePrefab, coursePrefab, containerPrefab, courseContPrefab];
            _courseButtons = [];
        }

        public void OnViewShow()
        {
            InitializeCourses();

            if (_rebuildRequested)
            {
                _rebuildRequested = false;

                LayoutTimeTable();
                CheckClashes();
                CheckEmptyCoursesLabel();
            }

            UpdateCourseList();

            // enable screenshot button
            MainWindow.SetScreenshotButtonState(true, OnScreenshotClick);
            MainWindow.SetLegendVisible(_legendState);
        }

        public void OnViewHide()
        {
            // clear out status bar
            MainWindow.SetStatusBarText(string.Empty);
            MainWindow.SetFooterBarText(string.Empty);
            MainWindow.SetScreenshotButtonState(false, null);
            MainWindow.SetLegendVisible(false);
        }

        public bool CanHideView()
        {
            return _initializationState != CoursesInitializationState.Initializing;
        }

        private async void InitializeCourses()
        {
            if (_initializationState != CoursesInitializationState.None) return;

            _initializationState = CoursesInitializationState.Initializing;

            // sleep for 1000ms to let other form elements load
            await Task.Delay(1000);

            var updateData = UpdateManager.Instance.UpdateData;

            try
            {
                CourseManager.Instance.ParseCourses(updateData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing courses\n{ex}");
            }

            Invoke(() =>
            {
                if (updateData != null)
                {
                    MainWindow.TitleText = string.Join(' ', "Cryn -", updateData.Value.Semester,
                                                    updateData.Value.LastUpdated.ToString("G"));
                }

                lLoading.Visible = false;
                MainWindow.SetFooterBarText(ImportCourseListFooterText);

                LayoutTimeTable();
                CheckEmptyCoursesLabel();

                _initializationState = CoursesInitializationState.Initialized;
            });
        }

        private void CheckEmptyCoursesLabel()
        {
            var anyOpen = CourseManager.HasAvailableCourseRecords(Config.ShowOpenOnly);
            if (!anyOpen)
            {
                lLoading.Text = "Select atleast one course to continue";
            }

            lLoading.Visible = !anyOpen;
        }

        public void RequestRebuild()
        {
            _rebuildRequested = true;
        }

        private void LayoutTimeTable()
        {
            SuspendLayout();

            if (_courseContainer != null)
            {
                // remove old container
                Controls.Remove(_courseContainer);
                _courseContainer.Dispose();
            }

            var wrapEnabled = Config.WrapTimeTable;
            _courseContainer = wrapEnabled ? new FlowLayoutPanel
            {
                WrapContents = true,
                FlowDirection = FlowDirection.LeftToRight,
            } : new Panel();

            _courseContainer.AutoScroll = courseContPrefab.AutoScroll;
            _courseContainer.BackColor = courseContPrefab.BackColor;
            _courseContainer.Dock = courseContPrefab.Dock;

            // hide prefabs
            foreach (var prefab in _prefabs)
            {
                if (prefab.Visible)
                {
                    prefab.Hide();
                }
            }

            // clear old buttons
            _courseButtons.Clear();

            //calc min max, etc
            var availableRecords = CourseManager.GetAvailableCourseRecords(Config.ShowOpenOnly);
            var records = new SortedDictionary<CourseRecordDay, CourseSpan>(new CourseDayComparer());
            foreach (var record in availableRecords)
            {
                if (!records.TryGetValue(record.Day, out var value))
                {
                    value = [];
                    records[record.Day] = value;
                }

                value.AddCourseRecord(record);
            }

            //render !!!
            foreach (var pair in records)
            {
                int dx = dayPrefab.Location.X;
                int dy = dayPrefab.Location.Y;

                var container = new Panel
                {
                    BackColor = containerPrefab.BackColor,
                };

                //some courses end at others' start time
                //hour, List<rowIndex>
                Dictionary<int, HashSet<int>> timeSpanOffsets = [];
                List<SpanRange> ranges = [];

                int periodCount = pair.Value.GetPeriodCount();
                int width = periodCount * timePrefab.Size.Width;
                int absHeight = dayPrefab.Size.Height + timePrefab.Size.Height;

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

                container.Controls.Add(day);

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

                    container.Controls.Add(time);

                    // do we have courses that start at hr?
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
                                var range = ranges.Find(r => r.CrsIdx == crsIdx
                                                             && Utils.RectOverlaps(new Rectangle(r.Location, r.Size), new Rectangle(initialLoc, size)));

                                if (range == null) break;

                                cdy += coursePrefab.Size.Height;
                                crsIdx++;

                                initialLoc = new Point(dx + coursePrefab.Size.Width * i, dy + cdy + coursePrefab.Location.Y);
                            }

                            var button = new Button
                            {
                                BackColor = crs.IsOpen ? (crs.Type == CourseRecordType.Lecture ? LectureColor : TutorialColor) : ClosedColor,
                                ForeColor = coursePrefab.ForeColor,
                                FlatStyle = coursePrefab.FlatStyle,
                                Font = coursePrefab.Font,
                                Size = size,
                                Anchor = coursePrefab.Anchor,
                                Text = $"{(Config.ShowCode ? crs.Course.Code : crs.Course.Name)}\n{crs.Type.ToString()[..3].ToUpper()} " +
                                $"G{crs.Group} " +
                                $"({crs.Enrolled}/{crs.ClassSize})",
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

                            container.Controls.Add(button);

                            // set tooltip
                            var tooltipText = $"[{crs.Course.Code}]\n{button.Text}\n{crs.Location}\n\n{crs.Status.ToUpper()}";
                            tooltip.SetToolTip(button, tooltipText);

                            cdy += coursePrefab.Size.Height;

                            _courseButtons.Add(new CourseButton(this, button, crs));

                            int finishHr = crs.To.Hours;
                            if (!timeSpanOffsets.TryGetValue(finishHr, out var value))
                            {
                                value = [];
                                timeSpanOffsets[finishHr] = value;
                            }

                            value.Add(crsIdx);
                            crsIdx++;
                        }
                    }
                }

                container.AutoScroll = true;
                container.Size = container.DisplayRectangle.Size + new Size(HorizontalSpacing, VerticalSpacing);

                // add container
                _courseContainer.Controls.Add(container);
            }

            // wrapping
            if (_courseContainer.Controls.Count > 0 && !wrapEnabled)
            {
                // position panels based on days per row
                int dx = containerPrefab.Location.X;
                int dy = containerPrefab.Location.Y;
                int maxHeight = 0;

                for (int i = 0; i < _courseContainer.Controls.Count; i++)
                {
                    var panel = _courseContainer.Controls[i] as Panel;
                    if (panel == null)
                    {
                        Console.WriteLine("Courses container contains non panel control !!!");
                        continue;
                    }

                    panel.Location = new Point(dx, dy);

                    dx += panel.Width + coursePrefab.Margin.Horizontal;
                    maxHeight = Math.Max(maxHeight, panel.Height);

                    if ((i + 1) % Config.DaysPerRow == 0)
                    {
                        // break
                        dx = containerPrefab.Location.X;
                        dy += maxHeight;
                        maxHeight = 0;
                    }
                }
            }

            // add courses container to main view
            Controls.Add(_courseContainer);

            // bring loading labe to front regardless
            lLoading.BringToFront();

            // resume layout
            ResumeLayout(true);

            // update legend vis
            _legendState = availableRecords.Count > 0;
            MainWindow.SetLegendVisible(_legendState);
        }

        public void SetHoveredRecord(CourseButton sender, bool value)
        {
            if (value && !Config.Highlight)
            {
                return;
            }

            var statusBarText = sender.Button.Text.Replace("\n", " ");
            if (!Config.ShowCode)
            {
                statusBarText = string.Join(' ', $"[{sender.Record.Course.Code}]", statusBarText);

                var crsName = sender.Record.Course.Name;
                if (crsName.Length > 40)
                {
                    statusBarText = statusBarText.Replace(crsName, crsName[..37] + "...");
                }
            }

            MainWindow.SetStatusBarText(statusBarText);

            var record = sender.Record;
            _courseButtons.ForEach(button =>
            {
                button.SetHoveredStatus(value && button.Record.Course == record.Course,
                    button.Record.Group == record.Group);
            });
        }

        public void CheckClashes()
        {
            var selectedRecs = CourseManager.GetSelectedCourseRecords();
            foreach (var rec in selectedRecs)
            {
                var cb = _courseButtons.Find(x => x.Record == rec);
                if (cb == null) continue;

                var clashes = CourseManager.FindClashingCourseRecords(rec);
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

            string footerText = string.Empty;

            var selectedRecs = CourseManager.Instance.GetSelectedCourseRecords();
            if (selectedRecs.Count > 0)
            {
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

                bool flag = false;
                foreach (var pair in list)
                {
                    if (flag) footerText += "  ";

                    string lec = pair.Value.Item1?.Group.ToString() ?? "NA";
                    string tut = pair.Value.Item2?.Group.ToString() ?? "NA";

                    footerText += $"{pair.Key.Name} ({lec}{(pair.Value.Item1?.Course.HasNoTutorial ?? false ? "" : $"/{tut}")})";

                    flag = true;
                }
            }
            else if (_initializationState == CoursesInitializationState.Initialized)
            {
                footerText = ImportCourseListFooterText;
            }

            MainWindow.SetFooterBarText(footerText);
        }

        private async void OnScreenshotClick()
        {
            if (_courseContainer == null) return;

            _courseContainer.BackColor = Color.FromArgb(31, 31, 31);
            _courseContainer.Dock = DockStyle.None;
            _courseContainer.Size = _courseContainer.DisplayRectangle.Size;

            var bmp = new Bitmap(_courseContainer.Width, _courseContainer.Height);

            _courseContainer.DrawToBitmap(bmp, new Rectangle(0, 0, _courseContainer.Width, _courseContainer.Height));

            var imgName = string.Join("_",
                $"TimeTable-{UpdateManager.Instance.UpdateData?.Semester}-{DateTime.Now:g}.png"
                .Split(Path.GetInvalidFileNameChars()));

            bmp.Save(imgName, ImageFormat.Png);

            // copy to clipboard
            Clipboard.SetImage(bmp);
            bmp.Dispose();

            _courseContainer.BackColor = Color.Transparent;
            _courseContainer.Dock = DockStyle.Fill;

            MainWindow.SetFooterBarText($"Saved timetable to {imgName}");

            await Task.Delay(3000);

            if (MainWindow.CurrentView == this)
            {
                UpdateCourseList();
            }
        }
    }
}
