using AutoMapper;
using BookAservices.Application.Contract;
using BookAservices.Domain;
using FluentValidation;
using MediatR;

namespace BookAservices.Application.Featcuer.Differen
{
    public class CreateDifferenceQuerry:IRequest<DifferencesDataResult>
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

    public class DifferencesDataResult
    {
        public Guid Id { get; set; }
        public string? message { get; set; }
        public bool? success { get; set; }
    }

    public class Validated : AbstractValidator<CreateDifferenceQuerry>
    {
        public Validated()
        {
            RuleFor(x => x.Address).NotEmpty();
        }
    }
    public class CreateDifferenceHandler : IRequestHandler<CreateDifferenceQuerry, DifferencesDataResult>
    {
        private readonly IMapper mapper;
        private readonly IInterfaceDifferences interfaceDifferences;

        public CreateDifferenceHandler(IMapper mapper , IInterfaceDifferences interfaceDifferences)
        {
            this.mapper = mapper;
            this.interfaceDifferences = interfaceDifferences;
        }

       
        public async Task<DifferencesDataResult> Handle(CreateDifferenceQuerry request, CancellationToken cancellationToken)
        {
            try
            {
                var result = mapper.Map<Differences>(request);
                Validated va = new Validated();
                var max = va.Validate(request);
                if (max.Errors.Any()) 
                {
                    return new DifferencesDataResult { message = string.Join(',', max.Errors), success = false };
                }
                await interfaceDifferences.AddAsync(result);
                return new DifferencesDataResult { Id = result.Id, success = true };
            }
             
            catch (Exception Ex)
            {

               return new DifferencesDataResult { success = false , message = Ex.Message };
            }
           

        }
    }
}
