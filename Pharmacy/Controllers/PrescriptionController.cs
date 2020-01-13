using Microsoft.AspNetCore.Mvc;
using Pharmacy.Models;
using Pharmacy.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Controllers
{
    public class PrescriptionController : Controller
    {
        private readonly IPrescriptionService _prescriptionService;
        private readonly IMedicineService _medicineService;

        public PrescriptionController(IPrescriptionService prescriptionService, IMedicineService medicineService)
        {
            _prescriptionService = prescriptionService;
            _medicineService = medicineService;
        }

        [HttpGet]
        public async Task<IActionResult> Index() => View((await _prescriptionService.GetAllPrescriptionsAsync()).OrderBy(p => p.Id));

        [HttpGet]
        public async Task<IActionResult> Create() => await Task.Run(() => View());

        [HttpPost]
        public async Task<IActionResult> Create(Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                await _prescriptionService.AddPrescriptionAsync(prescription);
                return RedirectToAction(nameof(Index));
            }
            return View(prescription);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int prescriptionId) =>
            await _prescriptionService.GetPrescriptionByIdAsync(prescriptionId) is var prescription && prescription == null
                ? (IActionResult)NotFound()
                : View(prescription);

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int prescriptionId)
        {
            await _prescriptionService.DeletePrescriptionAsync(prescriptionId);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> GetMedicinesWithPrescriptionAsync() => Json(await _medicineService.GetMedicinesWithPrescriptionAsync());
    }
}