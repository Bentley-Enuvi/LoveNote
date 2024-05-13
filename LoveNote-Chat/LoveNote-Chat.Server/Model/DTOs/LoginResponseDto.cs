namespace LoveNote_Chat.Server.Model.DTOs
{
    public class LoginResponseDto
    {
        public AppUserDto User { get; set; }
        public string Token { get; set; }
    }
}
