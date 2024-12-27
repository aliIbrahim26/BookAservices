using AutoMapper;
using BookAservices.Application.Contract;
using BookAservices.Domain;
using MediatR;

namespace BookAservices.Application.Featcuer.Orders
{


    public class CreateOrderQuerry : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public Guid ServiceRequestId { get; set; }
        public double TotalAmount { get; set; }
        public string? Status { get; set; }
        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }

    public class OrderDetail
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ServiceId { get; set; }
    }

    public class CreateOrderHandler : IRequestHandler<CreateOrderQuerry, Guid>
    {
        private readonly IMapper mapper;
        private readonly IInterfaceOrder interfaceOrder;

        public CreateOrderHandler(IMapper mapper, IInterfaceOrder interfaceOrder)
        {
            this.mapper = mapper;
            this.interfaceOrder = interfaceOrder;
        }
        public async Task<Guid> Handle(CreateOrderQuerry request, CancellationToken cancellationToken)
        {
            var result = mapper.Map<Order>(request);

            await interfaceOrder.AddAsync(result);
            return result.Id;
        }
    }
}
