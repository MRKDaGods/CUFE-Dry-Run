using MRK.Models;
using MRK.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MRK
{
    public partial class ImportCourseListWindow : ScaledForm
    {

        public ImportCourseListWindow() : base(false)
        {
            InitializeComponent();

            bImport.Click += OnImportClick;
            bCancel.Click += (o, e) => Close();
        }

        private void OnImportClick(object? sender, EventArgs e)
        {
            var courseManager = CourseManager.Instance;
            if (courseManager.Courses.Count == 0)
            {
                Close();
                return;
            }

            List<CourseRecord> toSelect = [];

            var matches = CourseListRegex().Matches(tbList.Text);
            foreach (Match match in matches)
            {
                var wholeMatch = match.Groups[0].Value;
                var name = match.Groups[1].Value.Trim();

                var lecGroupText = match.Groups[2].Value.Trim();
                var lecGroup = lecGroupText == "NA" ? -1 : int.Parse(lecGroupText);

                var tutGroupText = match.Groups[3].Value.Trim();
                var tutGroup = tutGroupText == "NA" || !int.TryParse(tutGroupText, out int tutVal) ? -1 : tutVal;

                var courses = courseManager.Courses.Where(
                    course => course.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)
                              && course.LectureCount >= lecGroup
                              && course.TutorialCount >= tutGroup).ToList();

                if (courses.Count == 0)
                {
                    Console.WriteLine($"Course \"{wholeMatch}\" not found");
                    continue;
                }

                Course? course = courses[0];
                if (courses.Count > 1)
                {
                    MessageBox.Show(this, "Course conflict found, check console for more details!", "Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Utils.BringConsoleToFront();

                    Console.WriteLine($"More than one course found for {wholeMatch}\nChoose the appropriate one:");

                    var prompt = string.Join('\t', courses.Select((x, idx) => $"{idx + 1} - {x.Code}"));
                    int idx;

                    do
                    {
                        Console.WriteLine(prompt);
                        Console.Write("Choice: ");

                        idx = int.TryParse(Console.ReadLine(), out var val) ? val : -1;
                    } while (idx < 1 || idx > courses.Count);

                    course = courses[idx - 1];
                    Console.WriteLine($"Chose {course.Code}");
                }

                // find the lec/tut
                var lec = courseManager.CourseRecords.Find(x => x.Course == course && x.Type == CourseRecordType.Lecture && x.Group == lecGroup);
                if (lec != null)
                {
                    toSelect.Add(lec);
                }

                var tut = courseManager.CourseRecords.Find(x => x.Course == course && x.Type == CourseRecordType.Tutorial && x.Group == tutGroup);
                if (tut != null)
                {
                    toSelect.Add(tut);
                }
            }

            // update course selection
            foreach (var course in courseManager.Courses)
            {
                course.Checked = toSelect.Find(x => x.Course == course) != null;
            }

            foreach (var record in courseManager.CourseRecords)
            {
                record.Selected = toSelect.Contains(record);
            }

            var tv = MainWindow.Instance.GetView<TimeTableView>()!;
            tv.RequestRebuild();
            tv.OnViewShow();

            // course view rebuild too
            MainWindow.Instance.GetView<CoursesView>()!.RequestRebuild();

            // close form
            Close();
        }

        [GeneratedRegex("([a-zA-Z][^\\(]+)\\((\\d+|NA)[/]?(\\d+|NA)?\\)")]
        private static partial Regex CourseListRegex();
    }
}
