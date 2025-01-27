using System.Collections.Generic;
using System.Threading.Tasks;
using CarmelOrders.Core.Models;

namespace CarmelOrders.Core.Interfaces
{
    public interface IFormulaService
    {
        Task<IEnumerable<Formula>> קבל_כל_הנוסחאות();
        Task<Formula> קבל_נוסחה_לפי_מזהה(int מזהה_נוסחה);
        Task<Formula> קבל_נוסחה_לפי_גוון(string קוד_גוון);
        Task<Formula> צור_נוסחה_חדשה(Formula נוסחה);
        Task עדכן_נוסחה(Formula נוסחה);
        Task מחק_נוסחה(int מזהה_נוסחה);
        Task<bool> בדוק_אם_יש_נוסחה(string קוד_גוון);
    }
}