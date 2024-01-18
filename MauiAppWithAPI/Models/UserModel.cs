namespace MauiAppWithAPI.Models
{
    public class UserModel
    {
        public string EmailId { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponseModel
    {
        public int UserId { get; set; }
        public string? FullName { get; set; }
        public string? EmailId { get; set; }
        public string? Photo { get; set; }
        public string? JWTToken { get; set; }

    }
}
