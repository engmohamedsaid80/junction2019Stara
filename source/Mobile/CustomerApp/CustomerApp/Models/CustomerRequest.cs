using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Models
{
    public class CustomerRequest
    {
        public int RequestId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string BuildingName { get; set; }
        public string Streetname { get; set; }

        public string PictureUrl { get; set; }
    }
}
