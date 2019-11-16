using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WorkerApp.Models;
using TaskStatus = WorkerApp.Models.TaskStatus;

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

            Items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "1 item", Description="This is an item description.", Status=TaskStatus.Assigned, building="Building 1", street="street 1", priority="Normal" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "2 item", Description="This is an item description.", Status=TaskStatus.Completed, building="Building 1", street="street 1", priority="Normal" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "3 item", Description="This is an item description.", Status=TaskStatus.Paused, building="Building 1", street="street 1", priority="Normal" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "4 item", Description="This is an item description.", Status=TaskStatus.Cancelled, building="Building 1", street="street 1", priority="Normal" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "5 item", Description="This is an item description.", Status=TaskStatus.Started, building="Building 1", street="street 1", priority="Normal" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "6 item", Description="This is an item description.", Status=TaskStatus.Completed, building="Building 1", street="street 1", priority="Normal" }
            };

            //try
            //{
            //    var uri = new Uri(string.Format(url, string.Empty));
            //    HttpClient client = new HttpClient();
            //    var response = await client.GetAsync(uri);
            //    if (response.IsSuccessStatusCode)
            //    {
            //        var content = await response.Content.ReadAsStringAsync();
            //        Items = JsonConvert.DeserializeObject<List<Item>>(content);
            //    }
            //}
            //catch (Exception ex)
            //{

            //}

            return Items;
        }
    }
}
