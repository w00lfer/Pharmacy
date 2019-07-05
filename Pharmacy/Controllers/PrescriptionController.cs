using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pharmacy.Extensions;
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
            if (_prescriptionRepository.GetAllPrescriptions() is null)
            {

            }
            return View(_prescriptionRepository.GetAllPrescriptions().OrderBy(p => p.Id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new PrescriptionViewModel
            {
                MedicinesWithPrescription = new SelectList(_medicineRepository.GetMedicinesWithPrescription()
                    .Select(p => new DataTransfer{Id =  p.Id, Value = p.Name }).ToList(), nameof(DataTransfer.Id) , nameof(DataTransfer.Value))
            };
            TempData.Clear();
            TempData.Set("MedicinesWithPrescription", _medicineRepository.GetMedicinesWithPrescription()
                .Select(p => new DataTransfer{Id = p.Id, Value = p.Name}).ToList());
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(PrescriptionViewModel prescriptionViewModel)
        {
            if (ModelState.IsValid)
            {
                _prescriptionRepository.AddPrescription(prescriptionViewModel.prescription);
                TempData.Remove("MedicinesWithPrescription");
                return RedirectToAction(nameof(Index));
            }

            prescriptionViewModel.MedicinesWithPrescription =
                new SelectList(TempData.Get<List<DataTransfer>>("MedicinesWithPrescription"), nameof(DataTransfer.Id), nameof(DataTransfer.Value));

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