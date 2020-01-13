using AutoMapper;
using Pharmacy.Models;
using Pharmacy.Services.Interfaces;
using Pharmacy.ViewModels;

namespace Pharmacy.Mappings.Resolvers
{
    public class MedicineNameResolver : IValueResolver<Order, OrderIndexViewModel, string>
    {
        private readonly IMedicineService _medicineService;

        public MedicineNameResolver(IMedicineService medicineService) => _medicineService = medicineService;

        public string Resolve(Order order, OrderIndexViewModel orderIndexViewModel, string destMember,
            ResolutionContext context) =>
            _medicineService.GetMedicineByIdAsync(order.MedicineId).Result.Name;
    }
}
