using BookAservices.Application.Contract;
using BookAservices.Domain;
using BookAservices.Persistence.DbContexts;

namespace BookAservices.Persistence.Repositories
{
    public class IServiceRequestRepository : IGenricRepository<ServiceRequest>,IInterfaceServiceRequest
    {
        public IServiceRequestRepository(ServicesDbContext db) : base(db)
        {
        }
    }
}
