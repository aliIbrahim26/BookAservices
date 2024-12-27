using AutoMapper;
using BookAservices.Application.Contract;
using MediatR;

namespace BookAservices.Application.Featcuer.Orders
{
    public class GetListOrder
    {
        public Guid Id { get; set; }
        public Guid ServiceRequestId { get; set; }
        public double TotalAmount { get; set; }
        public string? Status { get; set; }

    }
    public class GetListOrderQuerry : IRequest<List<GetListOrder>>
    {

    }
    public class GetListOrderHandler : IRequestHandler<GetListOrderQuerry, List<GetListOrder>>
    {
        private readonly IMapper mapper;
        private readonly IInterfaceOrder interfaceOrder;

        public GetListOrderHandler(IMapper mapper, IInterfaceOrder interfaceOrder)
        {
            this.mapper = mapper;
            this.interfaceOrder = interfaceOrder;
        }
        public async Task<List<GetListOrder>> Handle(GetListOrderQuerry request, CancellationToken cancellationToken)
        {
            var result = await interfaceOrder.GetAllAsync();
            var results = mapper.Map<List<GetListOrder>>(result);
            return results;
        }
    }
}
