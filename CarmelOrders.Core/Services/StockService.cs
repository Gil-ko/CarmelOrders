using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CarmelOrders.Core.Interfaces;
using CarmelOrders.Core.Models;
using CarmelOrders.Data.Context;

namespace CarmelOrders.Core.Services
{
    public class StockService : IStockService
    {
        private readonly CarmelDbContext _context;

        public StockService(CarmelDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Stock>> קבל_כל_המלאי()
        {
            return await _context.מלאי.ToListAsync();
        }

        public async Task<Stock> קבל_מלאי_לפי_מזהה(int מזהה_מלאי)
        {
            return await _context.מלאי.FindAsync(מזהה_מלאי);
        }

        public async Task<Stock> קבל_מלאי_לפי_גוון(string קוד_גוון)
        {
            return await _context.מלאי
                .FirstOrDefaultAsync(מ => מ.קוד_גוון == קוד_גוון);
        }

        public async Task<Stock> עדכן_כמות_במלאי(int מזהה_מלאי, decimal כמות)
        {
            var פריט = await _context.מלאי.FindAsync(מזהה_מלאי);
            if (פריט != null)
            {
                פריט.כמות_במלאי = כמות;
                await _context.SaveChangesAsync();
            }
            return פריט;
        }

        public async Task<bool> בדוק_אם_קיים_במלאי(string קוד_גוון)
        {
            var פריט = await _context.מלאי
                .FirstOrDefaultAsync(מ => מ.קוד_גוון == קוד_גוון);
            return פריט?.כמות_במלאי > 0;
        }

        public async Task<bool> בדוק_אם_מתחת_למינימום(string קוד_גוון)
        {
            var פריט = await _context.מלאי
                .FirstOrDefaultAsync(מ => מ.קוד_גוון == קוד_גוון);
            return פריט?.כמות_במלאי < פריט?.כמות_מינימום;
        }
    }
}