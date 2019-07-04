using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Models;

namespace Pharmacy.ViewModels
{
    public class PrescriptionVM
    {
        public IEnumerable<Medicine> MedicinesWithPrescription { get; set; }
        public Prescription Prescription { get; set; }
    }
}
