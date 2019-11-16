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
            RestUrl = "https://staraapi.azurewebsites.net";
        }

        public async Task<string> UpdateTaskAsync(ItemUpdate itemUpdate)
        {
            string url = RestUrl + "/api/Tasks";
            StringResponse ServiceResp = new StringResponse { Response = "" };

            try
            {
                var uri = new Uri(string.Format(url, string.Empty));

                var json = JsonConvert.SerializeObject(itemUpdate);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpClient client = new HttpClient();
                var response = await client.PostAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    var contentRes = await response.Content.ReadAsStringAsync();
                    ServiceResp = JsonConvert.DeserializeObject<StringResponse>(contentRes);
                }
            }
            catch (Exception ex)
            {
            }

            return ServiceResp.Response;
        }
        public async Task<List<Item>> GetTasksAsync(int id)
        {
            string url = RestUrl + "/api/Tasks/" + id;

            List<Models.Task> TaskItems = null;
            List<Item> Items = new List<Item>();

            //Items = new List<Item>()
            //{
            //    new Item { Id = Guid.NewGuid().ToString(), Text = "1 item", Description="This is an item description.", Status="Assigned", building="Building 1", street="street 1", priority="Normal", latitude="60.1883493",longitude="24.8223923" },
            //    new Item { Id = Guid.NewGuid().ToString(), Text = "2 item", Description="This is an item description.", Status="Completed", building="Building 1", street="street 1", priority="Normal", latitude="60.1883493",longitude="24.8223923"  },
            //    new Item { Id = Guid.NewGuid().ToString(), Text = "3 item", Description="This is an item description.", Status="Paused", building="Building 1", street="street 1", priority="Normal", latitude="60.1883493",longitude="24.8223923"  },
            //    new Item { Id = Guid.NewGuid().ToString(), Text = "4 item", Description="This is an item description.", Status="Paused", building="Building 1", street="street 1", priority="Normal", latitude="60.1883493",longitude="24.8223923"  },
            //    new Item { Id = Guid.NewGuid().ToString(), Text = "5 item", Description="This is an item description.", Status="Started", building="Building 1", street="street 1", priority="Normal", latitude="60.1883493",longitude="24.8223923"  },
            //    new Item { Id = Guid.NewGuid().ToString(), Text = "6 item", Description="This is an item description.", Status="Completed", building="Building 1", street="street 1", priority="Normal", latitude="60.1883493",longitude="24.8223923"  }
            //};

            try
            {
                var uri = new Uri(string.Format(url, string.Empty));
                HttpClient client = new HttpClient();
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    TaskItems = JsonConvert.DeserializeObject<List<Models.Task>>(content);

                    foreach (Models.Task item in TaskItems)
                    {
                        Item myItem = new Item();
                        myItem.Id = item.TaskId.ToString();
                        myItem.Text = item.Title;
                        myItem.Description = "desc";
                        myItem.latitude = item.Latitude;
                        myItem.longitude = item.Longitude;
                        myItem.priority = "Normal";
                        myItem.Status = item.Status;
                        myItem.building = item.BuildingName;
                        myItem.street = item.Streetname;

                        Items.Add(myItem);

                    }
                }
            }
            catch (Exception ex)
            {

            }

            return Items;
        }

        
    }
 }
