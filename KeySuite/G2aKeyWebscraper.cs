using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeySuite
{
    class G2aKeyWebscraper : WebScraper
    {
        public G2aKeyWebscraper(string url)
        {
            base.progToRun = "..\\..\\g2akeys_webscraper.py";
            base.url = url;
            base.initialise();
        }
    }
}
