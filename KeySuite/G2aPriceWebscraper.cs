using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeySuite
{
    class G2aPriceWebscraper : WebScraper
    {
        public G2aPriceWebscraper(string url)
        {
            base.progToRun = "..\\..\\g2aprice_webscraper.py";
            base.url = url;
            base.initialise();
        }
    }
}
