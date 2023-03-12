﻿using System;

namespace libreriaApp.API.Requests
{
    public class AuthorsAddRequest : RequestAddBase
    {
        public string au_id { get; set; }
        public string au_lname { get; set; }
        public string au_fname { get; set; }
        public string phone { get; set; }
        public string? address { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }
        public string? zip { get; set; }
        public bool contract { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
