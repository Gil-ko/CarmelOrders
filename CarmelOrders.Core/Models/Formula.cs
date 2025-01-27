namespace CarmelOrders.Core.Models
{
    public class Formula
    {
        public int מזהה_נוסחה { get; set; }
        public string קוד_גוון { get; set; }
        public string שם_גוון { get; set; }
        public string נוסחה { get; set; }
        public string הערות { get; set; }
        public bool פעיל { get; set; }
        public int מזהה_לקוח { get; set; }
    }
}