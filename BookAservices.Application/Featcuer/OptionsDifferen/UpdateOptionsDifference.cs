using AutoMapper;
using BookAservices.Application.Contract;
using BookAservices.Domain;
using MediatR;

namespace BookAservices.Application.Featcuer.OptionsDifferen
{
    public class UpdateOptionsDifferenceQuerry:IRequest
    {
        public Guid Id { get; set; }
        public Guid DifferencesId { get; set; }
        public string? Address { get; set; }
        public ICollection<OptionsDifferencesData>? optionsDifferenceDatas { get; set; }
    }
    public class UpdateOptionsDifferenceHandler : IRequestHandler<UpdateOptionsDifferenceQuerry>
    {
        private readonly IMapper mapper;
        private readonly IInterfaceOptionsDifference interfaceOptionsDifference;

        public UpdateOptionsDifferenceHandler(IMapper mapper , IInterfaceOptionsDifference interfaceOptionsDifference)
        {
            this.mapper = mapper;
            this.interfaceOptionsDifference = interfaceOptionsDifference;
        }
        public async Task<Unit> Handle(UpdateOptionsDifferenceQuerry request, CancellationToken cancellationToken)
        {
            var result = mapper.Map<OptionsDifference>(request);
            await interfaceOptionsDifference.UpdateAsync(result);
            return Unit.Value;
        }
    }
}
