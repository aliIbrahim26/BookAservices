using BookAservices.Application.Featcuer.Orders;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAservices.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("GetListOrder")]
        public async Task<ActionResult> GetListOrder()
        {
            var result = await mediator.Send(new GetListOrderQuerry());
            return Ok(result);
        }

        [HttpGet("GetOneOrder")]
        public async Task<ActionResult> GetOneOrder(Guid id)
        {
            var result = new GetOneOrderQuerry() { Id = id };
            return Ok(await mediator.Send(result));
        }

        [HttpPost("CreateOrder")]
        public async Task <ActionResult> CreateOrder([FromBody]CreateOrderQuerry createOrderQuerry) 
        {
            var result = await mediator.Send(createOrderQuerry);
            return Ok(result);
        }

        [HttpPut("UpdateOrder")]
        public async Task<ActionResult> UpdateOrder([FromBody] UpdateOrderQuerry updateOrderQuerry)
        {
            var result = await mediator.Send(updateOrderQuerry);
            return Ok(result);
        }

        [HttpDelete("DeleteOrder")]
        public async Task<ActionResult> DeleteOrder(Guid id)
        {
            var result = new DeleteOrderQuerry { Id = id };
            return Ok(await mediator.Send(result));
        }
    }
}
