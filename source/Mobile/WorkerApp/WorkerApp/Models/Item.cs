using System;

namespace WorkerApp.Models
{
    public enum TaskStatus { Started, Paused, Completed, Cancelled, Assigned}
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }

        public TaskStatus Status { get; set; }

        public string priority { get; set; }
        public string building { get; set; }
        public string street { get; set; }
    }
}