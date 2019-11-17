using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StaraDomainModels.Model
{
    public class Task
    {
        public Project Project { get; set; }

        [Key]
        public int TaskId { get; set; }
        public Worker Worker { get; set; }
        public String Streetname { get; set; }
        public String BuildingName { get; set; }
        public String Longitude { get; set; }
        public String Latitude { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndTime { get; set; }
        public int Duration { get; set; }

        public String Status { get; set; }

        public String Title { get; set; }

        public String Description { get; set; }

        public String priority { get; set; }

        public List<TaskUpdate> TaskUpdates { get; set; }
    }
}
