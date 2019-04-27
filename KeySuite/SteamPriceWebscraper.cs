using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeySuite
{
    class SteamPriceWebscraper : WebScraper
    {
        public SteamPriceWebscraper(string url)
        {
            base.progToRun = "..\\..\\steam_webscraper.py";
            base.url = url;
            base.initialise();
            
        }
    }
}
