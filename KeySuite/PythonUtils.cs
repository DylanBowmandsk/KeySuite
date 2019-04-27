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
using System.Threading;

namespace KeySuite
{
    class PythonUtils
    {

        public static string getSteamPrice(string url)
        {
            string price = null;


                  price = new SteamPriceWebscraper(url).WebScrape();


            return price;
        }

        public static string getG2aKeysData(string url)
        {
            string keys = null;

    
                keys = new G2aKeyWebscraper(url).WebScrape();
 
            return keys;
        }

        public static string getG2aPrice(string url)
        {
            string price = null;

  
                price = new G2aPriceWebscraper(url).WebScrape();
   

            return price;
        }
    }
}
