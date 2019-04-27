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

        /// <summary>
        /// initiates a webscraper instance to retrieve data 
        /// </summary>
        /// <param name="url">url to scrape for steam retail price</param>
        /// <returns>retail price of current product</returns>
        public static string getSteamPrice(string url)
        {
            string price = null;
            price = new SteamPriceWebscraper(url).WebScrape();
            return price;
        }

        /// <summary>
        /// initiates a webscraper instance to retrieve data 
        /// </summary>
        /// <param name="url">url to scrape for g2a keys</param>
        /// <returns>number of keys on g2a for selected product</returns>
        public static string getG2aKeysData(string url)
        {
            string keys = null;
            keys = new G2aKeyWebscraper(url).WebScrape();
            return keys;
        }

        /// <summary>
        /// initiates a webscraper instance to retrieve data 
        /// </summary>
        /// <param name="url">url to scrape for g2a price</param>
        /// <returns>lowest price of g2a listings</returns>
        public static string getG2aPrice(string url)
        {
            string price = null;
            price = new G2aPriceWebscraper(url).WebScrape();
            return price;
        }
    }
}
