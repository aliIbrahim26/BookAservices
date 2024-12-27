using BookAservices.Domain;

namespace BookAservices.Application.Contract
{
    public interface IInterfaceOrder:IGenricInterface<Order>
    {
        Task<Order> GetOrderWithDetail(Guid id);
    }
}
