using Pharmacy.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Services.Interfaces
{
    public interface IMedicineService
    {
        Task<List<Medicine>> GetAllMedicinesAsync();
        Task<List<Medicine>> GetMedicinesWithPrescriptionAsync();
        Task<Medicine> GetMedicineByIdAsync(int medicineId);
        Task AddMedicineAsync(Medicine medicine);
        Task EditMedicineAsync(Medicine medicine);
        Task DeleteMedicineAsync(int medicineId);
    }
}
