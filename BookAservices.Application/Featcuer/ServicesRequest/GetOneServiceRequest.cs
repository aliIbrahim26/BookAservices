using AutoMapper;
using BookAservices.Application.Contract;
using MediatR;

namespace BookAservices.Application.Featcuer.ServicesRequest
{
    public class GetOneServiceRequest
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int Phone { get; set; }
    }
    public class GetOneServiceRequestQuerry : IRequest<GetOneServiceRequest>
    {
        public Guid Id { get; set; }
    }
    public class GetOneServiceRequestHandler : IRequestHandler<GetOneServiceRequestQuerry, GetOneServiceRequest>
    {
        private readonly IMapper mapper;
        private readonly IInterfaceServiceRequest interfaceServiceRequest;

        public GetOneServiceRequestHandler(IMapper mapper , IInterfaceServiceRequest interfaceServiceRequest)
        {
            this.mapper = mapper;
            this.interfaceServiceRequest = interfaceServiceRequest;
        }
        public async Task<GetOneServiceRequest> Handle(GetOneServiceRequestQuerry request, CancellationToken cancellationToken)
        {
            var result = await interfaceServiceRequest.GetByIdAsync(request.Id);
            var results = mapper.Map<GetOneServiceRequest>(result);
            return results;
        }
    }
}
