using Pharmacy.Models;
using System.Collections.Generic;

namespace Pharmacy.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int orderId);
        void AddOrder(Order order);
        void EditOrder(Order order);
        void DeleteOrder(Order order);

    }
}
