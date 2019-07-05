using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pharmacy.Models;
using Pharmacy.Repositories.Interfaces;
using Pharmacy.ViewModels;

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
        public IActionResult Index()
        {
            if (_prescriptionRepository.GetAllPrescriptions() == null)
            {
                
            }
            return View(_prescriptionRepository.GetAllPrescriptions().OrderBy(p => p.Id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            var medicines = _medicineRepository.GetMedicinesWithPrescription()
                .Select(p => new {Id = p.Id, Value = p.Name}).ToList();
            var model = new PrescriptionViewModel();
            model.MedicinesWithPrescription = new SelectList(medicines, "Id", "Value");
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(PrescriptionViewModel prescriptionViewModel)
        {
            if (ModelState.IsValid)
            {
                _prescriptionRepository.AddPrescription(prescriptionViewModel.prescription);
                return RedirectToAction(nameof(Index));
            }

            return View(prescriptionViewModel);
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
    }
}