using Pharmacy.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Services.Interfaces
{
    public interface IPrescriptionService
    {
        Task<List<Prescription>> GetAllPrescriptionsAsync();
        Task<List<Prescription>> GetPrescriptionsForMedicineAsync(int medicineId);
        Task<Prescription> GetPrescriptionByIdAsync(int prescriptionId);
        Task AddPrescriptionAsync(Prescription prescription);
        Task EditPrescriptionAsync(Prescription prescription);
        Task DeletePrescriptionAsync(int prescriptionId);
    }
}
