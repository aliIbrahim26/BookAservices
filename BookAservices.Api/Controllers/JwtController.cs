using BookAservices.Api.Models;
using BookAservices.Api.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookAservices.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class JwtController : ControllerBase
    {
        private readonly IServiceAuthor _service;
        private readonly RoleManager<IdentityRole> _roleManager;


        public JwtController(IServiceAuthor service, RoleManager<IdentityRole> roleManager)
        {
            _service = service;
            _roleManager = roleManager;
        }
        [HttpPost("Rigster")]
        public async Task <ActionResult> RigsterAsync([FromBody]RigsterModel model)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            };
            var result = await _service.RigsterAsync(model);
            if (!result.IsAuthenticated)
            {
                return BadRequest(result.Message);

            }
            return Ok(result);
          
        }
        
        [HttpPost("SignIn")]
        public async Task<ActionResult> SignIn([FromBody] SignIn model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            };
            var result = await _service.SignInAsync(model);
            if (!result.IsAuthenticated)
            {
                return BadRequest(result.Message);

            }
            return Ok(result);

        }

        [HttpPost("addRole")]
        public async Task<ActionResult> AddRole([FromBody] AddRole model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            };
            var result = await _service.AddRoleAsync(model);
            if (!string.IsNullOrEmpty(result))
            {
                return BadRequest(model);

            }
            return Ok(result);

        }
        
        [HttpPost("addRoleInData")]
        public async Task<ActionResult> AddRoleINData([FromBody] string role)
        {
           
            if (!await _roleManager.RoleExistsAsync(role))
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(role));
                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }
                return Ok(new { Message = "Role Added successfully" });
            }
            return BadRequest("you already had this role");
        }

           

    }
    
}
