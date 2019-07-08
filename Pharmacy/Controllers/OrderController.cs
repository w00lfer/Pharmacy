using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pharmacy.Extensions;
using Pharmacy.Models;
using Pharmacy.Repositories.Interfaces;
using Pharmacy.ViewModels;

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
            List <OrderIndexViewModel> orderViewModels  = new List<OrderIndexViewModel>();
            foreach (var order in orders)
            {
                if (_medicineRepository.GetMedicineById(order.MedicineId).WithPrescription == true)
                {
                    orderViewModels.Add(new OrderIndexViewModel
                        {
                            Order = order,
                            MedicineName = _medicineRepository.GetMedicineById(order.MedicineId).Name,
                            PrescriptionNumber = _prescriptionRepository.GetPrescriptionById(order.PrescriptionId).PrescriptionNumber
                        }
                    );
                }
                else
                {
                    orderViewModels.Add(new OrderIndexViewModel
                    {
                        Order = order,
                        MedicineName = _medicineRepository.GetMedicineById(order.MedicineId).Name,
                        PrescriptionNumber = null
                    });
                }
            }

            return View(orderViewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new OrderCreateViewModel()
            {
                AllMedicines = new SelectList(_medicineRepository.GetAllMedicines()
                    .Select(p => new DataTransferForPrescriptionCreate { MedicineId = p.Id, MedicineName = p.Name }).ToList(), nameof(DataTransferForPrescriptionCreate.MedicineId), nameof(DataTransferForPrescriptionCreate.MedicineName)),
                ListOfPrescriptions = _prescriptionRepository.GetPrescriptionsNumbers()
            };
            TempData.Clear();
            TempData.Set("AllMedicines", _medicineRepository.GetAllMedicines()
                .Select(p => new DataTransferForPrescriptionCreate { MedicineId = p.Id, MedicineName = p.Name }).ToList());
            return View(model);
        }

    }
}