using Pharmacy.Models;
using System.Collections.Generic;

namespace Pharmacy.Repositories.Interfaces
{
    public interface IPrescriptionRepository
    {
        IEnumerable<Prescription> GetAllPrescriptions();
        Prescription GetPrescriptionById(int prescriptionId);
        void AddPrescription(Prescription prescription);
        void EditPrescription(Prescription prescription);
        void DeletePrescription(Prescription prescription);
    }
}
