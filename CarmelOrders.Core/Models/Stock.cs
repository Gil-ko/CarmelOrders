namespace CarmelOrders.Core.Models
{
    public class Stock
    {
        public int מזהה_מלאי { get; set; }
        public string קוד_גוון { get; set; }
        public decimal כמות_במלאי { get; set; }
        public decimal כמות_מינימום { get; set; }
        public סוג_אריזה סוג_אריזה { get; set; }
        public string הערות { get; set; }
    }
}