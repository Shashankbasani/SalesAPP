using SalesApp.Models;

namespace SalesApp.BusinessLogic
{
    public interface ISalesBL
    {
        Task<IEnumerable<SalesData>> GetSales();
        Task AddSale(SalesData sale);
        Task UpdateSale(SalesData sale);
        Task DeleteSale(int id);
    }
}
