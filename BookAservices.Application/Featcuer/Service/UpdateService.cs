using AutoMapper;
using BookAservices.Application.Contract;
using BookAservices.Domain;
using MediatR;

namespace BookAservices.Application.Featcuer.Service
{

    public class UpdateServiceQuerry : IRequest
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
    }
    public class UpdateServiceHandler : IRequestHandler<UpdateServiceQuerry>
    {
        private readonly IMapper mapper;
        private readonly IInterfaceServices interfaceServices;

        public UpdateServiceHandler(IMapper mapper , IInterfaceServices interfaceServices)
        {
            this.mapper = mapper;
            this.interfaceServices = interfaceServices;
        }
     

        async Task<Unit> IRequestHandler<UpdateServiceQuerry, Unit>.Handle(UpdateServiceQuerry request, CancellationToken cancellationToken)
        {
            var result = mapper.Map<Services>(request);
            await interfaceServices.UpdateAsync(result);
            return Unit.Value;
        }
    }
}
