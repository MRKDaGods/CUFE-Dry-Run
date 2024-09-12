using BrightIdeasSoftware;
using MRK.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MRK.Views
{
    public partial class CoursesView : UserControl, IView
    {
        private class CheckedListViewComparer : IComparer
        {
            private readonly bool sortDescending;

            public CheckedListViewComparer(bool sortDescending = false)
            {
                this.sortDescending = sortDescending;
            }

            public int Compare(object? x, object? y)
            {
                bool? checkedX = (x as ListViewItem)?.Checked;
                bool? checkedY = (y as ListViewItem)?.Checked;

                if (checkedX == checkedY)
                    return 0;

                if (checkedX == null)
                    return sortDescending ? 1 : -1;

                if (checkedY == null)
                    return sortDescending ? -1 : 1;

                // Compare based on checked state
                int result = checkedX.Value.CompareTo(checkedY.Value);

                // If descending order, reverse the comparison
                return sortDescending ? -result : result;
            }
        }

        private readonly Font _headerFont = new("Segoe UI Semibold", 10f);
        private readonly CheckedListViewComparer _listViewComparer = new(true);
        private bool _ignoreSortEvent;
        private bool _dirty;

        public string ViewName => "Courses";

        private static MainWindow MainWindow => MainWindow.Instance;

        public CoursesView()
        {
            InitializeComponent();
            InitializeListViewMetadata();

            bSearch.Click += OnSearchClick;
            tbSearch.KeyDown += OnSearchKeyDown;

            InitializeSearchShortcuts();
            AdjustLastColumnWidth();
        }

        public void OnViewShow()
        {
            // attach handler
            MainWindow.TransparencyChanged += AdjustForTransparency;

            // adjust back colors
            AdjustForTransparency();

            // setup courses
            if (listViewCourses.Items.Count == 0)
            {
                InitializeListView(CourseManager.Instance.Courses);
            }
            else
            {
                // sort them by checked
                SortByCheckedState();
            }

            MainWindow.SetFooterBarText("Double click on a course to toggle its checked state");
        }

        public void OnViewHide()
        {
            MainWindow.TransparencyChanged -= AdjustForTransparency;

            if (_dirty)
            {
                _dirty = false;

                Console.WriteLine("CoursesView dirty, requesting timetable rebuild");

                // notify timetable
                MainWindow.GetView<TimeTableView>()!.RequestRebuild();
            }

            MainWindow.SetFooterBarText(string.Empty);
        }

        public bool CanHideView()
        {
            return true;
        }

        private void InitializeListViewMetadata()
        {
            static OLVColumn col(string txt, int width, AspectGetterDelegate aspectGetter) => new()
            {
                Text = txt,
                Width = width,
                AspectGetter = aspectGetter
            };

            var codeColumn = col("Code", 150, (x) => ((CourseDisplay)x).Code);
            var nameColumn = col("Name", 400, (x) => ((CourseDisplay)x).Name);
            var lecsColumn = col("Lectures", 100, (x) => ((CourseDisplay)x).Lectures);
            var tutsColumn = col("Tutorials", 100, (x) => ((CourseDisplay)x).Tutorials);
            var flagsColumn = col("Flags", 100, (x) => ((CourseDisplay)x).Flags);
            listViewCourses.AllColumns.AddRange([codeColumn, nameColumn, lecsColumn, tutsColumn, flagsColumn]);
            listViewCourses.RebuildColumns();

            // headers
            UpdateListViewHeaderStyle();

            listViewCourses.Resize += OnListViewResize;
            listViewCourses.ColumnWidthChanged += OnListViewColumnResized;
            listViewCourses.ItemChecked += OnListViewChecked;
            listViewCourses.DoubleClick += OnListViewDoubleClick;

            listViewCourses.AfterSorting += OnListViewAfterSort;

            listViewCourses.Items.Clear();

            listViewCourses.UseFiltering = true;
        }

        private void OnListViewDoubleClick(object? sender, EventArgs e)
        {
            var item = listViewCourses.SelectedItem;
            if (item != null)
            {
                item.Checked = !item.Checked;
            }
        }

        private void OnListViewAfterSort(object? sender, AfterSortingEventArgs e)
        {
            if (_ignoreSortEvent || e.ColumnToSort == null) return;

            // sort by check state
            SortByCheckedState();
        }

        private void OnListViewColumnResized(object? sender, ColumnWidthChangedEventArgs e)
        {
            if (e.ColumnIndex == listViewCourses.Columns.Count - 1)
                return;

            AdjustLastColumnWidth();
        }

        private void OnListViewResize(object? sender, EventArgs e)
        {
            AdjustLastColumnWidth();
        }

        private void OnListViewChecked(object? sender, ItemCheckedEventArgs e)
        {
            if (e.Item is OLVListItem lvItem && lvItem.RowObject is CourseDisplay courseDisplay)
            {
                courseDisplay.Course.Checked = lvItem.Checked;

                _dirty = true;
            }
        }

        private void OnSearchClick(object? sender, EventArgs e)
        {
            SearchListView(tbSearch.Text.Trim());
        }

        private void OnSearchKeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                // search
                OnSearchClick(null, EventArgs.Empty);
            }
        }

        private void AdjustForTransparency()
        {
            var enabled = MainWindow.Instance.Config.TransparencyEnabled;
            UpdateListViewHeaderStyle(enabled);

            tbSearch.BackColor = enabled ? Color.Black : Color.FromArgb(24, 24, 24);

            var buttonOpaqueColor = Color.FromArgb(45, 45, 45);
            List<Button> buttons = [bSearch, .. panelShortcuts.Controls.OfType<Button>()];
            buttons.ForEach(button => button.BackColor = enabled ? Color.Black : buttonOpaqueColor);

            listViewCourses.BuildList(true);
        }

        private void AdjustLastColumnWidth()
        {
            //Total width of ListView(client area)
            int totalWidth = listViewCourses.ClientSize.Width;

            // Calculate total width of all columns except the last one
            int otherColumnsWidth = 0;
            for (int i = 0; i < listViewCourses.AllColumns.Count - 1; i++)
            {
                otherColumnsWidth += listViewCourses.AllColumns[i].Width;
            }

            // Set the last column width to fill the remaining space
            int lastColumnWidth = totalWidth - otherColumnsWidth;
            if (lastColumnWidth > 0)
            {
                listViewCourses.AllColumns[^1].Width = lastColumnWidth;
            }
        }

        private void InitializeSearchShortcuts()
        {
            foreach (var button in panelShortcuts.Controls.OfType<Button>())
            {
                var query = button.Text;
                if (query == "Clear")
                {
                    query = string.Empty;
                }

                button.Click += (o, e) =>
                {
                    tbSearch.Text = query;
                    OnSearchClick(null, EventArgs.Empty);
                };
            }
        }

        private void InitializeListView(IEnumerable<Course> courses)
        {
            List<CourseDisplay> objects = [];

            foreach (var course in courses)
            {
                var flagStr = string.Empty;
                if (course.Flags != CourseFlags.None)
                {
                    var flagsMax = (int)Enum.GetValues<CourseFlags>().Max();

                    int flag;

                    for (int i = 0; (flag = (int)Math.Pow(2, i)) <= flagsMax; i++)
                    {
                        if ((course.Flags & (CourseFlags)flag) != 0)
                        {
                            flagStr += $"[{(CourseFlags)flag}] ";
                        }
                    }
                }

                var courseDisplay = new CourseDisplay
                {
                    Course = course,
                    Flags = flagStr.Trim(),
                };
                objects.Add(courseDisplay);
            }

            listViewCourses.SetObjects(objects);
        }

        private void SortByCheckedState()
        {
            _ignoreSortEvent = true;

            var oldCol = listViewCourses.PrimarySortColumn;
            listViewCourses.PrimarySortColumn = null;

            listViewCourses.ListViewItemSorter = _listViewComparer;
            listViewCourses.Sort();

            listViewCourses.PrimarySortColumn = oldCol;

            _ignoreSortEvent = false;
        }

        private void SearchListView(string searchText)
        {
            searchText = searchText.Trim();
            listViewCourses.AdditionalFilter = new ModelFilter((x) => ((CourseDisplay)x).Code.Contains(searchText, StringComparison.OrdinalIgnoreCase));
            SortByCheckedState();
        }

        private void UpdateListViewHeaderStyle(bool transparent = false)
        {
            HeaderFormatStyle? headerStyle = listViewCourses.HeaderFormatStyle;
            if (headerStyle == null)
            {
                headerStyle = new HeaderFormatStyle();
                headerStyle.SetFont(_headerFont);
                headerStyle.SetForeColor(listViewCourses.ForeColor);
                listViewCourses.HeaderFormatStyle = headerStyle;
            }

            headerStyle.SetBackColor(transparent ? Color.Black : listViewCourses.BackColor);
        }
    }
}
