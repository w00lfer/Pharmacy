using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Models
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
