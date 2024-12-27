using BookAservices.Application.Contract;
using BookAservices.Domain;
using BookAservices.Persistence.DbContexts;

namespace BookAservices.Persistence.Repositories
{
    public class IDifferenceDataRepository : IGenricRepository<DifferenceData>,IInterfaceDifferenceData
    {
        public IDifferenceDataRepository(ServicesDbContext db) : base(db)
        {
        }
    }
}
