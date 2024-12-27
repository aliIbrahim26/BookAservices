using BookAservices.Application.Featcuer.Differen;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookAservices.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DifferenceController : ControllerBase
    {
        private readonly IMediator mediator;

        public DifferenceController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("GetListDifference")]
        public async Task<ActionResult> GetList()
        {
            var result = await mediator.Send(new GetListDifferenceQuerry());
            return Ok(result);
        }

        [HttpGet("GetOneDifference")]
        public async Task<ActionResult> GetOneDifference(Guid id)
        {
            var result = new GetOneDifferenceQuerry() { Id = id };
            return Ok(await mediator.Send(result));
        }

        [HttpPost("CreateDifference")]
        public async Task <ActionResult> CreateDifference([FromBody]CreateDifferenceQuerry createDifferenceQuerry)
        {
            var result = await mediator.Send(createDifferenceQuerry);
            return Ok(result);
        }

        [HttpPut("UpdateDifference")]
        public async Task<ActionResult> UpdateDifference([FromBody] UpdateDifferenceQuerry updateDifferenceQuerry)
        {
            var result = await mediator.Send(updateDifferenceQuerry);
            return Ok(result);
        }

        [HttpDelete("DeleteDifference")]
        public async Task<ActionResult> DeleteDifference(Guid id)
        {
            var result = new DeleteDifferenceQuerry { Id = id };
            return Ok(await mediator.Send(result));
        }
    }
}
