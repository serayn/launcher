using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace launcher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (System.IO.File.Exists("update.exe"))
            {
              if (System.IO.File.Exists("atheroz launcher.exe"))
                {
                    try
                    {
                        System.IO.File.Delete("atheroz launcher.exe");
                        System.IO.File.Copy("update.exe", "updating.exe");
                    }
                    catch { }
                    try
                    {
                        System.Diagnostics.Process.Start("updating.exe");
                        Environment.Exit(-1);
                    }
                    catch { }
                }
              if (System.IO.File.Exists("updating.exe"))
                {
                    try
                    {
                        System.IO.File.Delete("update.exe");
                        System.IO.File.Copy("updating.exe", "atheroz launcher.exe");
                    }
                    catch { }
                    try
                    {
                        System.Diagnostics.Process.Start("atheroz launcher.exe");
                        Environment.Exit(-1);
                    }
                    catch { }
                }
            }
            if (System.IO.File.Exists("updating.exe")&& System.IO.File.Exists("atheroz launcher.exe"))
            {
                try
                {
                    System.IO.File.Delete("updating.exe");
                }
                catch { }
            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
