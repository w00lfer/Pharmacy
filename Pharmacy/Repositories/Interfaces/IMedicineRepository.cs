using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Models
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
