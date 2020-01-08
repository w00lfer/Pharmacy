using AutoMapper;
using Pharmacy.Models;
using Pharmacy.Services.Interfaces;
using Pharmacy.ViewModels;

namespace Pharmacy.Mappings.Resolvers
{
    public class WithPrescriptionResolver : IValueResolver<Order, OrderIndexViewModel, bool>
    {
        private readonly IMedicineService _medicineService;

        public WithPrescriptionResolver(IMedicineService medicineService) => _medicineService = medicineService;

        public bool Resolve(Order order, OrderIndexViewModel orderIndexViewModel, bool destMember, ResolutionContext context) =>
            _medicineService.GetMedicineByIdAsync(order.MedicineId).Result.WithPrescription;
    }
}
