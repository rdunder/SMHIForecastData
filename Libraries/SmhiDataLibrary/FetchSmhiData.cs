using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SmhiDataLibrary
{
    internal class FetchSmhiData
    {
        public string _location { get; private set; }

        public FetchSmhiData(string location)
        {
            _location = location;
        }

        internal async Task<string> GetSMHIjsonAsync()
        {
            HttpClient httpClient = new HttpClient();
            string getJsonURL = _location;
            HttpResponseMessage respons = await httpClient.GetAsync(getJsonURL);

            httpClient.Dispose();

            string jsonString = await respons.Content.ReadAsStringAsync();
            return jsonString;
        }
    }
}