using Microsoft.AspNetCore.Mvc;
using Pharmacy.Models;
using System.Linq;

namespace Pharmacy.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMedicineRepository _medicineRepository;

        public HomeController(IMedicineRepository medicineRepository) => _medicineRepository = medicineRepository;

        public IActionResult Index() => View(_medicineRepository.GetAllMedicines().OrderBy(m => m.Name));
    }
}
