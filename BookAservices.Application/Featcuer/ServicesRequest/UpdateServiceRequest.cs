using AutoMapper;
using BookAservices.Application.Contract;
using BookAservices.Domain;
using MediatR;

namespace BookAservices.Application.Featcuer.ServicesRequest
{
  
    public class UpdateServiceRequestQuerry : IRequest
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int Phone { get; set; }
    }
    public class UpdateServiceRequestHandler : IRequestHandler<UpdateServiceRequestQuerry>
    {
        private readonly IMapper mapper;
        private readonly IInterfaceServiceRequest interfaceServiceRequest;

        public UpdateServiceRequestHandler(IMapper mapper , IInterfaceServiceRequest interfaceServiceRequest)
        {
            this.mapper = mapper;
            this.interfaceServiceRequest = interfaceServiceRequest;
        }
        public async Task<Unit> Handle(UpdateServiceRequestQuerry request, CancellationToken cancellationToken)
        {
           var result = mapper.Map<ServiceRequest>(request);
            await interfaceServiceRequest.UpdateAsync(result);
            return Unit.Value;
        }
    }
}
