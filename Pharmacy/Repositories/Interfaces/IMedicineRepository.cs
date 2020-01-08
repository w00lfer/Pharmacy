using Pharmacy.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Repositories.Interfaces
{
    public interface IMedicineRepository : IGenericRepository<Medicine>
    {
        Task<List<Medicine>> GetMedicinesWithPrescriptionAsync();
    }
}
