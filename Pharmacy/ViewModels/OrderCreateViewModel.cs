namespace Pharmacy.ViewModels
{
    public class OrderCreateViewModel
    {
        public int? PrescriptionId { get; set; }
        public int MedicineId { get; set; }
        public int Amount { get; set; }
    }
}
