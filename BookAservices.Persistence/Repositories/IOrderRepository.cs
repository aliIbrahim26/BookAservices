using BookAservices.Application.Contract;
using BookAservices.Domain;
using BookAservices.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace BookAservices.Persistence.Repositories
{
    public class IOrderRepository : IGenricRepository<Order>,IInterfaceOrder
    {
        private readonly ServicesDbContext db;
        public IOrderRepository(ServicesDbContext db) : base(db)
        {
            this.db = db;
        }

        public async Task<Order> GetOrderWithDetail(Guid id)
        {
            return await db.orders.Include(x=> x.OrderDetails).FirstAsync(x=>x.Id==id);
        }
    }
}
