using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Models
{
    public class Medicine
    {
        public int Id { get; set; }

        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Display(Name = "Producent")]
        public string Manufacturer { get; set; }

        [Display(Name = "Cena")]
        public double Price { get; set; }

        [Display(Name = "Ilość")]
        public int Amount { get; set; }

        [Display(Name = "Na receptę")]
        public bool WithPrescription { get; set; }

    }
}
