using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Pharmacy.Models;
using Pharmacy.Repositories.Interfaces;

namespace Pharmacy.Repositories
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly AppDbContext _appDbContext;

        public PrescriptionRepository(AppDbContext appDbContext) => _appDbContext = appDbContext;

        public IEnumerable<Prescription> GetAllPrescriptions() => _appDbContext.Prescriptions;

        public IEnumerable<long> GetPrescriptionsNumbers() => _appDbContext.Prescriptions.Select(p => p.PrescriptionNumber).ToList();

        public Prescription GetPrescriptionById(int prescriptionId) => _appDbContext.Prescriptions.FirstOrDefault(p => p.Id == prescriptionId);

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
