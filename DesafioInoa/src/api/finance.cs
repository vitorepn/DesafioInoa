using Newtonsoft.Json;
using System.Configuration;

namespace DesafioInoa.src.api
{
    internal class finance
    {
        static string ApiKey = ConfigurationManager.AppSettings["ApiKey"];
        static RetornoApi Stock;
        public static RetornoApi ObjetoStock(string InputStock)
        {

            string strURL = "https://api.twelvedata.com/time_series?apikey=" + ApiKey + "&interval=1min&type=stock&symbol=" + InputStock + "&timezone=America/Sao_Paulo&format=JSON&outputsize=1";
            string result = "";

            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(strURL).Result;
                if (response.IsSuccessStatusCode)
                {
                    result = response.Content.ReadAsStringAsync().Result;
                }
            }
            Stock = JsonConvert.DeserializeObject<RetornoApi>(result);
            return Stock;
        }
        public class Meta
        {
            public string symbol { get; set; }
            public string interval { get; set; }
            public string currency { get; set; }
            public string exchange_timezone { get; set; }
            public string exchange { get; set; }
            public string type { get; set; }
        }

        public class Value
        {
            public string datetime { get; set; }
            public float open { get; set; }
            public float high { get; set; }
            public float low { get; set; }
            public float close { get; set; }
            public float volume { get; set; }
        }

        public class RetornoApi
        {
            public Meta meta { get; set; }
            public List<Value> values { get; set; }
            public string status { get; set; }
        }
    }
}
