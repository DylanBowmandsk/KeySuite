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
    /// <summary>
    /// Parent class for webscraper children
    /// </summary>
    abstract class WebScraper
    {
        //variable holds what scipt to run
        public string progToRun { get; set; }
        //url for script to load
        public string url { get; set; }
        //host python process
        private Process proc = new Process();

        /// <summary>
        /// initialises the process values
        /// </summary>
        public void initialise()
        { 
            proc.StartInfo.FileName = "pythonw.exe";
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.Arguments = string.Concat(progToRun, " ", url);
        }

        /// <summary>
        /// sets url for script to load
        /// </summary>
        /// <param name="url"></param>
        public void setUrl(string url)
        {
            this.url = url;
        }

        /// <summary>
        /// scrapes the web for data
        /// </summary>
        /// <returns>scraped data</returns>
        public string WebScrape()
        {
            proc.Start();

            StreamReader sReader = proc.StandardOutput;
            string output = sReader.ReadToEnd();
            return output;
        }
    }
}
