using System;
using AutoMapper;
using Pharmacy.Mappings.Resolvers;
using Pharmacy.Models;
using Pharmacy.Models.DTO;
using Pharmacy.ViewModels;


namespace Pharmacy.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderIndexViewModel>()
                .ForMember(d => d.MedicineName, opts => opts.MapFrom<MedicineNameResolver>())
                .ForMember(d => d.WithPrescription, opts => opts.MapFrom<WithPrescriptionResolver>())
                .ForMember(d => d.Order, opts => opts.MapFrom(s => s));
            CreateMap<OrderCreateViewModel, Order>()
                .ForMember(d => d.Date, opts => opts.MapFrom(s => DateTime.UtcNow))
                .ForMember(d => d.OrderCost, opts => opts.MapFrom<OrderCostResolver>());
            CreateMap<Medicine, MedicineName>();
            CreateMap<Prescription, PrescriptionNumber>()
                .ForMember(d => d.Number, opts => opts.MapFrom(s => s.PrescriptionNumber));
        }
    }
}