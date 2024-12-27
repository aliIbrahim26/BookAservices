using AutoMapper;
using BookAservices.Application.Contract;
using MediatR;

namespace BookAservices.Application.Featcuer.Service
{
    public class GetListService
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
    }   
        public class GetListServiceQuerry : IRequest<List<GetListService>>
        {

        }
        public class GetListServiceHandler : IRequestHandler<GetListServiceQuerry, List<GetListService>>
        {
            private readonly IMapper mapper;
            private readonly IInterfaceServices interfaceServices;

            public GetListServiceHandler(IMapper mapper, IInterfaceServices interfaceServices)
            {
                this.mapper = mapper;
                this.interfaceServices = interfaceServices;
            }
            public async Task<List<GetListService>> Handle(GetListServiceQuerry request, CancellationToken cancellationToken)
            {
                var result = await interfaceServices.GetAllAsync();
                var results = mapper.Map<List<GetListService>>(result);
                return results;

            }
        }
    }




