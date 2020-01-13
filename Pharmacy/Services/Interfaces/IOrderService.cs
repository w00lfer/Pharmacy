using Pharmacy.Models;
using Pharmacy.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderIndexViewModel>> GetAllOrdersAsync();
        Task<Order> GetOrderByIdAsync(int orderId);
        Task AddOrderAsync(OrderCreateViewModel orderCreateViewModel);
        Task EditOrderAsync(Order order);
        Task DeleteOrderAsync(int orderId);
    }
}
