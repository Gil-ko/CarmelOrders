using System.Collections.Generic;
using System.Threading.Tasks;
using CarmelOrders.Core.Models;

namespace CarmelOrders.Core.Interfaces
{
    public interface IStockService
    {
        Task<IEnumerable<Stock>> קבל_כל_המלאי();
        Task<Stock> קבל_מלאי_לפי_מזהה(int מזהה_מלאי);
        Task<Stock> קבל_מלאי_לפי_גוון(string קוד_גוון);
        Task<Stock> עדכן_כמות_במלאי(int מזהה_מלאי, decimal כמות);
        Task<bool> בדוק_אם_קיים_במלאי(string קוד_גוון);
        Task<bool> בדוק_אם_מתחת_למינימום(string קוד_גוון);
    }
}