using Pharmacy.Models;
using System.Collections.Generic;
using System.Linq;

namespace Pharmacy.Repositories.Interfaces
{
    public interface IMedicineRepository
    {
        IEnumerable<Medicine> GetAllMedicines();
        IQueryable<Medicine> GetMedicinesWithPrescription();
        Medicine GetMedicineById(int medicineId);
        void AddMedicine(Medicine medicine);
        void EditMedicine(Medicine medicine);
        void DeleteMedicine(Medicine medicine);
    }
}
