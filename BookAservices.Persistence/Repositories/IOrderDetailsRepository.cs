using BookAservices.Application.Contract;
using BookAservices.Domain;
using BookAservices.Persistence.DbContexts;

namespace BookAservices.Persistence.Repositories
{
    public class IOrderDetailsRepository : IGenricRepository<OrderDetails>,IInterfaceOrderDetails
    {
        public IOrderDetailsRepository(ServicesDbContext db) : base(db)
        {
        }
    }
}
