using AutoMapper;
using BookAservices.Application.Contract;
using BookAservices.Domain;
using MediatR;

namespace BookAservices.Application.Featcuer.OptionsDifferen
{
    public class CreateOptionsDifferenceQuerry:IRequest<Guid>
    {
        public Guid Id { get; set; }
        public Guid DifferencesId { get; set; }
        public string? Address { get; set; }
        public ICollection<OptionsDifferencesData>? optionsDifferenceDatas { get; set; }
    }

    public class OptionsDifferencesData
    {
        public Guid Id { get; set; }
        public Guid DifferenceDataId { get; set; }
        public Guid OptionsDifferenceId { get; set; }

      
    }
    public class CreateOptionsDifferenceHandler : IRequestHandler<CreateOptionsDifferenceQuerry, Guid>
    {
        private readonly IMapper mapper;
        private readonly IInterfaceOptionsDifference interfaceOptionsDifference;

        public CreateOptionsDifferenceHandler(IMapper mapper , IInterfaceOptionsDifference interfaceOptionsDifference)
        {
            this.mapper = mapper;
            this.interfaceOptionsDifference = interfaceOptionsDifference;
        }
        public async Task<Guid> Handle(CreateOptionsDifferenceQuerry request, CancellationToken cancellationToken)
        {
            var result = mapper.Map<OptionsDifference>(request);
            await interfaceOptionsDifference.AddAsync(result);
            return result.Id;
        }
    }
}
