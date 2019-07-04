namespace Pharmacy.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public int Pesel { get; set; }
        public int PrescriptionNumber { get; set; }
        public int MedicineId { get; set; }
    }
}
