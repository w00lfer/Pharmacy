using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Models;
using Pharmacy.Repositories.Interfaces;
using Pharmacy.ViewModels;

namespace Pharmacy.Controllers
{
    public class PrescriptionController : Controller
    {
        private readonly IPrescriptionRepository _prescriptionRepository;
        private readonly IMedicineRepository _medicineRepository;

        public PrescriptionController(IPrescriptionRepository prescriptionRepository, IMedicineRepository medicineRepository)
        {
            _prescriptionRepository = prescriptionRepository;
            _medicineRepository = medicineRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (_prescriptionRepository.GetAllPrescriptions() == null)
            {
                
            }
            return View(new PrescriptionVM
            {
                MedicinesWithPrescription = _medicineRepository.GetAllMedicines().Where( m => m.WithPrescription == true),
                Prescription =
            });
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                _prescriptionRepository.AddPrescription(prescription);
            }
            return View(prescription)
        }
    }
}