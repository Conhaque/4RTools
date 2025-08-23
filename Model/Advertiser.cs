using _4RTools.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4RTools.Model
{
    internal class Advertiser
    {
        public string bannerUrl { get; set; }
        public string discordUrl { get; set; }
        public string websiteUrl { get; set; }

        private static System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient();



        public Advertiser(string bannerUrl, string discordUrl, string websiteUrl) 
        { 
            this.bannerUrl = bannerUrl;
            this.discordUrl = discordUrl;
            this.websiteUrl = websiteUrl;
        }

        public static List<Advertiser> LoadAdvertiser() {
            List<Advertiser> ads = new List<Advertiser> { };

            try
            {
                // Advertisement fetching disabled - working offline only
                // Skip external advertisement loading
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ads;
        }
    }
}
