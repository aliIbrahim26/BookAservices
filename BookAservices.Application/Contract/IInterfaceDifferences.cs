using BookAservices.Domain;

namespace BookAservices.Application.Contract
{
    public interface IInterfaceDifferences:IGenricInterface<Differences>
    {
        Task<Differences> GetDifferencesWithDifferencesData(Guid id);
    }
}
