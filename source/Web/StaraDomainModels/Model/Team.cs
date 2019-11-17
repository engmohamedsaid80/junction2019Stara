using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StaraDomainModels.Model
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        public String Name { get; set; }
        public String Foreman { get; set; }

        public List<Worker> Workers { get; set; }
    }
}
