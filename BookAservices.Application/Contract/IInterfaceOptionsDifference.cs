using BookAservices.Domain;

namespace BookAservices.Application.Contract
{
    public interface IInterfaceOptionsDifference:IGenricInterface<OptionsDifference>
    {
        Task<OptionsDifference> GetOptionsDifferenceWithDetails(Guid id);
    }
}
