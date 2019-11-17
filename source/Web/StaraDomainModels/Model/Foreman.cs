using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StaraDomainModels.Model
{
    public class Foreman
    {
        public Team Team { get; set; }

        [Key]
        public int ForemanId { get; set; }
        public String Name { get; set; }
        public String PhoneNumber { get; set; }
        public String Email { get; set; }
        public String Status { get; set; }

        public List<Project> Projects { get; set; }
    }
}
