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
                    new Medicine {  Name = "Nazwa testowa", Manufacturer = "Producent testowy", Price = 15, Amount = 10, WithPrescription = false }
                    );
                  
            }
            context.SaveChanges();
        }
    }
}
