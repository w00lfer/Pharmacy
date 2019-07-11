using Microsoft.AspNetCore.Mvc;
using Pharmacy.Models;
using Pharmacy.Repositories.Interfaces;
using Pharmacy.ViewModels;
using System;
using System.Linq;

namespace Pharmacy.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMedicineRepository _medicineRepository;
        private readonly IPrescriptionRepository _prescriptionRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderController(IMedicineRepository medicineRepository, IPrescriptionRepository prescriptionRepository, IOrderRepository orderRepository)
        {
            _medicineRepository = medicineRepository;
            _prescriptionRepository = prescriptionRepository;
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var orders = _orderRepository.GetAllOrders().OrderBy(o => o.Date);
            var orderViewModels  = orders.Select(order => 
                new OrderIndexViewModel
                {
                    Order = order,
                    MedicineName = _medicineRepository.GetMedicineById(order.MedicineId).Name,
                    WithPrescription = _medicineRepository.GetMedicineById(order.MedicineId).WithPrescription
                }).ToList();

            return View(orderViewModels);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                order.Date = DateTime.UtcNow;
                order.OrderCost = _medicineRepository.GetMedicineById(order.MedicineId).Price * order.Amount;
                _orderRepository.AddOrder(order);
                if(order.PrescriptionId != null)
                {
                    _prescriptionRepository.DeletePrescription(_prescriptionRepository.GetPrescriptionById((int)order.PrescriptionId));
                }
                return RedirectToAction(nameof(Index));
            }

            return View(order);
        }


        public ActionResult GetMedicines() => Json(_medicineRepository.GetAllMedicines().Select(m => new {MedicineId = m.Id, MedicineName = m.Name}).ToList());


        public ActionResult GetPrescriptionsForMedicine(int medicineId) => Json(_prescriptionRepository.GetPrescriptionsForMedicine(medicineId).Select(p => new {PrescriptionId = p.Id, PrescriptionNumber = p.PrescriptionNumber}));

        public ActionResult GetInfoIfMedicineHasPrescription(int medicineId) => Json(_medicineRepository.GetMedicineById(medicineId).WithPrescription);
    }
}