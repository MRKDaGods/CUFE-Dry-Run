using MRK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

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
        private static unsafe extern void* NativeHandleCourseRecords(COURSE* courses, int len, [MarshalAs(UnmanagedType.LPStr)] string payload, ref int dwPSz);

        public unsafe static bool Handle(List<CourseRecord> records, string payload)
        {
            var nativeCourses = records.Select(record => new COURSE
            {
                Code = (void*)Marshal.StringToHGlobalAnsi(record.Course.Code),
                Type = record.Type,
                Group = record.Group,
                Flags = record.Course.Flags,
                MultipleLectureIndex = record.MultipleLectureIndex
            }).ToArray();

            var arrSz = sizeof(COURSE) * nativeCourses.Length;
            COURSE* courses = (COURSE*)Marshal.AllocHGlobal(arrSz);

            int psz = 0;

            try
            {
                for (int i = 0; i < nativeCourses.Length; i++)
                {
                    courses[i] = nativeCourses[i];
                }

                var result = NativeHandleCourseRecords(courses, nativeCourses.Length, payload, ref psz);
                if (psz == 1)
                {
                    var str = Marshal.PtrToStringAnsi((nint)result) ?? string.Empty;
                    str = str
                        .Replace("\\t", "\t")
                        .Replace("\\n", "\n")
                        .Replace("\\\"", "\"");

                    Clipboard.SetText(str);
                    Console.WriteLine($"Native handler returned: \n{str}");
                }
            }
            finally
            {
                foreach (var course in nativeCourses)
                {
                    Marshal.FreeHGlobal((nint)course.Code);
                }

                Marshal.FreeHGlobal((nint)courses);
            }

            return psz == 1;
        }
    }
}
