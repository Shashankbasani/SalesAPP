
using SalesApp.BusinessLogic;
using SalesApp.Models;
using SalesApp.Repository;

namespace SalesApp.BL
{
    public class SalesBL : ISalesBL
    {
        private readonly ISalesRepository _salesRepository;

        public SalesBL(ISalesRepository salesRepository)
        {
            _salesRepository = salesRepository;
        }

        public async Task<IEnumerable<SalesData>> GetSales()
        {
            return await _salesRepository.GetSales();
        }

        public async Task AddSale(SalesData sale)
        {
            await _salesRepository.AddSale(sale);
        }

        public async Task UpdateSale(SalesData sale)
        {
            await _salesRepository.UpdateSale(sale);
        }

        public async Task DeleteSale(int id)
        {
            await _salesRepository.DeleteSale(id);
        }
    }
}