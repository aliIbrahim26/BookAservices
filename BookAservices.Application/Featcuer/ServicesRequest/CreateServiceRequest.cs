using AutoMapper;
using BookAservices.Application.Contract;
using BookAservices.Domain;
using MediatR;

namespace BookAservices.Application.Featcuer.ServicesRequest
{
   
    public class CreateServiceRequestQuerry:IRequest<Guid>
    {
        
        public string? Name { get; set; }
        public int Phone { get; set; }
    }
    public class CreateServiceRequestHandler : IRequestHandler<CreateServiceRequestQuerry, Guid>
    {
        private readonly IMapper mapper;
        private readonly IInterfaceServiceRequest interfaceServiceRequest;

        public CreateServiceRequestHandler(IMapper mapper , IInterfaceServiceRequest interfaceServiceRequest)
        {
            this.mapper = mapper;
            this.interfaceServiceRequest = interfaceServiceRequest;
        }
        public async Task<Guid> Handle(CreateServiceRequestQuerry request, CancellationToken cancellationToken)
        {
            var result = mapper.Map<ServiceRequest>(request);
            await interfaceServiceRequest.AddAsync(result);
            return result.Id;
        }
    }
}
