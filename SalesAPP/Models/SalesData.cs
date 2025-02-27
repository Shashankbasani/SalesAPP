using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesApp.Models
{
    public class SalesData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string ?Month { get; set; }
        [Required]
        public int NewVehicleSales { get; set; }
        [Required]
        public int UsedVehicleSales { get; set; }
        [Required]
        public int InventoryLevels { get; set; }
        [Required]
        [Range(0, 100)]
        public float AppointmentSetRate { get; set; }
        [Required]
        [Range(0,100)]
        public float AppointmentCloseRate { get; set; }
    }
}
