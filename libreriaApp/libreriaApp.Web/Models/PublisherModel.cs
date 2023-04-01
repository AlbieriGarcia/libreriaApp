﻿using System;

namespace libreriaApp.Web.Models
{
    public class PublisherModel
    {
        public string pub_id { get; set; }
        public string pub_name { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public DateTime startDate { get; set; }
        
    }
}
