﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Scripting.Hosting;
using IronPython.Runtime;
using IronPython.Hosting;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace KeySuite
{
    class PythonUtils
    {

        public static string getSteamPrice(string url)
        {
            string price = null;

            var thread = new Thread(
              () =>
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

                  price = output;
              });

            thread.Start();
            thread.Join();

            return price;
        }

        public static string getG2aKeysData(string url)
        {
            string data = null;
            var thread = new Thread(
            () =>
            {
                string progToRun = "..\\..\\g2akeys_webscraper.py";

                Process proc = new Process();
                proc.StartInfo.FileName = "pythonw.exe";
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.UseShellExecute = false;


                proc.StartInfo.Arguments = string.Concat(progToRun, " ", url);
                proc.Start();

                StreamReader sReader = proc.StandardOutput;
                data = sReader.ReadToEnd();

            });

            thread.Start();
            thread.Join();

            return data;
        }

        public static string getG2aPrice(string url)
        {
            string data = null;
            var thread = new Thread(
            () =>
            {
                string progToRun = "..\\..\\g2aprice_webscraper.py";

                Process proc = new Process();
                proc.StartInfo.FileName = "pythonw.exe";
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.UseShellExecute = false;


                proc.StartInfo.Arguments = string.Concat(progToRun, " ", url);
                proc.Start();

                StreamReader sReader = proc.StandardOutput;
                data = sReader.ReadToEnd();

            });

            thread.Start();
            thread.Join();

            return data;
        }
    }
}
