namespace BookAservices.Application.Contract
{
    public interface IGenricInterface<T> where T : class
    {
        Task <List<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task AddAsync(T Entity);
        Task UpdateAsync(T Entity);
        Task DeleteAsync(T Entity);
    }
}
