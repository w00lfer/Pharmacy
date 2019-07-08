using System;
using System.Linq;

namespace Pharmacy.Models
{
    public class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Medicines.Any())
            {
                context.AddRange(
                    new Medicine {  Name = "Nazwa testowa", Manufacturer = "Producent testowy", Price = 15, Amount = 10, WithPrescription = true}
                );
                  
            }

            if (!context.Prescriptions.Any())
            {
                context.AddRange(new Prescription { CustomerName = "Paweł Kowalski", MedicineId = 2, Pesel = 123321, PrescriptionNumber = 123456 }
                );
            }

            if (!context.Orders.Any())
            {
                context.AddRange(
                    new Order { Amount = 3, Date = new DateTime(2019,3,20), MedicineId =1, PrescriptionId = 1022, OrderCost = 45.0}
                        );
            }
            context.SaveChanges();
        }
    }
}
