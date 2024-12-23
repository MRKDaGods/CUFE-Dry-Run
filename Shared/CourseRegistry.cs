using MRK.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MRK
{
    public class CourseRegistry
    {
        private static readonly Dictionary<Type, ICourseParser> _parsers;

        public static List<Course> Courses { get; private set; }

        static CourseRegistry()
        {
            _parsers = [];
            Courses = [];
        }

        public static TParser GetOrCreateParser<TParser>() where TParser : class, ICourseParser
        {
            ICourseParser? parser;
            if (!_parsers.TryGetValue(typeof(TParser), out parser))
            {
                parser = Activator.CreateInstance(typeof(TParser)) as TParser;
            }

            if (parser == null)
            {
                throw new InvalidOperationException("Failed to create parser");
            }

            return (TParser)parser;
        }

        public static void RegisterParser(ICourseParser parser)
        {
            _parsers[parser.GetType()] = parser;
        }

        public static Course GetOrCreateCourse(string code, string? name = null)
        {
            var course = Courses.Find(x => x.Code == code);
            if (course == null)
            {
                ArgumentNullException.ThrowIfNull(name);

                course = new Course(code, name);
                Courses.Add(course);
            }

            return course;
        }

        /// <summary>
        /// Sorts the courses by their code
        /// </summary>
        public static void Sort()
        {
            Courses.Sort((x, y) => x.Code.CompareTo(y.Code));
        }

        public static void ResetCourses(bool clear)
        {
            if (clear)
            {
                Courses.Clear();
                return;
            }

            foreach (var course in Courses)
            {
                course.LectureCount = course.TutorialCount = 0;
                course.Flags = CourseFlags.None;
            }
        }

        public static void UpdateCourseFlags(ICourseParser parser)
        {
            foreach (var def in Courses)
            {
                // clear flags
                def.Flags = CourseFlags.None;

                var lectureGroupMap = new Dictionary<int, int>();

                foreach (var lecture in parser.CourseRecords.Where(x => x.Course.Code == def.Code
                                                                 && x.Type == CourseRecordType.Lecture))
                {
                    if (!lectureGroupMap.ContainsKey(lecture.Group))
                    {
                        lectureGroupMap[lecture.Group] = 0;
                    }

                    lecture.MultipleLectureIndex = lectureGroupMap[lecture.Group]++;
                }

                if (lectureGroupMap.Any(x => x.Value >= 2))
                {
                    //multiple lectures
                    def.Flags |= CourseFlags.MultipleLectures;
                }

                // check for multiple tutorials
                var tutorialGroupMap = new Dictionary<int, int>();

                foreach (var tutorial in parser.CourseRecords.Where(x => x.Course.Code == def.Code
                                                                  && x.Type == CourseRecordType.Tutorial))
                {
                    if (!tutorialGroupMap.ContainsKey(tutorial.Group))
                    {
                        tutorialGroupMap[tutorial.Group] = 0;
                    }

                    tutorial.MultipleTutorialIndex = tutorialGroupMap[tutorial.Group]++;
                }

                if (tutorialGroupMap.Any(x => x.Value >= 2))
                {
                    //multiple tutorials
                    def.Flags |= CourseFlags.MultipleTutorials;
                }
            }
        }
    }
}
