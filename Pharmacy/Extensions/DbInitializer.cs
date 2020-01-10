using System;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Models
{
    public class DbInitializer
    {
        public static async Task Seed(AppDbContext context)
        {
            if (!context.Medicines.Any())
            {
                await context.AddRangeAsync(
                    new Medicine {  Name = "Medtest", Manufacturer = "Best medicines", Price = 15, Amount = 10, WithPrescription = true},
                    new Medicine { Name = "Medito", Manufacturer = "Pharmo", Price = 25, Amount = 5, WithPrescription = false },
                    new Medicine { Name = "Prescro", Manufacturer = "Pharmo ", Price = 50, Amount = 3, WithPrescription = true }
                    );            
            }

            if (!context.Prescriptions.Any())
            {
                await context.AddRangeAsync(
                    new Prescription { CustomerName = "John Doe", MedicineId = 3, Pesel = 11111111111, PrescriptionNumber = 123456 }
                    );
            }

            if (!context.Orders.Any())
            {
                await context.AddRangeAsync(
                    new Order { Amount = 1, Date = new DateTime(2019,3,20), MedicineId =3, PrescriptionId = 1, OrderCost = 50.0},
                    new Order { Amount = 2, Date = new DateTime(2019, 5, 2), MedicineId = 3, PrescriptionId = 1, OrderCost = 100.0 },
                    new Order { Amount = 5, Date = new DateTime(2019, 8, 11), MedicineId = 2, PrescriptionId = null, OrderCost = 125.0 }
                    );
            }
            await context.SaveChangesAsync();
        }
    }
}
