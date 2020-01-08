using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pharmacy.Mappings;
using Pharmacy.Models;
using Pharmacy.Repositories;
using Pharmacy.Repositories.Interfaces;
using Pharmacy.Services;
using Pharmacy.Services.Interfaces;

namespace Pharmacy.Helpers
{
    public static class AppSetup
    {
        public static void ConfigureAppByDefault(this IServiceCollection services, IConfiguration configuration)
        {
            AddDatabaseAndIdentity(services, configuration);
            AddDI(services);
            services.AddMvc();
        }

        private static void AddDatabaseAndIdentity(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        private static void AddDI(this IServiceCollection services)
        {
            services.AddScoped<IMedicineRepository, MedicineRepository>();
            services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IMedicineService, MedicineService>();
            services.AddScoped<IPrescriptionService, PrescriptionService>();
            services.AddScoped<IOrderService, OrderService>(); ;
            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}