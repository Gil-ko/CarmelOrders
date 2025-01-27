using System.Collections.Generic;
using System.Threading.Tasks;
using CarmelOrders.Core.Models;

namespace CarmelOrders.Core.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<הזמנה>> קבל_כל_ההזמנות();
        Task<הזמנה> קבל_הזמנה_לפי_מזהה(int מספר_הזמנה);
        Task<הזמנה> צור_הזמנה_חדשה(הזמנה הזמנה);
        Task עדכן_הזמנה(הזמנה הזמנה);
        Task מחק_הזמנה(int מספר_הזמנה);
    }
}