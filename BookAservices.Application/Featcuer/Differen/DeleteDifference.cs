using AutoMapper;
using BookAservices.Application.Contract;
using BookAservices.Domain;
using MediatR;

namespace BookAservices.Application.Featcuer.Differen
{
    public class DeleteDifferenceQuerry:IRequest
    {
        public Guid Id { get; set; }
    }
    public class DeleteDifferenceHandler : IRequestHandler<DeleteDifferenceQuerry>
    {
        private readonly IMapper mapper;
        private readonly IInterfaceDifferences interfaceDifferences;

        public DeleteDifferenceHandler(IMapper mapper , IInterfaceDifferences interfaceDifferences)
        {
            this.mapper = mapper;
            this.interfaceDifferences = interfaceDifferences;
        }
        public async Task<Unit> Handle(DeleteDifferenceQuerry request, CancellationToken cancellationToken)
        {
            var result = mapper.Map<Differences>(request);
            await interfaceDifferences.DeleteAsync(result);
            return Unit.Value;
        }
    }
}
