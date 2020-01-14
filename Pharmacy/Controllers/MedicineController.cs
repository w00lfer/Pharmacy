using Microsoft.AspNetCore.Mvc;
using Pharmacy.Models;
using Pharmacy.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Controllers
{
    public class MedicineController : Controller
    {
        private readonly IMedicineService _medicineService;

        public MedicineController(IMedicineService medicineService) => _medicineService = medicineService;

        [HttpGet]
        public async Task<IActionResult> Index() => View((await _medicineService.GetAllMedicinesAsync()).OrderBy(m => m.Id));

        [HttpGet]
        public async Task<IActionResult> Create() => await Task.Run(() => View());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                await _medicineService.AddMedicineAsync(medicine);
                return RedirectToAction(nameof(Index));
            }
            return View(medicine);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int medicineId) =>
            await _medicineService.GetMedicineByIdAsync(medicineId) is var medicine == null
                ? (IActionResult) NotFound()
                : View(medicine);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                await _medicineService.EditMedicineAsync(medicine);
                return RedirectToAction(nameof(Index));
            }
            return View(medicine);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int medicineId) =>
            await _medicineService.GetMedicineByIdAsync(medicineId) is var medicine == null
                ? (IActionResult) NotFound()
                : View(medicine);

        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedAsync(int medicineId)
        {
            await _medicineService.DeleteMedicineAsync(medicineId);
            return RedirectToAction(nameof(Index));
        }
    }

}