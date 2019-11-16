using System;
using System.Collections.Generic;
using System.Text;

namespace WorkerApp.Models
{
    public class ItemUpdate
    {
        public string taskId { get; set; }
        public string Status { get; set; }

        public string workerid { get; set; }
        public string wLatitude { get; set; }
        public string wLongitude { get; set; }
    }
}
