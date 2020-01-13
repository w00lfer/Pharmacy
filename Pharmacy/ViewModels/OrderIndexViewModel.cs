using Pharmacy.Models;

namespace Pharmacy.ViewModels
{
    public class OrderIndexViewModel
    {
        public Order Order { get; set; }
        public string MedicineName { get; set; }
        public bool WithPrescription { get; set; }
    }
}
