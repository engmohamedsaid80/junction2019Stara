using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaraWebAPI.Model
{
    public class TaskUpdateModel
    {
        public Task task { get; set; }

        public string taskId { get; set; }
        public string Status { get; set; }

        public string comments { get; set; }
        public string workerid { get; set; }
        public string wLatitude { get; set; }
        public string wLongitude { get; set; }
    }
}
