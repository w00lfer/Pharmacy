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
                    new Medicine {  Name = "Nazwa testowa", Manufacturer = "Producent testowy", Price = 15, Amount = 10, WithPrescription = false}
                );
                  
            }

            if (!context.Prescriptions.Any())
            {
                context.AddRange(new Prescription { CustomerName = "Paweł Kowalski", MedicineId = 2, Pesel = 123321, PrescriptionNumber = 123456 }
                );
            }
            context.SaveChanges();
        }
    }
}
