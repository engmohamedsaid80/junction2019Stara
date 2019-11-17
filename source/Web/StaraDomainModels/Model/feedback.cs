using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StaraDomainModels.Model
{
    public class feedback
    {
        [Key]
        public int FeedbackId { get; set; }
        public Project Project { get; set; }

        public int Description { get; set; }
    }
}
