using AutoMapper;
using BookAservices.Application.Contract;
using BookAservices.Domain;
using MediatR;

namespace BookAservices.Application.Featcuer.OptionsDifferen
{
    public class GetOneOptionsDifference
    {
        public Guid Id { get; set; }
        public Guid DifferencesId { get; set; }
        public string? Address { get; set; }
        public ICollection<OptionsDifferencesData>? optionsDifferenceDatas { get; set; }
    }
    public class GetOneOptionsDifferenceQuerry : IRequest<GetOneOptionsDifference>
    {
        public Guid Id { get; set; }
    }
    public class GetOneOptionsDifferenceHandler : IRequestHandler<GetOneOptionsDifferenceQuerry, GetOneOptionsDifference>
    {
        private readonly IMapper mapper;
        private readonly IInterfaceOptionsDifference interfaceOptionsDifference;

        public GetOneOptionsDifferenceHandler(IMapper mapper , IInterfaceOptionsDifference interfaceOptionsDifference)
        {
            this.mapper = mapper;
            this.interfaceOptionsDifference = interfaceOptionsDifference;
        }
        public async Task<GetOneOptionsDifference> Handle(GetOneOptionsDifferenceQuerry request, CancellationToken cancellationToken)
        {
            var result = await interfaceOptionsDifference.GetOptionsDifferenceWithDetails(request.Id);
            var results = mapper.Map<GetOneOptionsDifference>(result);
            return results;
        }
    }
}
