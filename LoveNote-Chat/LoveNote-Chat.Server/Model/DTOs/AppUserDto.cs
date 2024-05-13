namespace LoveNote_Chat.Server.Model.DTOs
{
    public class AppUserDto
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Id { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public IList<string> RoleName { get; set; }

    }
}
