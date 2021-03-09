using System.Runtime.Serialization.Json;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Data;

namespace Bank
{
    public class Rate
    {
        public string no { get; set; }
        public string effectiveDate { get; set; }
        public double mid { get; set; }
    }

    public class Root
    {
        public string table { get; set; }
        public string currency { get; set; }
        public string code { get; set; }
        public List<Rate> rates { get; set; }
    }


}