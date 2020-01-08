using Microsoft.EntityFrameworkCore;
using Pharmacy.Models;
using Pharmacy.Repositories.Interfaces;
using Pharmacy.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Services
{
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineRepository _medicineRepository;

        public MedicineService(IMedicineRepository medicineRepository) => _medicineRepository = medicineRepository;

        public async Task<List<Medicine>> GetAllMedicinesAsync() => await _medicineRepository.GetAll().ToListAsync();

        public async Task<Medicine> GetMedicineByIdAsync(int medicineId) => await _medicineRepository.GetByIdAsync(medicineId);

        public async Task<List<Medicine>> GetMedicinesWithPrescriptionAsync() => await _medicineRepository.GetMedicinesWithPrescriptionAsync();

        public async Task AddMedicineAsync(Medicine medicine) => await _medicineRepository.CreateAsync(medicine);

        public async Task DeleteMedicineAsync(int medicineId) => await _medicineRepository.DeleteAsync(medicineId);

        public async Task EditMedicineAsync(Medicine medicine) => await _medicineRepository.UpdateAsync(medicine);
    }
}
