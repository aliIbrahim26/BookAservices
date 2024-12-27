using AutoMapper;
using BookAservices.Application.Contract;
using BookAservices.Domain;
using MediatR;

namespace BookAservices.Application.Featcuer.OptionsDifferen
{
    public class DeleteOptionsDifferenceQuerry:IRequest
    {
        public Guid Id { get; set; }
    }
    public class DeleteOptionsDifferenceHandler : IRequestHandler<DeleteOptionsDifferenceQuerry>
    {
        private readonly IMapper mapper;
        private readonly IInterfaceOptionsDifference interfaceOptionsDifference;

        public DeleteOptionsDifferenceHandler(IMapper mapper , IInterfaceOptionsDifference interfaceOptionsDifference)
        {
            this.mapper = mapper;
            this.interfaceOptionsDifference = interfaceOptionsDifference;
        }
        public async Task<Unit> Handle(DeleteOptionsDifferenceQuerry request, CancellationToken cancellationToken)
        {
            var result = mapper.Map<OptionsDifference>(request);
            await interfaceOptionsDifference.DeleteAsync(result);
            return Unit.Value;
        }
    }
}
