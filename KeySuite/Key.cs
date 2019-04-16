using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeySuite
{
    public class Key
    {
        public string cdkey { get; set; }
        public string product { get; set; }
        public string supplier { get; set; }
        public string distributor { get; set; }
        public string steam_url { get; set; }
        public string g2a_url { get; set; }
        public string region { get; set; }

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
