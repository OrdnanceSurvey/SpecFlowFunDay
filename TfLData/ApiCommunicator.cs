using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TfLData
{
    public class ApiCommunicator
    {
        private string apiUrl;
        private HttpResponseMessage response;

        public ApiCommunicator(string apiUrl)
        {
            this.apiUrl = apiUrl;
        }

        public async Task GetAsync()
        {
            HttpClient client = new HttpClient();
            response = await client.GetAsync(apiUrl);
        }

        public bool? WasSuccessful()
        {
            return response.IsSuccessStatusCode;
            
        }

        public async Task<List<object>> GetListOfItemsAsync()
        {
            string content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<object>>(content);
        }
    }
}
