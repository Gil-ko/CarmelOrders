using System;

namespace CarmelOrders.Core.Models
{
    public class Order
    {
        public int מספר_הזמנה { get; set; }
        public string שם_חברה { get; set; }
        public string מוצר { get; set; }
        public decimal כמות { get; set; }
        public סוג_אריזה סוג_אריזה { get; set; }
        public string גוון { get; set; }
        public string הערות { get; set; }
        public סטטוס_הזמנה סטטוס { get; set; }
        public רמת_דחיפות דחיפות { get; set; }
        public bool עם_תעודת_משלוח { get; set; }
        public string מספר_תעודת_משלוח { get; set; }
        public DateTime תאריך_הזמנה { get; set; }
        public bool יש_נוסחה { get; set; }
        public bool קיים_במלאי { get; set; }
    }
}