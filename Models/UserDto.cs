//namespace JwtWebApiDotNet7.Models
//{
//    public class UserDto
//    {
//        public required string Username { get; set; }
//        public required string Password { get; set; }
//    }
//}
namespace JwtWebApiDotNet7.Models
{
    public class UserDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class LoginUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;
    }

    public class AuthUser
    {

        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;

    } 
    public class LoginUserDetail
    {

        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;


    }

    public class RegisterStud
    {

        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string ContactNo { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public string Branch { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public int? UserId { get; set; }
    }
}
