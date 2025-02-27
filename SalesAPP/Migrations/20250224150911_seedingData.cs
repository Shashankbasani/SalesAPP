using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SalesApp.Migrations
{
    /// <inheritdoc />
    public partial class seedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_salesDatas",
                table: "salesDatas");

            migrationBuilder.RenameTable(
                name: "salesDatas",
                newName: "SalesData");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesData",
                table: "SalesData",
                column: "Id");

            migrationBuilder.InsertData(
                table: "SalesData",
                columns: new[] { "Id", "AppointmentCloseRate", "AppointmentSetRate", "InventoryLevels", "Month", "NewVehicleSales", "UsedVehicleSales" },
                values: new object[,]
                {
                    { 1, 8.5f, 15.2f, 500, "December 2023", 120, 80 },
                    { 2, 8.7f, 14.8f, 480, "January 2024", 130, 90 },
                    { 3, 7.9f, 13.5f, 460, "February 2024", 110, 85 },
                    { 4, 9.1f, 16f, 440, "March 2024", 140, 95 },
                    { 5, 9.3f, 16.8f, 420, "April 2024", 150, 100 },
                    { 6, 9.5f, 17.2f, 400, "May 2024", 160, 105 },
                    { 7, 9f, 16.5f, 380, "June 2024", 155, 110 },
                    { 8, 10f, 18f, 360, "July 2024", 170, 115 },
                    { 9, 10.2f, 18.5f, 340, "August 2024", 180, 120 },
                    { 10, 10.5f, 19f, 320, "September 2024", 190, 125 },
                    { 11, 11f, 19.8f, 300, "October 2024", 200, 130 },
                    { 12, 11.3f, 20.2f, 280, "November 2024", 210, 135 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesData",
                table: "SalesData");

            migrationBuilder.DeleteData(
                table: "SalesData",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SalesData",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SalesData",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SalesData",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SalesData",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SalesData",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SalesData",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SalesData",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SalesData",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SalesData",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SalesData",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "SalesData",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.RenameTable(
                name: "SalesData",
                newName: "salesDatas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_salesDatas",
                table: "salesDatas",
                column: "Id");
        }
    }
}
