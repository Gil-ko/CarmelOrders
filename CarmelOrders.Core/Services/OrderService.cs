using System.Collections.Generic;
using System.Threading.Tasks;
using CarmelOrders.Core.Interfaces;
using CarmelOrders.Core.Models;

namespace CarmelOrders.Core.Services
{
    public class OrderService : IOrderService
    {
        public async Task<IEnumerable<הזמנה>> קבל_כל_ההזמנות()
        {
            // TODO: יש להוסיף את הלוגיקה
            return new List<הזמנה>();
        }

        public async Task<הזמנה> קבל_הזמנה_לפי_מזהה(int מספר_הזמנה)
        {
            // TODO: יש להוסיף את הלוגיקה
            return new הזמנה();
        }

        public async Task<הזמנה> צור_הזמנה_חדשה(הזמנה הזמנה)
        {
            // TODO: יש להוסיף את הלוגיקה
            return הזמנה;
        }

        public async Task עדכן_הזמנה(הזמנה הזמנה)
        {
            // TODO: יש להוסיף את הלוגיקה
        }

        public async Task מחק_הזמנה(int מספר_הזמנה)
        {
            // TODO: יש להוסיף את הלוגיקה
        }
    }
}