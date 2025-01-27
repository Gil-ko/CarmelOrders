using System.Collections.Generic;

namespace CarmelOrders.Core.Models
{
    public class Customer
    {
        public int מזהה_לקוח { get; set; }
        public string שם_חברה { get; set; }
        public string איש_קשר { get; set; }
        public string טלפון { get; set; }
        public string כתובת { get; set; }
        public string אימייל { get; set; }
        public List<string> גוונים_מורשים { get; set; } = new List<string>();
        public string הערות { get; set; }
    }
}