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
            var model = new PrescriptionCreateViewModel
            {
                MedicinesWithPrescription = new SelectList(_medicineRepository.GetMedicinesWithPrescription()
                    .Select(p => new DataTransferForPrescriptionCreate{MedicineId =  p.Id, MedicineName = p.Name }).ToList(), nameof(DataTransferForPrescriptionCreate.MedicineId) , nameof(DataTransferForPrescriptionCreate.MedicineName))
            };
            TempData.Clear();
            TempData.Set("MedicinesWithPrescription", _medicineRepository.GetMedicinesWithPrescription()
                .Select(p => new DataTransferForPrescriptionCreate{MedicineId = p.Id, MedicineName = p.Name}).ToList());
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(PrescriptionCreateViewModel prescriptionCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                _prescriptionRepository.AddPrescription(prescriptionCreateViewModel.prescription);
                TempData.Remove("MedicinesWithPrescription");
                return RedirectToAction(nameof(Index));
            }

            prescriptionCreateViewModel.MedicinesWithPrescription =
                new SelectList(TempData.Get<List<DataTransferForPrescriptionCreate>>("MedicinesWithPrescription"), nameof(DataTransferForPrescriptionCreate.MedicineId), nameof(DataTransferForPrescriptionCreate.MedicineName));

            return View(prescriptionCreateViewModel);
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