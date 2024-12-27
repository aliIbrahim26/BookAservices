using BookAservices.Application.Contract;
using BookAservices.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace BookAservices.Persistence.Repositories
{
    public class IGenricRepository<T> : IGenricInterface<T> where T : class
    {
        private readonly ServicesDbContext db;

        public IGenricRepository(ServicesDbContext db)
        {
            this.db = db;
        }

        public async Task<List<T>> GetAllAsync()
        {
            var result = await db.Set<T>().ToListAsync();
            return result;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var result = await db.Set<T>().FindAsync(id);
            return result;
        }

        public async Task AddAsync(T Entity)
        {
            var result =  db.Add(Entity);
           await db.SaveChangesAsync();
        }

        public async Task UpdateAsync(T Entity)
        {
           db.Update(Entity);
           await db.SaveChangesAsync();
        }
        public async Task DeleteAsync(T Entity)
        {
           db.Remove(Entity);
            await db.SaveChangesAsync();
        }

       
    }
}
