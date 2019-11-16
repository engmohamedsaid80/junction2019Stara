using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WorkerApp.Models;

namespace WorkerApp
{
    public class RestAPICaller
    {
        private string RestUrl;
        public RestAPICaller()
        {
            RestUrl = "";
        }
        public async Task<List<Item>> GetTasksAsync(int id)
        {
            string url = RestUrl + "/api/apisubclass/" + id;

            List<Item> Items = null;

            try
            {
                var uri = new Uri(string.Format(url, string.Empty));
                HttpClient client = new HttpClient();
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<Item>>(content);
                }
            }
            catch (Exception ex)
            {

            }

            return Items;
        }
    }
}
