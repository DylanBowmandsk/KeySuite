using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeySuite
{
    class SteamPriceWebscraper : WebScraper
    {
        /// <summary>
        /// sets script to run
        /// </summary>
        /// <param name="url">url to scrape</param>
        public SteamPriceWebscraper(string url)
        {
            base.progToRun = "..\\..\\steam_webscraper.py";
            base.url = url;
            base.initialise();
            
        }
    }
}
