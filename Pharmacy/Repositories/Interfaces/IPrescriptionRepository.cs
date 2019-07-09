﻿using Pharmacy.Models;
using System.Collections.Generic;
using System.Linq;

namespace Pharmacy.Repositories.Interfaces
{
    public interface IPrescriptionRepository
    {
        IEnumerable<Prescription> GetAllPrescriptions();
        IQueryable<Prescription> GetPrescriptionsForMedicine(int medicineId);
        Prescription GetPrescriptionById(int prescriptionId);
        void AddPrescription(Prescription prescription);
        void EditPrescription(Prescription prescription);
        void DeletePrescription(Prescription prescription);
    }
}
