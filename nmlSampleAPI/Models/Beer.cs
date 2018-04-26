using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nmlSampleAPI.Models
{
    public class Beer
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string tagline { get; set; }
        public string description { get; set; }
        public string first_brewed { get; set; }
        public string contributed_by { get; set; }
        public string image_url { get; set; }
    }
}