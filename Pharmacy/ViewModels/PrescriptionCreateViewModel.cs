using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pharmacy.Models;

namespace Pharmacy.ViewModels
{
    public class PrescriptionCreateViewModel
    {
        public Prescription prescription { get; set; }
        public int  MedicineWithPrescriptionId { get; set; }
        public SelectList MedicinesWithPrescription { get; set; }
    }
}
