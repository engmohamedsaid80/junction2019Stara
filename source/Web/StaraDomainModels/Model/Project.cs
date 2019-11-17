using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StaraDomainModels.Model
{
    public class Project
    {
        public Foreman Foreman { get; set; }

        [Key]
        public int ProjectId { get; set; }
        public String Longitude { get; set; }
        public String Latitude { get; set; }
        public String Streetname { get; set; }
        public String BuildingName { get; set; }
        public String Urgency { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndTime { get; set; }
        public int Duration { get; set; }

        public List<Task> Tasks { get; set; }
        public List<feedback> Feedbacks { get; set; }
    }
}
