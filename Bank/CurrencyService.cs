using System.IO;
using System;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace Bank
{
    public class CurrencyService
    {
        private const string CurrencyApiGBP = "http://api.nbp.pl/api/exchangerates/rates/a/gbp/?format=json";
        private const string CurrencyApiUSD = "http://api.nbp.pl/api/exchangerates/rates/a/usd/?format=json";
        private const string CurrencyApiEUR = "http://api.nbp.pl/api/exchangerates/rates/a/eur/?format=json";
        
        HttpWebRequest webRequestGBP = (HttpWebRequest)WebRequest.Create(string.Format($"{CurrencyApiGBP}"));
        HttpWebRequest webRequestUSD = (HttpWebRequest)WebRequest.Create(string.Format($"{CurrencyApiUSD}"));
        HttpWebRequest webRequestEUR = (HttpWebRequest)WebRequest.Create(string.Format($"{CurrencyApiEUR}"));
        // public List<Root> GetGBPData() => GetCurrencyData(webRequestGBP);         
        // public List<Root> GetUSDData() => GetCurrencyData(webRequestUSD);           
        // public List<Root> GetEURData() => GetCurrencyData(webRequestEUR);    

        public Root GetGBPData() => GetCurrencyData(webRequestGBP);         
        public Root GetUSDData() => GetCurrencyData(webRequestUSD);           
        public Root GetEURData() => GetCurrencyData(webRequestEUR);        

        private Root GetCurrencyData(HttpWebRequest webRequest){
            webRequest.Method = "GET";
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            Console.WriteLine(webResponse.StatusCode);
            Console.WriteLine(webResponse.Server);
            string jsonString;

            using (Stream stream = webResponse.GetResponseStream()){
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            Root CurrencyList = JsonConvert.DeserializeObject<Root>(jsonString);
            Console.WriteLine(CurrencyList);
            return CurrencyList;
        }   
        

        // private List<Root> GetCurrencyData(HttpWebRequest webRequest){
        //     webRequest.Method = "GET";
        //     HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
        //     Console.WriteLine(webResponse.StatusCode);
        //     Console.WriteLine(webResponse.Server);
        //     string jsonString;

        //     using (Stream stream = webResponse.GetResponseStream()){
        //         StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
        //         jsonString = reader.ReadToEnd();
        //     }

        //     List<Root> CurrencyList = JsonConvert.DeserializeObject<List<Root>>(jsonString);
        //     Console.WriteLine(CurrencyList.Count);
        //     return CurrencyList;
        // }


    }
}