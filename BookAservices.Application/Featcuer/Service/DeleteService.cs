using AutoMapper;
using BookAservices.Application.Contract;
using BookAservices.Domain;
using MediatR;

namespace BookAservices.Application.Featcuer.Service
{
 
    public class DeleteServiceQuerry : IRequest
    {
      public Guid Id { get; set; }
    }

    public class DeleteServiceHandler : IRequestHandler<DeleteServiceQuerry>
    {
        private readonly IMapper mapper;
        private readonly IInterfaceServices interfaceServices;

        public DeleteServiceHandler(IMapper mapper,IInterfaceServices interfaceServices)
        {
            this.mapper = mapper;
            this.interfaceServices = interfaceServices;
        }

        public async Task<Unit> Handle(DeleteServiceQuerry request, CancellationToken cancellationToken)
        {
            var result = mapper.Map<Services>(request);
            await interfaceServices.DeleteAsync(result);
            return Unit.Value;
        }
    }
}
