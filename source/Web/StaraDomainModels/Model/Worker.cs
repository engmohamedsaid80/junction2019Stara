using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StaraDomainModels.Model
{
    public class Worker
    {
        public Team Team { get; set; }

        [Key]
        public int WorkerId { get; set; }
        public String Name { get; set; }
        public String PhoneNumber { get; set; }
        public String Email { get; set; }
        public String Status { get; set; }
        public String Longitude { get; set; }
        public String Latitude { get; set; }

        public List<Task> Tasks { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Hours> Hours { get; set; }
    }
}
