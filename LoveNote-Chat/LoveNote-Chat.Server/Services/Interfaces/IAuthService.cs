using Love_Note.UI.Server.Model.DTOs;
using LoveNote_Chat.Server.Model.DTOs;

namespace LoveNote_Chat.Server.Services.Interfaces
{
    public interface IAuthService
    {
        Task<Result<AppUserDto>> SignUp(SignUpRequestDto regRequestDto);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
        Task<bool> AssignRole(string email, string roleName);
    }
}
