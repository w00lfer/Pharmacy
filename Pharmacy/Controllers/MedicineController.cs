using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Models;
using Pharmacy.Repositories.Interfaces;

namespace Pharmacy.Controllers
{
    public class MedicineController : Controller
    {
        private readonly IMedicineRepository _medicineRepository;

        public MedicineController(IMedicineRepository medicinerepository)
        {
            _medicineRepository = medicinerepository;
        }

        [HttpGet]
        public IActionResult Index() => View(_medicineRepository.GetAllMedicines().OrderBy(m => m.Name));

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                _medicineRepository.AddMedicine(medicine);
                return RedirectToAction(nameof(Index));
            }

            return View(medicine);
        }
    }
}