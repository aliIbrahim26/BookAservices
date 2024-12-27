using AutoMapper;
using BookAservices.Application.Contract;
using BookAservices.Domain;
using MediatR;

namespace BookAservices.Application.Featcuer.Orders
{

    public class DeleteOrderQuerry : IRequest
    {
        public Guid Id { get; set; }
    }
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderQuerry>
    {
        private readonly IMapper mapper;
        private readonly IInterfaceOrder interfaceOrder;

        public DeleteOrderHandler(IMapper mapper, IInterfaceOrder interfaceOrder)
        {
            this.mapper = mapper;
            this.interfaceOrder = interfaceOrder;
        }
        public async Task<Unit> Handle(DeleteOrderQuerry request, CancellationToken cancellationToken)
        {
            var result = mapper.Map<Order>(request);
            await interfaceOrder.DeleteAsync(result);
            return Unit.Value;
        }
    }
}
