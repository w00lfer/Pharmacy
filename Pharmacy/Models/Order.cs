using System;
using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Models
{
    public class Order : BaseEntity
    {
        [Range(1, 99999999999999999,ErrorMessage = "You can't choose default option")]
        public int? PrescriptionId { get; set; }

        [Required(ErrorMessage = "Medicine is required")]
        [Range(1,99999999999999999,ErrorMessage = "Medicine is required")]
        public int MedicineId { get; set; }

        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        [Range(0,100)]
        public int Amount { get; set; }

        public double OrderCost { get; set; }
    }
}
