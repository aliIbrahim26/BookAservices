using BookAservices.Application.Contract;
using BookAservices.Domain;
using BookAservices.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace BookAservices.Persistence.Repositories
{
    public class IOptionsDifferenceRepository : IGenricRepository<OptionsDifference>,IInterfaceOptionsDifference
    {
        private readonly ServicesDbContext db;
        public IOptionsDifferenceRepository(ServicesDbContext db) : base(db)
        {
            this.db = db;
        }

        public async Task<OptionsDifference> GetOptionsDifferenceWithDetails(Guid id)
        {
            return await db.OptionsDifferences.Include(x=>x.optionsDifferenceDatas).FirstAsync(x=>x.Id == id);
        }
    }
}
