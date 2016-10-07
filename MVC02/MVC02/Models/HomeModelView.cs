using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC02.Models
{
    public class HomeModelView
    {
        public IList<String> RangeDays { get; set; }
        public IList<DateTime> RangeValues { get; set; }
        public bool isChecked { get; set; }
        public string ClientFormater { get; set; }
        public Dictionary<String, String> MapDays { get; set; }
        public HomeModelView()
        {
            RangeDays = new List<string>();
            RangeValues = new List<DateTime>();
            MapDays =  new Dictionary<String, String>();

        }

    }

}