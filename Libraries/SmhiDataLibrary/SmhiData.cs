using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmhiDataLibrary
{
    public class SmhiData
    {
        /// <summary>
        /// Can return null, otherwise it returns a Root object witch contain's data from the open API at SMHI.se
        /// </summary>
        /// <returns></returns>
        public Root GetSmhiData(string location)
        {
            FetchSmhiData fetchSmhiData = new FetchSmhiData(location);
            Task<string> jsonString = fetchSmhiData.GetSMHIjsonAsync();

            if (jsonString == null) { return null; }

            Root jsonData = JsonConvert.DeserializeObject<Root>(jsonString.Result);
            return jsonData;
        }

        public class Root
        {
            public DateTime approvedTime { get; set; }
            public DateTime referenceTime { get; set; }
            public Geometry geometry { get; set; }
            public List<TimeSeries> timeSeries { get; set; }
        }
        public class Geometry
        {
            public string type { get; set; }
            public List<List<double>> coordinates { get; set; }
        }
        public class TimeSeries
        {
            public DateTime validTime { get; set; }
            public List<Parameter> parameters { get; set; }
        }
        public class Parameter
        {
            public string name { get; set; }
            public string levelType { get; set; }
            public int level { get; set; }
            public string unit { get; set; }
            public List<double> values { get; set; }
        }

    }
}
