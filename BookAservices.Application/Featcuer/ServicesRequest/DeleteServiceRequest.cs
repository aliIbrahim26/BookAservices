using AutoMapper;
using BookAservices.Application.Contract;
using BookAservices.Domain;
using MediatR;

namespace BookAservices.Application.Featcuer.ServicesRequest
{
    public class DeleteServiceRequestQuerry:IRequest
    {
        public Guid Id { get; set; }
    }
    public class DeleteServiceRequestHandler : IRequestHandler<DeleteServiceRequestQuerry>
    {
        private readonly IMapper mapper;
        private readonly IInterfaceServiceRequest interfaceServiceRequest;

        public DeleteServiceRequestHandler(IMapper mapper , IInterfaceServiceRequest interfaceServiceRequest)
        {
            this.mapper = mapper;
            this.interfaceServiceRequest = interfaceServiceRequest;
        }
        public async Task<Unit> Handle(DeleteServiceRequestQuerry request, CancellationToken cancellationToken)
        {
           var result = mapper.Map<ServiceRequest>(request);
           await interfaceServiceRequest.DeleteAsync(result);
            return Unit.Value;
        }
    }
}
