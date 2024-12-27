using AutoMapper;
using BookAservices.Application.Contract;
using BookAservices.Domain;
using MediatR;

namespace BookAservices.Application.Featcuer.ServicesRequest
{
    public class GetListServiceRequest
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int Phone { get; set; }
    }
    public class GetListServiceRequestQuerry : IRequest<List<GetListServiceRequest>>
    {

    }
    public class GetListServiceRequestHandler : IRequestHandler<GetListServiceRequestQuerry, List<GetListServiceRequest>>
    {
        private readonly IMapper mapper;
        private readonly IInterfaceServiceRequest interfaceServiceRequest;

        public GetListServiceRequestHandler(IMapper mapper , IInterfaceServiceRequest interfaceServiceRequest)
        {
            this.mapper = mapper;
            this.interfaceServiceRequest = interfaceServiceRequest;
        }

        public async Task<List<GetListServiceRequest>> Handle(GetListServiceRequestQuerry request, CancellationToken cancellationToken)
        {
            var result = await interfaceServiceRequest.GetAllAsync();
            var results = mapper.Map<List<GetListServiceRequest>>(result);
            return results;
        }
    }
}
