using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StaraDomainModels.Model
{
    public class Hours
    {
        [Key]
        public int Id { get; set; }
        public Worker Worker { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Duration { get; set; }
    }
}
