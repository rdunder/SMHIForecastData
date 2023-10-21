using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmhiDataLibrary
{
    public class LocationData
    {
        public string Thn { get; private set; }
        public string Gbg { get; private set; }
        public string Sthlm { get; private set; }

        public LocationData() 
        {
            Thn = @"https://opendata-download-metfcst.smhi.se/api/category/pmp3g/version/2/geotype/point/lon/12.265978/lat/58.28608/data.json";
            Gbg = @"https://opendata-download-metfcst.smhi.se/api/category/pmp3g/version/2/geotype/point/lon/11.973982/lat/57.709421/data.json";
            Sthlm = @"https://opendata-download-metfcst.smhi.se/api/category/pmp3g/version/2/geotype/point/lon/18.058326/lat/59.330158/data.json";
        }
    }
}
