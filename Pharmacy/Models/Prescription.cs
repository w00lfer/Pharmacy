using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Models
{
    public class Prescription
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Medicine's name is required")]
        [Display(Name = "Customer name")]
        [StringLength(100, ErrorMessage = "Customer's name is too long")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Pesel name is required")]
        [Display(Name = "Pesel")]
        [MaxLength(11, ErrorMessage = "Pesel is to long")]
        [MinLength(11, ErrorMessage = " Pesel is too short")]
        public long Pesel { get; set; }

        [Required(ErrorMessage = "Prescription number is required")]
        [Display(Name = "Prescription Number")]
        public long PrescriptionNumber { get; set; }

        [Required]
        public int MedicineId { get; set; }
    }
}
