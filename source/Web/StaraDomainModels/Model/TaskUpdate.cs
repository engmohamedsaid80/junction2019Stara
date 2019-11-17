using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StaraDomainModels.Model
{
    public class TaskUpdate
    {

        [Key]
        public int Id { get; set; }
        public Task Task { get; set; }
        public string task_Id { get; set; }
        public string worker_id { get; set; }
        public String Status { get; set; }
        public String Description { get; set; }
        public String PictureUrl { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
