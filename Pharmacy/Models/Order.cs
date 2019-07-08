using System;

namespace Pharmacy.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int PrescriptionId { get; set; }
        public int MedicineId { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public double OrderCost { get; set; }
    }
}
