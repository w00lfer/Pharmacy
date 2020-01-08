using System.Collections.Generic;
using Pharmacy.Models;
using Pharmacy.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Pharmacy.Repositories
{
    public class MedicineRepository : GenericRepository<Medicine>, IMedicineRepository
    {
        public MedicineRepository(AppDbContext appDbContext)
            : base(appDbContext)
        { }

        public async Task<List<Medicine>> GetMedicinesWithPrescriptionAsync() => await GetAll().Where( m => m.WithPrescription == true).ToListAsync();
    }
}
