using Microsoft.EntityFrameworkCore;
using SalesApp.Models;

namespace SalesApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { } 

        public DbSet<SalesData> SalesData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SalesData>().HasData(
                new SalesData { Id = 1, Month = "December 2023", NewVehicleSales = 120, UsedVehicleSales = 80, InventoryLevels = 500, AppointmentSetRate = 15.2f, AppointmentCloseRate = 8.5f },
                new SalesData { Id = 2, Month = "January 2024", NewVehicleSales = 130, UsedVehicleSales = 90, InventoryLevels = 480, AppointmentSetRate = 14.8f, AppointmentCloseRate = 8.7f },
                new SalesData { Id = 3, Month = "February 2024", NewVehicleSales = 110, UsedVehicleSales = 85, InventoryLevels = 460, AppointmentSetRate = 13.5f, AppointmentCloseRate = 7.9f },
                new SalesData { Id = 4, Month = "March 2024", NewVehicleSales = 140, UsedVehicleSales = 95, InventoryLevels = 440, AppointmentSetRate = 16.0f, AppointmentCloseRate = 9.1f },
                new SalesData { Id = 5, Month = "April 2024", NewVehicleSales = 150, UsedVehicleSales = 100, InventoryLevels = 420, AppointmentSetRate = 16.8f, AppointmentCloseRate = 9.3f },
                new SalesData { Id = 6, Month = "May 2024", NewVehicleSales = 160, UsedVehicleSales = 105, InventoryLevels = 400, AppointmentSetRate = 17.2f, AppointmentCloseRate = 9.5f },
                new SalesData { Id = 7, Month = "June 2024", NewVehicleSales = 155, UsedVehicleSales = 110, InventoryLevels = 380, AppointmentSetRate = 16.5f, AppointmentCloseRate = 9.0f },
                new SalesData { Id = 8, Month = "July 2024", NewVehicleSales = 170, UsedVehicleSales = 115, InventoryLevels = 360, AppointmentSetRate = 18.0f, AppointmentCloseRate = 10.0f },
                new SalesData { Id = 9, Month = "August 2024", NewVehicleSales = 180, UsedVehicleSales = 120, InventoryLevels = 340, AppointmentSetRate = 18.5f, AppointmentCloseRate = 10.2f },
                new SalesData { Id = 10, Month = "September 2024", NewVehicleSales = 190, UsedVehicleSales = 125, InventoryLevels = 320, AppointmentSetRate = 19.0f, AppointmentCloseRate = 10.5f },
                new SalesData { Id = 11, Month = "October 2024", NewVehicleSales = 200, UsedVehicleSales = 130, InventoryLevels = 300, AppointmentSetRate = 19.8f, AppointmentCloseRate = 11.0f },
                new SalesData { Id = 12, Month = "November 2024", NewVehicleSales = 210, UsedVehicleSales = 135, InventoryLevels = 280, AppointmentSetRate = 20.2f, AppointmentCloseRate = 11.3f }
            );
        }
    }
}
