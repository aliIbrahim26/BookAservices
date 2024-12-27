using AutoMapper;
using BookAservices.Application.Contract;
using BookAservices.Domain;
using MediatR;

namespace BookAservices.Application.Featcuer.Differen
{
    public class GetOneDifference
    {
        public Guid Id { get; set; }
        public Guid TableId { get; set; }
        public string? Address { get; set; }
        public string? TypeData { get; set; }
        public ICollection<DifferenceDatas>? DifferenceDatas { get; set; }
    }

    public class DifferenceDatas
    {

        public Guid Id { get; set; }
        public Guid DifferencesId { get; set; }
        public Guid ServiceRequestId { get; set; }
        public string? Reply { get; set; }
    }
    public class GetOneDifferenceQuerry : IRequest<GetOneDifference>
    {
        public Guid Id { get; set; }
    }
    public class GetOneDifferenceHandler : IRequestHandler<GetOneDifferenceQuerry, GetOneDifference>
    {
        private readonly IMapper mapper;
        private readonly IInterfaceDifferences interfaceDifferences;

        public GetOneDifferenceHandler(IMapper mapper , IInterfaceDifferences interfaceDifferences)
        {
            this.mapper = mapper;
            this.interfaceDifferences = interfaceDifferences;
        }
        public async Task<GetOneDifference> Handle(GetOneDifferenceQuerry request, CancellationToken cancellationToken)
        {
            var result = await interfaceDifferences.GetDifferencesWithDifferencesData(request.Id);
            var results = mapper.Map<GetOneDifference>(result);
            return results;
        }
    }
}
