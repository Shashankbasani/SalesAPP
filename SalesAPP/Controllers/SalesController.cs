
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using SalesApp.Models;
using System;
using SalesApp.BusinessLogic;
using SalesApp.Data;

namespace SalesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesBL _salesBL;

        public SalesController(ISalesBL salesBL)
        {
            _salesBL = salesBL;
        }

        [HttpGet("GetSales")]
        public async Task<IEnumerable<SalesData>> GetSales()
        {
            try
            {
                return await _salesBL.GetSales();
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching sales data", ex);
            }
        }

        [HttpPost("AddSale")]
        public async Task<IActionResult> AddSale([FromBody] SalesData sale)
        {
            try
            {
                if (sale == null)
                    return BadRequest("Invalid sale data");

                await _salesBL.AddSale(sale);
                return Ok("Sale added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error adding sale: {ex.Message}");
            }
        }

        [HttpPut("UpdateSale")]
        public async Task<string> UpdateSale([FromBody] SalesData sale)
        {
            try
            {
                if (sale == null || sale.Id <= 0)
                    return "Invalid sale data";

                await _salesBL.UpdateSale(sale);
                return "Sale updated successfully";
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating sale", ex);
            }
        }

        [HttpDelete("DeleteSale/{id}")]
        public async Task<string> DeleteSale(int id)
        {
            try
            {
                if (id <= 0)
                    return "Invalid sale ID";

                await _salesBL.DeleteSale(id);
                return "Sale deleted successfully";
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting sale", ex);
            }
        }
    }
}
