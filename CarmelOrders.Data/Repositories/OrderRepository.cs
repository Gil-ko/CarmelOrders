using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarmelOrders.Core.Models;
using CarmelOrders.Data.Context;

namespace CarmelOrders.Data.Repositories
{
    public class OrderRepository
    {
        private readonly CarmelDbContext _context;

        public OrderRepository(CarmelDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<הזמנה>> GetAllAsync()
        {
            return await _context.הזמנות.ToListAsync();
        }

        public async Task<הזמנה> GetByIdAsync(int מספר_הזמנה)
        {
            return await _context.הזמנות.FindAsync(מספר_הזמנה);
        }

        public async Task<הזמנה> AddAsync(הזמנה הזמנה)
        {
            _context.הזמנות.Add(הזמנה);
            await _context.SaveChangesAsync();
            return הזמנה;
        }

        public async Task UpdateAsync(הזמנה הזמנה)
        {
            _context.Entry(הזמנה).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int מספר_הזמנה)
        {
            var הזמנה = await _context.הזמנות.FindAsync(מספר_הזמנה);
            if (הזמנה != null)
            {
                _context.הזמנות.Remove(הזמנה);
                await _context.SaveChangesAsync();
            }
        }
    }
}