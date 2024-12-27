using AutoMapper;
using BookAservices.Application.Contract;
using BookAservices.Domain;
using MediatR;

namespace BookAservices.Application.Featcuer.Orders
{

    public class UpdateOrderQuerry : IRequest
    {
        public Guid Id { get; set; }
        public Guid ServiceRequestId { get; set; }
        public double TotalAmount { get; set; }
        public string? Status { get; set; }
        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderQuerry>
    {
        private readonly IMapper mapper;
        private readonly IInterfaceOrder interfaceOrder;

        public UpdateOrderHandler(IMapper mapper, IInterfaceOrder interfaceOrder)
        {
            this.mapper = mapper;
            this.interfaceOrder = interfaceOrder;
        }
        public async Task<Unit> Handle(UpdateOrderQuerry request, CancellationToken cancellationToken)
        {
            var result = mapper.Map<Order>(request);
            await interfaceOrder.UpdateAsync(result);
            return Unit.Value;
        }
    }
}
