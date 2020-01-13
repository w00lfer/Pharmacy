using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Models;
using Pharmacy.Repositories.Interfaces;
using Pharmacy.Services.Interfaces;
using Pharmacy.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<List<OrderIndexViewModel>> GetAllOrdersAsync() => _mapper.Map<List<OrderIndexViewModel>>(await _orderRepository.GetAll().ToListAsync());

        public async Task<Order> GetOrderByIdAsync(int orderId) => await _orderRepository.GetByIdAsync(orderId);

        public async Task AddOrderAsync(OrderCreateViewModel orderCreateViewModel) => await _orderRepository.CreateAsync(_mapper.Map<Order>(orderCreateViewModel));

        public async Task EditOrderAsync(Order order) => await _orderRepository.UpdateAsync(order);

        public async Task DeleteOrderAsync(int orderId) => await _orderRepository.DeleteAsync(orderId);
    }
}
