using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CarmelOrders.Core.Interfaces;
using CarmelOrders.Core.Models;
using CarmelOrders.Data.Context;

namespace CarmelOrders.Core.Services
{
    public class FormulaService : IFormulaService
    {
        private readonly CarmelDbContext _context;

        public FormulaService(CarmelDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Formula>> קבל_כל_הנוסחאות()
        {
            return await _context.נוסחאות
                .Where(נ => נ.פעיל)
                .ToListAsync();
        }

        public async Task<Formula> קבל_נוסחה_לפי_מזהה(int מזהה_נוסחה)
        {
            return await _context.נוסחאות.FindAsync(מזהה_נוסחה);
        }

        public async Task<Formula> קבל_נוסחה_לפי_גוון(string קוד_גוון)
        {
            return await _context.נוסחאות
                .FirstOrDefaultAsync(נ => נ.קוד_גוון == קוד_גוון && נ.פעיל);
        }

        public async Task<Formula> צור_נוסחה_חדשה(Formula נוסחה)
        {
            נוסחה.פעיל = true;
            _context.נוסחאות.Add(נוסחה);
            await _context.SaveChangesAsync();
            return נוסחה;
        }

        public async Task עדכן_נוסחה(Formula נוסחה)
        {
            _context.Entry(נוסחה).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task מחק_נוסחה(int מזהה_נוסחה)
        {
            var נוסחה = await _context.נוסחאות.FindAsync(מזהה_נוסחה);
            if (נוסחה != null)
            {
                נוסחה.פעיל = false;  // soft delete
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> בדוק_אם_יש_נוסחה(string קוד_גוון)
        {
            return await _context.נוסחאות
                .AnyAsync(נ => נ.קוד_גוון == קוד_גוון && נ.פעיל);
        }
    }
}