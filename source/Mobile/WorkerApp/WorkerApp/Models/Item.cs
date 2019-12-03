using System;

namespace WorkerApp.Models
{
    public enum TaskStatus { Started, Paused, Completed, Assigned}
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }

        public String Status { get; set; }

        public string StatusImage { get; set; }

        public string priority { get; set; }

        public string PriorityImage { get; set; }
        public string building { get; set; }
        public string street { get; set; }

        public string latitude { get; set; }

        public string longitude { get; set; }

        public string WorkerLatitude { get; set; }

        public string WorkerLongitude { get; set; }

        
    }
}