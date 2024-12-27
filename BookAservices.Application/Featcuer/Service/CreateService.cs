using AutoMapper;
using BookAservices.Application.Contract;
using BookAservices.Domain;
using MediatR;

namespace BookAservices.Application.Featcuer.Service
{
 
    public class CreateServiceQuery : IRequest<Guid>
    {
      
        public string? Name { get; set; }
        public double Price { get; set; }
    }
    public class CreateServiceHandler : IRequestHandler<CreateServiceQuery, Guid>
    {
        private readonly IMapper mapper;
        private readonly IInterfaceServices interfaceServices;

        public CreateServiceHandler(IMapper mapper , IInterfaceServices interfaceServices)
        {
            this.mapper = mapper;
            this.interfaceServices = interfaceServices;
        }
        public async Task<Guid> Handle(CreateServiceQuery request, CancellationToken cancellationToken)
        {
            var result = mapper.Map<Services>(request);
             await interfaceServices.AddAsync(result);
            return result.Id;
        }
    }
}
