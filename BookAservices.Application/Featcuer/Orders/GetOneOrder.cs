using AutoMapper;
using BookAservices.Application.Contract;
using BookAservices.Domain;
using MediatR;

namespace BookAservices.Application.Featcuer.Orders
{
    public class GetOneOrder
    {
        public Guid Id { get; set; }
        public Guid ServiceRequestId { get; set; }
        public double TotalAmount { get; set; }
        public string? Status { get; set; }
        public ICollection<OrderDetail>? OrderDetails { get; set; }

    }


    public class GetOneOrderQuerry : IRequest<GetOneOrder>
    {
        public Guid Id { get; set; }
    }

    public class GetOneOrderHandler : IRequestHandler<GetOneOrderQuerry, GetOneOrder>
    {
        private readonly IMapper mapper;
        private readonly IInterfaceOrder interfaceOrder;

        public GetOneOrderHandler(IMapper mapper, IInterfaceOrder interfaceOrder)
        {
            this.mapper = mapper;
            this.interfaceOrder = interfaceOrder;
        }
        public async Task<GetOneOrder> Handle(GetOneOrderQuerry request, CancellationToken cancellationToken)
        {
            var result = await interfaceOrder.GetOrderWithDetail(request.Id);
            var results = mapper.Map<GetOneOrder>(result);
            return results;
        }
    }
}
