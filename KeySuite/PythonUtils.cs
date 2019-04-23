using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Scripting.Hosting;
using IronPython.Runtime;
using IronPython.Hosting;
using System.Diagnostics;
using System.IO;

namespace KeySuite
{
    class PythonUtils
    {

        public static string getSteamPrice(string url)
        {
            string progToRun = "..\\..\\steam_webscraper.py";
            

            Process proc = new Process();
            proc.StartInfo.FileName = "pythonw.exe";
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.UseShellExecute = false;

            
            proc.StartInfo.Arguments = string.Concat(progToRun, " ", url);
            proc.Start();

            StreamReader sReader = proc.StandardOutput;
            string output = sReader.ReadToEnd();

            string price = output;
            return price;
        }

        public static string[] getG2aData(string url)
        {
            string progToRun = "..\\..\\g2a_webscraper.py";
            char[] splitter = { '\r' };

            Process proc = new Process();
            proc.StartInfo.FileName = "pythonw.exe";
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.UseShellExecute = false;


            proc.StartInfo.Arguments = string.Concat(progToRun, " ", url);
            proc.Start();

            StreamReader sReader = proc.StandardOutput;
            string[] data = sReader.ReadToEnd().Split(splitter);

            return data;
        }
    }
}
