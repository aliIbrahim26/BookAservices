using BookAservices.Api.Models;

namespace BookAservices.Api.Service
{
    public interface IServiceAuthor
    {
        Task <AuthModel> RigsterAsync (RigsterModel model);
        Task<AuthModel> SignInAsync(SignIn model);
        Task<string> AddRoleAsync(AddRole model);
    }
}
