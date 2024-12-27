using AutoMapper;
using BookAservices.Application.Contract;
using MediatR;

namespace BookAservices.Application.Featcuer.OptionsDifferen
{
    public class GetListOptionsDifference
    {
        public Guid Id { get; set; }
        public Guid DifferencesId { get; set; }
        public string? Address { get; set; }
    }
    public class GetListOptionsDifferenceQuerry : IRequest<List<GetListOptionsDifference>>
    {

    }
    public class GetListOptionsDifferenceHandler : IRequestHandler<GetListOptionsDifferenceQuerry, List<GetListOptionsDifference>>
    {
        private readonly IMapper mapper;
        private readonly IInterfaceOptionsDifference interfaceOptionsDifference;

        public GetListOptionsDifferenceHandler(IMapper mapper , IInterfaceOptionsDifference interfaceOptionsDifference)
        {
            this.mapper = mapper;
            this.interfaceOptionsDifference = interfaceOptionsDifference;
        }
        public async Task<List<GetListOptionsDifference>> Handle(GetListOptionsDifferenceQuerry request, CancellationToken cancellationToken)
        {
            var result = await interfaceOptionsDifference.GetAllAsync();
            var results = mapper.Map<List<GetListOptionsDifference>>(result);
            return results;
        }
    }
}
