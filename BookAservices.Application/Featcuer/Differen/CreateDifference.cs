using AutoMapper;
using BookAservices.Application.Contract;
using BookAservices.Domain;
using MediatR;

namespace BookAservices.Application.Featcuer.Differen
{
    public class CreateDifferenceQuerry:IRequest<Guid>
    {
        public Guid Id { get; set; }
        public Guid TableId { get; set; }
        public string? Address { get; set; }
        public string? TypeData { get; set; }
        public ICollection<DifferencesData>? DifferenceDatas { get; set; }
    }

    public class DifferencesData
    {
        public Guid Id { get; set; }
        public Guid DifferencesId { get; set; }
        public Guid ServiceRequestId { get; set; }
        public string? Reply { get; set; }
    }
    public class CreateDifferenceHandler : IRequestHandler<CreateDifferenceQuerry, Guid>
    {
        private readonly IMapper mapper;
        private readonly IInterfaceDifferences interfaceDifferences;

        public CreateDifferenceHandler(IMapper mapper , IInterfaceDifferences interfaceDifferences)
        {
            this.mapper = mapper;
            this.interfaceDifferences = interfaceDifferences;
        }
        public async Task<Guid> Handle(CreateDifferenceQuerry request, CancellationToken cancellationToken)
        {
            var result = mapper.Map<Differences>(request);
            await interfaceDifferences.AddAsync(result);
            return result.Id;

        }
    }
}
