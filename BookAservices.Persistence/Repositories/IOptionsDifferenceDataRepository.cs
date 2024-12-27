using BookAservices.Application.Contract;
using BookAservices.Domain;
using BookAservices.Persistence.DbContexts;

namespace BookAservices.Persistence.Repositories
{
    public class IOptionsDifferenceDataRepository : IGenricRepository<OptionsDifferenceData>,IInterfaceOptionsDifferenceData
    {
        public IOptionsDifferenceDataRepository(ServicesDbContext db) : base(db)
        {
        }
    }
}
