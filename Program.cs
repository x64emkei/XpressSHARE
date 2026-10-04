using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32.SafeHandles;
using XpressShare.Tests;
using XpressShare.Transfers;

namespace XpressShare
{
    internal static class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetStdHandle(int nStdHandle);
        private const int STD_OUTPUT_HANDLE = -11;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                AttachConsole(ATTACH_PARENT_PROCESS);

                try
                {
                    IntPtr handle = GetStdHandle(STD_OUTPUT_HANDLE);
                    if (handle != IntPtr.Zero && handle != new IntPtr(-1))
                    {
                        SafeFileHandle safeHandle = new SafeFileHandle(handle, false);
                        FileStream fs = new FileStream(safeHandle, FileAccess.Write);
                        StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                        sw.AutoFlush = true;
                        Console.SetOut(sw);
                    }
                }
                catch { }

                if (args[0] == "--run-tests" || args[0] == "/test")
                {
                    string summary;
                    bool passed = XpxProtocolTests.RunAllTests(out summary);
                    Console.WriteLine(summary);
                    try { File.WriteAllText("test_results.txt", summary); } catch { }
                    return passed ? 0 : 1;
                }

                if (args[0] == "--diagnostics" || args[0] == "/diag")
                {
                    string report = TransferOptimizer.GetDiagnosticReport();
                    Console.WriteLine(report);
                    try { File.WriteAllText("diagnostics_report.txt", report); } catch { }
                    return 0;
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms.SplashForm());
            return 0;
        }
    }
}
