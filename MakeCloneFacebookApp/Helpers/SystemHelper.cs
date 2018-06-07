using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MakeCloneFacebookApp.Helpers
{
    public class SystemHelper
    {
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        public static string GetSerial()
        {
            Process proc = new Process();
            proc.StartInfo.FileName = "CMD.exe";
            proc.StartInfo.Arguments = "/c wmic bios get serialnumber > serial.dat";
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.Start();
            proc.WaitForExit();

            string data = File.ReadAllText("serial.dat");
            File.Delete("serial.dat");
            return data.Split('\n')[1].Substring(0, 8);
        }
    }
}
