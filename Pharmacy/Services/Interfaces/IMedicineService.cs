using Pharmacy.Models;
using Pharmacy.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Services.Interfaces
{
    public interface IMedicineService
    {
        Task<List<Medicine>> GetAllMedicinesAsync();
        Task<List<MedicineName>> GetAllMedicinesNamesAsync();
        Task<List<MedicineName>> GetMedicinesWithPrescriptionAsync();
        Task<Medicine> GetMedicineByIdAsync(int medicineId);
        Task AddMedicineAsync(Medicine medicine);
        Task EditMedicineAsync(Medicine medicine);
        Task DeleteMedicineAsync(int medicineId);
    }
}
