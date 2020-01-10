using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Models;
using Pharmacy.Services.Interfaces;
using Pharmacy.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMedicineService _medicineService;
        private readonly IPrescriptionService _prescriptionService;
        private readonly IOrderService _orderService;

        public OrderController(IMapper mapper, IMedicineService medicineService, IPrescriptionService prescriptionService, IOrderService orderService)
        {
            _mapper = mapper;
            _medicineService = medicineService;
            _prescriptionService = prescriptionService;
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> Index() => 
            View(_mapper.Map<List<OrderIndexViewModel>>((await _orderService.GetAllOrdersAsync()).OrderBy(o => o.Date)));

        [HttpGet]
        public async Task<IActionResult> Create() => await Task.Run(() => View());

        [HttpPost]
        public async Task<IActionResult> Create(OrderCreateViewModel orderCreateViewModel)
        {
            var order = _mapper.Map<Order>(orderCreateViewModel);
            if (ModelState.IsValid)
            {
                await _orderService.AddOrderAsync(order);
                if(order.PrescriptionId != null)
                { 
                    await _prescriptionService.DeletePrescriptionAsync((int)order.PrescriptionId);
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