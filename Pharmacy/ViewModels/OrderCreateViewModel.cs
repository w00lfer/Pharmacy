using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pharmacy.Models;

namespace Pharmacy.ViewModels
{
    public class OrderCreateViewModel
    {
        public Order Order { get; set; }
        public int MedicineId { get; set; }
        public SelectList AllMedicines { get; set; }
        public IEnumerable<long> ListOfPrescriptions { get; set; }
        public List<SelectList> PresciptionsForMedicines { get; set; }

    }
}
