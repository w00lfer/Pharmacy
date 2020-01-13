using Microsoft.AspNetCore.Mvc;
using Pharmacy.Services.Interfaces;
using Pharmacy.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMedicineService _medicineService;
        private readonly IPrescriptionService _prescriptionService;
        private readonly IOrderService _orderService;

        public OrderController(IMedicineService medicineService, IPrescriptionService prescriptionService, IOrderService orderService)
        {
            _medicineService = medicineService;
            _prescriptionService = prescriptionService;
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> Index() => 
            View((await _orderService.GetAllOrdersAsync()).OrderBy(o => o.Order.Date));

        [HttpGet]
        public async Task<IActionResult> Create() => await Task.Run(() => View());

        [HttpPost]
        public async Task<IActionResult> Create(OrderCreateViewModel orderCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                await _orderService.AddOrderAsync(orderCreateViewModel);
                if(orderCreateViewModel.PrescriptionId != null)
                { 
                    await _prescriptionService.DeletePrescriptionAsync((int)orderCreateViewModel.PrescriptionId);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(orderCreateViewModel);
        }

        public async Task<IActionResult> GetMedicinesAsync() => Json((await _medicineService.GetAllMedicinesAsync()).Select(m => new {MedicineId = m.Id, MedicineName = m.Name}).ToList());

        public async Task<IActionResult> GetPrescriptionsForMedicineAsync(int medicineId) => Json((await _prescriptionService.GetPrescriptionsForMedicineAsync(medicineId)).Select(p => new {PrescriptionId = p.Id, PrescriptionNumber = p.PrescriptionNumber}));

        public async Task<IActionResult> GetInfoIfMedicineHasPrescriptionAsync(int medicineId) => Json((await _medicineService.GetMedicineByIdAsync(medicineId)).WithPrescription);
    }
}