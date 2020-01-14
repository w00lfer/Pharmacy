using Microsoft.AspNetCore.Mvc;
using Pharmacy.Services.Interfaces;
using Pharmacy.ViewModels;
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
            View(await _orderService.GetAllOrdersAsync());

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

        public async Task<IActionResult> GetAllMedicinesNamesAsync() => Json(await _medicineService.GetAllMedicinesNamesAsync());

        public async Task<IActionResult> GetAllPrescriptionsNumbersForMedicineAsync(int medicineId) => Json(await _prescriptionService.GetAllPrescriptionsNumbersForMedicineAsync(medicineId));

        public async Task<IActionResult> GetInfoIfMedicineHasPrescriptionAsync(int medicineId) => Json((await _medicineService.GetMedicineByIdAsync(medicineId)).WithPrescription);
    }
}   