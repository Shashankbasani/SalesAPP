using Microsoft.EntityFrameworkCore;
using SalesApp.Data;
using SalesApp.Models;


namespace SalesApp.Repository
{
    public class SalesRepository : ISalesRepository
    {
        private readonly AppDbContext _context;

        public SalesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SalesData>> GetSales()
        {
            return await _context.SalesData.ToListAsync();
        }

        public async Task AddSale(SalesData sale)
        {
            await _context.SalesData.AddAsync(sale);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSale(SalesData sale)
        {
            _context.SalesData.Update(sale);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSale(int id)
        {
            var sale = await _context.SalesData.FindAsync(id);
            if (sale != null)
            {
                _context.SalesData.Remove(sale);
                await _context.SaveChangesAsync();
            }
        }
    }
}


