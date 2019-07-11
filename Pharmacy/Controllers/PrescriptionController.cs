using Microsoft.AspNetCore.Mvc;
using Pharmacy.Models;
using Pharmacy.Repositories.Interfaces;
using System.Linq;

namespace Pharmacy.Controllers
{
    public class PrescriptionController : Controller
    {
        private readonly IPrescriptionRepository _prescriptionRepository;
        private readonly IMedicineRepository _medicineRepository;

        public PrescriptionController(IPrescriptionRepository prescriptionRepository, IMedicineRepository medicineRepository)
        {
            _prescriptionRepository = prescriptionRepository;
            _medicineRepository = medicineRepository;
        }

        [HttpGet]
        public IActionResult Index() => View(_prescriptionRepository.GetAllPrescriptions().OrderBy(p => p.Id));

        [HttpGet]
        public IActionResult Create() => View();

            [HttpPost]
        public IActionResult Create(Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                _prescriptionRepository.AddPrescription(prescription);
                return RedirectToAction(nameof(Index));
            }
            return View(prescription);
        }

        [HttpGet]
        public IActionResult Delete(int prescriptionId) =>
            _prescriptionRepository.GetPrescriptionById(prescriptionId) is var prescription == null
                ? (IActionResult)NotFound()
                : View(prescription);

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int prescriptionId)
        {
            var prescription = _prescriptionRepository.GetPrescriptionById(prescriptionId);
            _prescriptionRepository.DeletePrescription(prescription);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult GetMedicinesWithPrescription() => Json(_medicineRepository.GetMedicinesWithPrescription().Select(m => new {MedicineId = m.Id, MedicineName = m.Name}).ToList());
    }
}