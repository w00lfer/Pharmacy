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
        public String MedicineName { get; set; }
        public long? PrescriptionNumber { get; set; }
    }
}
