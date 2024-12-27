using BookAservices.Application.Contract;
using BookAservices.Domain;
using BookAservices.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace BookAservices.Persistence.Repositories
{
    public class IDifferencesRepository : IGenricRepository<Differences>,IInterfaceDifferences
    {
        private readonly ServicesDbContext db;
        public IDifferencesRepository(ServicesDbContext db) : base(db)
        {
            this.db = db;
        }

        public async Task<Differences> GetDifferencesWithDifferencesData(Guid id)
        {
            return await db.Differences.Include(x=>x.DifferenceDatas).FirstAsync(x=>x.Id==id);
        }
    }
}
