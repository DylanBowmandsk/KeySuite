using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Threading;

namespace KeySuite
{
    class WebScraper
    {
        public string progToRun = null;
        public string url = null;
        private Process proc = new Process();

       public void initialise()
        { 
            proc.StartInfo.FileName = "pythonw.exe";
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.Arguments = string.Concat(progToRun, " ", url);
        }

        public void setUrl(string url)
        {
            this.url = url;
        }

        public string WebScrape()
        {
            proc.Start();

            StreamReader sReader = proc.StandardOutput;
            string output = sReader.ReadToEnd();
            return output;
        }
    }
}
