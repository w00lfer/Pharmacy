using Pharmacy.Models;
using Pharmacy.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Services.Interfaces
{
    public interface IPrescriptionService
    {
        Task<List<Prescription>> GetAllPrescriptionsAsync();
        Task<List<PrescriptionNumber>> GetAllPrescriptionsNumbersForMedicineAsync(int medicineId);
        Task<Prescription> GetPrescriptionByIdAsync(int prescriptionId);
        Task AddPrescriptionAsync(Prescription prescription);
        Task EditPrescriptionAsync(Prescription prescription);
        Task DeletePrescriptionAsync(int prescriptionId);
    }
}
