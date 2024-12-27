using BookAservices.Application.Contract;
using BookAservices.Domain;
using BookAservices.Persistence.DbContexts;

namespace BookAservices.Persistence.Repositories
{
    public class IServicesRepository : IGenricRepository<Services>,IInterfaceServices
    {
        public IServicesRepository(ServicesDbContext db) : base(db)
        {
        }
    }
}
