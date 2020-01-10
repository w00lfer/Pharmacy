using Microsoft.EntityFrameworkCore;
using Pharmacy.Models;
using Pharmacy.Repositories.Interfaces;
using Pharmacy.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository) => _orderRepository = orderRepository;

        public async Task<List<Order>> GetAllOrdersAsync() => await _orderRepository.GetAll().ToListAsync();

        public async Task<Order> GetOrderByIdAsync(int orderId) => await _orderRepository.GetByIdAsync(orderId);

        public async Task AddOrderAsync(Order order) => await _orderRepository.CreateAsync(order);

        public async Task EditOrderAsync(Order order) => await _orderRepository.UpdateAsync(order);

        public async Task DeleteOrderAsync(int orderId) => await _orderRepository.DeleteAsync(orderId);
    }
}
