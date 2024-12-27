using AutoMapper;
using BookAservices.Application.Contract;
using MediatR;

namespace BookAservices.Application.Featcuer.Differen
{
    public class GetListDifference
    {
        public Guid Id { get; set; }
        public Guid TableId { get; set; }
        public string? Address { get; set; }
        public string? TypeData { get; set; }
       
    }

    public class GetListDifferenceQuerry : IRequest<List<GetListDifference>>
    {

    }
    public class GetListDifferenceHandler : IRequestHandler<GetListDifferenceQuerry, List<GetListDifference>>
    {
        private readonly IMapper mapper;
        private readonly IInterfaceDifferences interfaceDifferences;

        public GetListDifferenceHandler(IMapper mapper , IInterfaceDifferences interfaceDifferences)
        {
            this.mapper = mapper;
            this.interfaceDifferences = interfaceDifferences;
        }
        public async Task<List<GetListDifference>> Handle(GetListDifferenceQuerry request, CancellationToken cancellationToken)
        {
            var result = await interfaceDifferences.GetAllAsync();
            var results = mapper.Map<List<GetListDifference>>(result);
            return results;
        }
    }
}
