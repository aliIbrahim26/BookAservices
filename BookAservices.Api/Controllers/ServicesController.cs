using BookAservices.Application.Featcuer.Service;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAservices.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IMediator mediator;

        public ServicesController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("GetList")]
        public async Task <ActionResult> GetAll()
        {
            var result = await mediator.Send(new GetListServiceQuerry());
            return Ok(result);

        }
        [HttpGet("GetOne")]
        public async Task<ActionResult> GetOne(Guid id)
        { 
        var result = new GetOneServiceQuerry() { Id = id };
            return Ok(await mediator.Send(result));
        }

        [HttpPost("CreateService")]
        public async Task<ActionResult> CreateService([FromBody]CreateServiceQuery createServiceQuery)
        {
            var result = await mediator.Send(createServiceQuery);
            return Ok(result);
        }

        [HttpPut("UpdateService")]
        public async Task<ActionResult> UpdateService([FromBody] UpdateServiceQuerry updateServiceQuerry)
        {
            var result = await mediator.Send(updateServiceQuerry);
            return Ok(result);
        }

        [HttpDelete("DeleteService")]
        public async Task<ActionResult> DeleteService(Guid id)
        {
            var result = new DeleteServiceQuerry() { Id = id };
            return Ok(await mediator.Send(result));
        }
    }
}
