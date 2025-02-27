using SalesApp.Models;

public interface ISalesRepository
{
    Task<IEnumerable<SalesData>> GetSales();
    Task AddSale(SalesData sale);
    Task UpdateSale(SalesData sale);
    Task DeleteSale(int id);
}
