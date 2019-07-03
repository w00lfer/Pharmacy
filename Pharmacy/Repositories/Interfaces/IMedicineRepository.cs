using Pharmacy.Models;
using System.Collections.Generic;

namespace Pharmacy.Repositories.Interfaces
{
    public interface IMedicineRepository
    {
        IEnumerable<Medicine> GetAllMedicines();
        Medicine GetMedicineById(int medicineId);
        void AddMedicine(Medicine medicine);
        void EditMedicine(Medicine medicine);
        void DeleteMedicine(Medicine medicine);
    }
}
