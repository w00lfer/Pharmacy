using Microsoft.AspNetCore.Mvc;
using Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMedicineRepository _medicineRepository;

        public HomeController(IMedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }

        public IActionResult Index()
        {
            var medicines = _medicineRepository.GetAllMedicines().OrderBy(m => m.Name);
            return View(medicines);
        }

    }
}
