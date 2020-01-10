using Microsoft.EntityFrameworkCore;
using Pharmacy.Models;
using Pharmacy.Repositories.Interfaces;
using Pharmacy.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPrescriptionRepository _prescriptionRepository;

        public PrescriptionService(IPrescriptionRepository prescriptionRepository) =>
            _prescriptionRepository = prescriptionRepository;

        public async Task<List<Prescription>> GetAllPrescriptionsAsync() =>
            await _prescriptionRepository.GetAll().ToListAsync();

        public async Task<List<Prescription>> GetPrescriptionsForMedicineAsync(int medicineId) =>
            await _prescriptionRepository.GetPrescriptionsForMedicineAsync(medicineId);

        public async Task<Prescription> GetPrescriptionByIdAsync(int prescriptionId) =>
            await _prescriptionRepository.GetByIdAsync(prescriptionId);

        public async Task AddPrescriptionAsync(Prescription prescription) =>
            await _prescriptionRepository.CreateAsync(prescription);

        public async Task EditPrescriptionAsync(Prescription prescription) =>
            await _prescriptionRepository.UpdateAsync(prescription);

        public async Task DeletePrescriptionAsync(int prescriptionId) =>
            await _prescriptionRepository.DeleteAsync(prescriptionId);
    }
}
