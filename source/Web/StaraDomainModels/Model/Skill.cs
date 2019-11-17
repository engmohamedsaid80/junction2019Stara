using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StaraDomainModels.Model
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }
        public Worker Worker { get; set; }

        public String Description { get; set; }
    }
}
