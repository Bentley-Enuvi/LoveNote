using Microsoft.AspNetCore.Identity;

namespace LoveNote_Chat.Server.Model
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }
}
