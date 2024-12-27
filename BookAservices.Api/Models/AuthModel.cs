namespace BookAservices.Api.Models
{
    public class AuthModel
    {
        public string? Email { get; set; }
        public string? Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public DateTime Expired { get; set; }
        public List<string>? Roles { get; set; }
        public string? Token { get; set; }

    }
}
