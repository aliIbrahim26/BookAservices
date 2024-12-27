using AutoMapper;
using BookAservices.Application.Contract;
using BookAservices.Domain;
using MediatR;

namespace BookAservices.Application.Featcuer.Differen
{
    public class UpdateDifferenceQuerry:IRequest
    {
        public Guid Id { get; set; }
        public Guid TableId { get; set; }
        public string? Address { get; set; }
        public string? TypeData { get; set; }
        public ICollection<DifferencesData>? DifferenceDatas { get; set; }
    }

    public class UpdateDifferenceHandler : IRequestHandler<UpdateDifferenceQuerry>
    {
        private readonly IMapper mapper;
        private readonly IInterfaceDifferences interfaceDifferences;

        public UpdateDifferenceHandler(IMapper mapper , IInterfaceDifferences interfaceDifferences)
        {
            this.mapper = mapper;
            this.interfaceDifferences = interfaceDifferences;
        }
        public async Task<Unit> Handle(UpdateDifferenceQuerry request, CancellationToken cancellationToken)
        {
            var result = mapper.Map<Differences>(request);
            await interfaceDifferences.UpdateAsync(result);
            return Unit.Value;
        }
    }
}
