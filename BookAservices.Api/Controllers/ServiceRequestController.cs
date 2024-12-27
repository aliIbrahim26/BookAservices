using BookAservices.Application.Featcuer.ServicesRequest;
using MediatR;
using MediatR.Registration;
using Microsoft.AspNetCore.Mvc;

namespace BookAservices.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceRequestController : ControllerBase
    {
        private readonly IMediator mediator;

        public ServiceRequestController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("GetListServiceRequest")]
        public async Task <ActionResult> GetAll()
        {
            var result = await mediator.Send(new GetListServiceRequestQuerry());
            return Ok(result);
        }

        [HttpGet("GetOneServiceRequest")]
        public async Task<ActionResult> GetOne(Guid id) 
        { 
        var result = new GetOneServiceRequestQuerry() { Id = id};
            return Ok(await mediator.Send(result));
        
        }

        [HttpPost("CreateServiceRequest")]
        public async Task<ActionResult> CreateServiceRequest([FromBody]CreateServiceRequestQuerry createServiceRequestQuerry)
        {
            var result = await mediator.Send(createServiceRequestQuerry);
            return Ok(result);
        }

        [HttpPut("UpdateServiceRequest")]
        public async Task<ActionResult> UpdateServiceRequest([FromBody] UpdateServiceRequestQuerry updateServiceRequestQuerry)
        {
            var result = await mediator.Send(updateServiceRequestQuerry);
            return Ok(result);
        }

        [HttpDelete("DeleteServiceRequest")]
        public async Task<ActionResult> DeleteServiceRequest(Guid id )
        {
            var result = new DeleteServiceRequestQuerry() { Id=id };
            return Ok(await mediator.Send(result));
        }
    }
}
