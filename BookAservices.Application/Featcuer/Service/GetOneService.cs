using AutoMapper;
using BookAservices.Application.Contract;
using MediatR;

namespace BookAservices.Application.Featcuer.Service
{
    public class GetOneService
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
    }
    public class GetOneServiceQuerry : IRequest<GetOneService>
    {
        public Guid Id { get; set; }
    }

    public class GetOneServiceHandler : IRequestHandler<GetOneServiceQuerry, GetOneService>
    {
        private readonly IMapper mapper;
        private readonly IInterfaceServices interfaceServices;

        public GetOneServiceHandler(IMapper mapper , IInterfaceServices interfaceServices)
        {
            this.mapper = mapper;
            this.interfaceServices = interfaceServices;
        }
        public async Task<GetOneService> Handle(GetOneServiceQuerry request, CancellationToken cancellationToken)
        {
            var result = await interfaceServices.GetByIdAsync(request.Id);
            var results = mapper.Map<GetOneService>(result);
            return results;
        }
    }
}
