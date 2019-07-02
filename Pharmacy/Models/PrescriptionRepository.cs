using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Models
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly AppDbContext _appDbContext;

        public PrescriptionRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Prescription> GetAllPrescriptions()
        {
            return _appDbContext.Prescriptions;
        }

        public Prescription GetPrescriptionById(int prescriptionId)
        {
            return _appDbContext.Prescriptions.FirstOrDefault( p => p.Id == prescriptionId);
        }

        public void AddPrescription(Prescription prescription)
        {
            _appDbContext.Prescriptions.Add(prescription);
            _appDbContext.SaveChanges();
        }

        public void EditPrescription(Prescription prescription)
        {
            _appDbContext.Prescriptions.Update(prescription);
            _appDbContext.SaveChanges();
        }

        public void DeletePrescription(Prescription prescription)
        {
            _appDbContext.Prescriptions.Remove(prescription);
            _appDbContext.SaveChanges();
        }
    }
}
