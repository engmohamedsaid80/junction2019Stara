using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkerApp.Models;

namespace WorkerApp.Services
{
    public class StaraDataStore : IDataStore<Item>
    {
        List<Item> items;

        public StaraDataStore()
        {
            GetItems();
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await System.Threading.Tasks.Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await System.Threading.Tasks.Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await System.Threading.Tasks.Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await System.Threading.Tasks.Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        private async void GetItems()
        {
            RestAPICaller restCaller = new RestAPICaller();

            items = await restCaller.GetTasksAsync(3);

            foreach (Item i in items)
            {
                switch (i.Status)
                {
                    case "Assigned": i.StatusImage = "assigned.png"; break;
                    case "Started": i.StatusImage = "started.png"; break;
                    case "Paused": i.StatusImage = "paused.png"; break;
                    case "Completed": i.StatusImage = "completed.png"; break;
                }

                if (i.priority == "Normal") i.PriorityImage = "normal.png";
                else i.PriorityImage = "urgent.png";
            }

        }
        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            GetItems();
            return await System.Threading.Tasks.Task.FromResult(items);
        }
    }
}