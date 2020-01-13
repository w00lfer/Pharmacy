using Pharmacy.Models;
using Pharmacy.Repositories.Interfaces;

namespace Pharmacy.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext appDbContext)
            : base(appDbContext)
        { }
    }
}
