using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Models
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly AppDbContext _appDbContext;
        public MedicineRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Medicine> GetAllMedicines()
        {
            AddMedicine(new Medicine { Name = "Nazwa testowa", Manufacturer = "Producent testowy", Price = 15, Amount = 10, WithPrescription = false });
            return _appDbContext.Medicines;
        }

        public Medicine GetMedicineById(int medicineId)
        {
            return _appDbContext.Medicines.FirstOrDefault(m => m.Id == medicineId);
        }

        public void AddMedicine(Medicine medicine)
        {
            _appDbContext.Medicines.Add(medicine);
            _appDbContext.SaveChanges();
        }

        public void EditMedicine(Medicine medicine)
        {
            _appDbContext.Medicines.Update(medicine);
            _appDbContext.SaveChanges();
        }

        public void DeleteMedicine(Medicine medicine)
        {
            _appDbContext.Medicines.Remove(medicine);
            _appDbContext.SaveChanges(); 
        }                 
    }
}
