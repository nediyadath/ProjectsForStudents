using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCExample.Models
{
    public class Patient
    {
        public int id { get; set; }
        public string name { get; set; }
        public string allergies { get; set; }
    }
}