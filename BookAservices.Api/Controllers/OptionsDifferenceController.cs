using BookAservices.Application.Featcuer.OptionsDifferen;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookAservices.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionsDifferenceController : ControllerBase
    {
        private readonly IMediator mediator;

        public OptionsDifferenceController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("GetOneOptionsDifference")]
        public async Task<ActionResult> GetOneOptionsDifference(Guid id)
        {
            var result = new GetOneOptionsDifferenceQuerry() { Id = id };
            return Ok(await mediator.Send(result));
        }

        [HttpGet("GetList")]
        public async Task<ActionResult> GetList()
        {
            var result = await mediator.Send(new GetListOptionsDifferenceQuerry());
            return Ok(result);
        }

        [HttpPost("CreateOptionsDifference")]
        public async Task <ActionResult> CreateOptionsDifference([FromBody]CreateOptionsDifferenceQuerry createOptionsDifferenceQuerry)
        {
            var result = await mediator.Send(createOptionsDifferenceQuerry);
            return Ok(result);
        }
        [HttpPut("UpdateOptionsDifference")]
        public async Task<ActionResult> UpdateOptionsDifference([FromBody]UpdateOptionsDifferenceQuerry updateOptionsDifferenceQuerry)
        {
            var result = await mediator.Send(updateOptionsDifferenceQuerry);
            return Ok(result);
        }

        [HttpDelete("DeleteOptionsDifference")]
        public async Task<ActionResult> DeleteOptionsDifference(Guid id)
        {
            var result = new DeleteOptionsDifferenceQuerry { Id = id };
            return Ok(await mediator.Send(result));
        }
    }
}
