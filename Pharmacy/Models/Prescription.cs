using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public int Pesel { get; set; }
        public int PrescriptionNumber { get; set; }
    }
}
