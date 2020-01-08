using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Models
{
    public class Prescription : BaseEntity
    {
        [Required(ErrorMessage = "Medicine's name is required")]
        [Display(Name = "Customer name")]
        [StringLength(100, ErrorMessage = "Customer's name is too long")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Pesel name is required")]
        [Display(Name = "Pesel")]
        [Range(10000000000,99999999999,ErrorMessage = "Pesel is too long or too short")]
        public long Pesel { get; set; }

        [Required(ErrorMessage = "Prescription number is required")]
        [Display(Name = "Prescription Number")]
        public long PrescriptionNumber { get; set; }

        [Required]
        [Range(1,999999999999999,ErrorMessage = "Medicine is required")]
        public int MedicineId { get; set; }
    }
}
