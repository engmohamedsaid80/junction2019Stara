using System;
using System.Collections.Generic;
using System.Text;

namespace WorkerApp.Models
{
    public class ItemUpdate
    {
        public Item item { get; set; }
        public TaskStatus Status { get; set; }
        public string WorkerLatitude { get; set; }

        public string WorkerLongitude { get; set; }
    }
}
