using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Models
{
    public class Medicine : BaseEntity
    {
        [Required(ErrorMessage = "Medicine's name is required")]
        [Display(Name = "Name")]
        [StringLength(100,ErrorMessage = "Medicine's name is too long")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Manufacturer's name is required")]
        [Display(Name = "Manufacturer")]
        [StringLength(100, ErrorMessage = "Manufacturer's name is too long")]
        public string Manufacturer { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Display(Name = "Price")]
        [DataType(DataType.Currency, ErrorMessage = "Price format is not valid ")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        [Display(Name = "Amount")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "It is required")]
        [Display(Name = "With prescription")]
        public bool WithPrescription { get; set; }

    }
}
