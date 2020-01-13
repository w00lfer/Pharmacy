using Pharmacy.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Repositories.Interfaces
{
    public interface IPrescriptionRepository : IGenericRepository<Prescription>
    {
        Task<List<Prescription>> GetPrescriptionsForMedicineAsync(int medicineId);
    }
}
