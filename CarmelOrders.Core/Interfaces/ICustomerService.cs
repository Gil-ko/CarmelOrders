using System.Collections.Generic;
using System.Threading.Tasks;
using CarmelOrders.Core.Models;

namespace CarmelOrders.Core.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> קבל_כל_הלקוחות();
        Task<Customer> קבל_לקוח_לפי_מזהה(int מזהה_לקוח);
        Task<Customer> קבל_לקוח_לפי_שם_חברה(string שם_חברה);
        Task<Customer> צור_לקוח_חדש(Customer לקוח);
        Task עדכן_לקוח(Customer לקוח);
        Task מחק_לקוח(int מזהה_לקוח);
        Task<IEnumerable<string>> קבל_גוונים_מורשים(int מזהה_לקוח);
    }
}