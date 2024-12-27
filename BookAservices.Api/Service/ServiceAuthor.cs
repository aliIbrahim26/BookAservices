using BookAservices.Api.Helper;
using BookAservices.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookAservices.Api.Service
{
    public class ServiceAuthor : IServiceAuthor
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JWT _jwt;



        public ServiceAuthor(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<JWT> jwt)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwt = jwt.Value;

        }

        public async Task<AuthModel> RigsterAsync(RigsterModel model)
        {


            if (await _userManager.FindByEmailAsync(model.Email) is not null)
            {
                return new AuthModel { Message = "this email already rigstered!" };
            }
            if (await _userManager.FindByNameAsync(model.UserName) is not null)
            {
                return new AuthModel { Message = "this user already rigstered!" };
            }
            ApplicationUser user = new ApplicationUser
            {
                Email = model.Email,
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,

            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                var Error = string.Empty;
                foreach (var error in result.Errors)
                {
                    Error += error.Description;
                }
                return new AuthModel { Message = Error };
            }
            await _userManager.AddToRoleAsync(user, "User");
            var jwt = await CreateToken(user);
            return new AuthModel {
                Email = model.Email,
                Expired = jwt.ValidTo,
                IsAuthenticated = true,
                Roles = new List<string> { "User" },
                Token = new JwtSecurityTokenHandler().WriteToken(jwt)

            };
        }

        public async Task<JwtSecurityToken> CreateToken(ApplicationUser user)
        {
            var Role = await _userManager.GetRolesAsync(user);
            var claims = await _userManager.GetClaimsAsync(user);
            var roleclaims = new List<Claim>();
            foreach (var roles in Role)
            {
                roleclaims.Add(new Claim("role", roles));
            }

            var claim = new[]
            {
             new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
             new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
             new Claim(JwtRegisteredClaimNames.Email,user.Email),
             new Claim("uid",user.Id),
            }
            .Union(roleclaims)
            .Union(claims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            //help
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            //
            var jwtSecurityToken = new JwtSecurityToken
                 (
                   issuer: _jwt.Issuer,
                   audience: _jwt.Audience,
                   claims: claim,
                   expires: DateTime.Now.AddDays(_jwt.DurationOfDays),
                   signingCredentials: signingCredentials
                 );
            return jwtSecurityToken;
        }

        public async Task<AuthModel> SignInAsync(SignIn model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                return new AuthModel { Message = "your email or password is wrong" };

            }
            var role = await _userManager.GetRolesAsync(user);
            var jwt = await CreateToken(user);
            return new AuthModel
            {
                Email = model.Email,
                IsAuthenticated = true,
                Roles = role.ToList(),
                Token = new JwtSecurityTokenHandler().WriteToken(jwt)
            };
        }
        public async Task<string> AddRoleAsync(AddRole model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user is null ||!await _roleManager.RoleExistsAsync(model.RoleName)) 
            {
                return "some thing wrong";
            }
            if (await _userManager.IsInRoleAsync(user, model.RoleName))
            {
                return "you already in this role";
            }
         
          var result = await _userManager.AddToRoleAsync(user, model.RoleName);
            if (!result.Succeeded)
            {
                return "not succed";
            }
            return string.Empty;
        }

        
           

    }
}
