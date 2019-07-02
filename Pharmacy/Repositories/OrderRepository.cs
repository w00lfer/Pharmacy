using System.Collections.Generic;
using System.Linq;
using Pharmacy.Models;

namespace Pharmacy.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;

        public OrderRepository(AppDbContext appDbContext) => _appDbContext = appDbContext;

        public IEnumerable<Order> GetAllOrders() => _appDbContext.Orders;

        public Order GetOrderById(int orderId) => _appDbContext.Orders.FirstOrDefault(o => o.Id == orderId);

        public void AddOrder(Order order)
        {
            _appDbContext.Orders.Add(order);
            _appDbContext.SaveChanges();
        }
        public void EditOrder(Order order)
        {
            _appDbContext.Orders.Update(order);
            _appDbContext.SaveChanges();
        }

        public void DeleteOrder(Order order)
        {
            _appDbContext.Orders.Remove(order);
            _appDbContext.SaveChanges();
        }
    }
}
