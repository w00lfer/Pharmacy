using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Models;

namespace Pharmacy.ViewModels
{
    public class OrderIndexViewModel
    {
        public Order Order { get; set; }
        public string MedicineName { get; set; }
        public bool WithPrescription { get; set; }
    }
}
