using System.Collections.Generic;
using System.Linq;
using Pharmacy.Models;
using Pharmacy.Repositories.Interfaces;

namespace Pharmacy.Repositories
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly AppDbContext _appDbContext;
        public MedicineRepository(AppDbContext appDbContext) => _appDbContext = appDbContext;

        public IEnumerable<Medicine> GetAllMedicines() => _appDbContext.Medicines.ToList();

        public IQueryable<Medicine> GetMedicinesWithPrescription() => _appDbContext.Medicines.Where( m => m.WithPrescription == true);

        public Medicine GetMedicineById(int medicineId) => _appDbContext.Medicines.FirstOrDefault(m => m.Id == medicineId);

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
