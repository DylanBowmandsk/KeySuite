using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeySuite
{
    public class Key
    {
        /// <summary>
        /// initialize default key values and set status to property using getters and setters
        /// </summary>
        public string cdkey { get; set; }
        public string product { get; set; }
        public string supplier { get; set; }
        public string distributor { get; set; }
        public string steam_url { get; set; }
        public string g2a_url { get; set; }
        public string region { get; set; }

        /// <summary>
        /// Constructor for Key Class
        /// </summary>
        /// <param name="cdkey">duh</param>
        /// <param name="product">name of product cdkey belongs to</param>
        /// <param name="supplier">the development company</param>
        /// <param name="distributor">who retails the product</param>
        /// <param name="steam_url">website page to scrape from</param>
        /// <param name="g2a_url">website page to scrape from</param>
        /// <param name="region">region lock code for the product</param>
        public Key(string cdkey, string product, string supplier, string distributor,
            string steam_url, string g2a_url, string region)
        {
            this.cdkey = cdkey;
            this.product = product;
            this.supplier = supplier;
            this.distributor = distributor;
            this.steam_url = steam_url;
            this.g2a_url = g2a_url;
            this.region = region;
        }
    }
}
