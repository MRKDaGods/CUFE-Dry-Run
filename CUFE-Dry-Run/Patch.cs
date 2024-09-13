using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MRK
{
    public enum PageProtection : uint
    {
        PAGE_NOACCESS = 0x01,
        PAGE_READONLY = 0x02,
        PAGE_READWRITE = 0x04,
        PAGE_WRITECOPY = 0x08,
        PAGE_EXECUTE = 0x10,
        PAGE_EXECUTE_READ = 0x20,
        PAGE_EXECUTE_READWRITE = 0x40,
        PAGE_EXECUTE_WRITECOPY = 0x80,
        PAGE_GUARD = 0x100,
        PAGE_NOCACHE = 0x200,
        PAGE_WRITECOMBINE = 0x400
    }

    public partial class Patch
    {
        public static (PortableExecutableKinds, ImageFileMachine) MachineInfo
        {
            get
            {
                Assembly.GetExecutingAssembly().ManifestModule.GetPEKind(out var kind, out var machine);
                return (kind, machine);
            }
        }

        public static void PatchButtonFocusCues()
        {
            Console.WriteLine("Patching button focus cues");

            var mach = MachineInfo;
            Console.WriteLine($"Machine={mach.Item2} PEKind={mach.Item1}");

            if (mach.Item2 != ImageFileMachine.AMD64)
            {
                Console.WriteLine("Machine not x64, not patching!");
                return;
            }

            var drawFlatFocus = typeof(Button).Assembly.GetType("System.Windows.Forms.ButtonInternal.ButtonBaseAdapter")?
                .GetMethod("DrawFlatFocus", BindingFlags.NonPublic | BindingFlags.Static);
            if (drawFlatFocus == null)
            {
                Console.WriteLine("Cannot find ButtonBaseAdapter::DrawFlatFocus");
                return;
            }

            // CER who
            var replacementMethod = typeof(Patch).GetMethod("EatingCookiesRn", BindingFlags.NonPublic | BindingFlags.Static);
            if (replacementMethod == null)
            {
                Console.WriteLine("Cannot find replacement method");
                return;
            }

            RuntimeHelpers.PrepareMethod(drawFlatFocus.MethodHandle);
            RuntimeHelpers.PrepareMethod(replacementMethod.MethodHandle);

            var originalFuncPtr = drawFlatFocus.MethodHandle.GetFunctionPointer();
            var targetFuncPtr = replacementMethod.MethodHandle.GetFunctionPointer();

            Console.WriteLine($"OriginalPtr=0x{originalFuncPtr.ToInt64():X2} TargetPtr=0x{targetFuncPtr.ToInt64():X2}");

            // setup shellcode
            // mov r11, targetFuncPtr
            // jmp r11
            // 13 bytes
            byte[] shellcode = [0x49, 0xBB, .. BitConverter.GetBytes(targetFuncPtr.ToInt64()), 0x41, 0xFF, 0xE3];
            Console.WriteLine($"Shellcode: {{ {string.Join(", ", shellcode.Select(b => "0x" + b.ToString("X2")))} }}");

            Console.WriteLine("Patching...");

            unsafe
            {
                VirtualProtect(originalFuncPtr, (uint)shellcode.Length, (uint)PageProtection.PAGE_EXECUTE_READWRITE, out var oldProtect);

                void* ptr = originalFuncPtr.ToPointer();
                for (int i = 0; i < shellcode.Length; i++)
                {
                    *((byte*)ptr + i) = shellcode[i];
                }

                var hProcess = Process.GetCurrentProcess().Handle;
                FlushInstructionCache(hProcess, originalFuncPtr, (uint)shellcode.Length);

                // reset prot
                VirtualProtect(originalFuncPtr, (uint)shellcode.Length, oldProtect, out _);
            }

            Console.WriteLine("Done");
        }

        private static void EatingCookiesRn()
        {
        }

        [LibraryImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool FlushInstructionCache(nint hProcess, nint lpBaseAddress, nuint dwSize);

        [LibraryImport("kernel32.dll", SetLastError = true)]
        public static partial nint GetCurrentProcess();

        [LibraryImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool VirtualProtect(nint lpAddress, nuint dwSize, uint flNewProtect, out uint lpflOldProtect);
    }
}
