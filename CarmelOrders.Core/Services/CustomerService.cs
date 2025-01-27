using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CarmelOrders.Core.Interfaces;
using CarmelOrders.Core.Models;
using CarmelOrders.Data.Context;

namespace CarmelOrders.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CarmelDbContext _context;

        public CustomerService(CarmelDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> קבל_כל_הלקוחות()
        {
            return await _context.לקוחות.ToListAsync();
        }

        public async Task<Customer> קבל_לקוח_לפי_מזהה(int מזהה_לקוח)
        {
            return await _context.לקוחות.FindAsync(מזהה_לקוח);
        }

        public async Task<Customer> קבל_לקוח_לפי_שם_חברה(string שם_חברה)
        {
            return await _context.לקוחות
                .FirstOrDefaultAsync(ל => ל.שם_חברה == שם_חברה);
        }

        public async Task<Customer> צור_לקוח_חדש(Customer לקוח)
        {
            _context.לקוחות.Add(לקוח);
            await _context.SaveChangesAsync();
            return לקוח;
        }

        public async Task עדכן_לקוח(Customer לקוח)
        {
            _context.Entry(לקוח).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task מחק_לקוח(int מזהה_לקוח)
        {
            var לקוח = await _context.לקוחות.FindAsync(מזהה_לקוח);
            if (לקוח != null)
            {
                _context.לקוחות.Remove(לקוח);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<string>> קבל_גוונים_מורשים(int מזהה_לקוח)
        {
            var לקוח = await _context.לקוחות
                .Include(ל => ל.גוונים_מורשים)
                .FirstOrDefaultAsync(ל => ל.מזהה_לקוח == מזהה_לקוח);

            return לקוח?.גוונים_מורשים ?? new List<string>();
        }
    }
}