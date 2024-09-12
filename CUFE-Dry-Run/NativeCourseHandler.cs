using MRK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace MRK
{
    public class NativeCourseHandler
    {
        [StructLayout(LayoutKind.Sequential)]
        unsafe struct COURSE
        {
            public void* Code;

            [MarshalAs(UnmanagedType.I4)]
            public CourseRecordType Type;

            public int Group;

            [MarshalAs(UnmanagedType.I4)]
            public CourseFlags Flags;

            public int MultipleLectureIndex;
        }

        [DllImport("CrynNativeCourseHandler.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static unsafe extern void* NativeHandleCourseRecords(COURSE* courses, int len);

        public unsafe static void Test(List<CourseRecord> selectedRecords)
        {
            var nativeCourses = selectedRecords.Select(record => new COURSE
            {
                Code = (void*)Marshal.StringToHGlobalAnsi(record.Course.Code),
                Type = record.Type,
                Group = record.Group,
                Flags = record.Course.Flags,
                MultipleLectureIndex = record.MultipleLectureIndex
            }).ToArray();

            var arrSz = sizeof(COURSE) * nativeCourses.Length;
            COURSE* courses = (COURSE*)Marshal.AllocHGlobal(arrSz);

            try
            {
                for (int i = 0; i < nativeCourses.Length; i++)
                {
                    courses[i] = nativeCourses[i];
                }

                var result = NativeHandleCourseRecords(courses, nativeCourses.Length);
                Console.WriteLine("Result from native: " + Marshal.PtrToStringAnsi((nint)result));
            }
            finally
            {
                foreach (var course in nativeCourses)
                {
                    Marshal.FreeHGlobal((nint)course.Code);
                }

                Marshal.FreeHGlobal((nint)courses);
            }
        }
    }
}
