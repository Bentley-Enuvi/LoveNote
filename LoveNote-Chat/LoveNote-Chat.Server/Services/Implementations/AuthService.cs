using Love_Note.UI.Server.Model.DTOs;
using LoveNote_Chat.Server.Data;
using LoveNote_Chat.Server.Model;
using LoveNote_Chat.Server.Model.DTOs;
using LoveNote_Chat.Server.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using System.Text;

namespace LoveNote_Chat.Server.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly LoveNoteChatDbContext _context;
        private readonly UserManager<AppUser> _userManager;


        public AuthService(LoveNoteChatDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public async Task<Result<AppUserDto>> SignUp(SignUpRequestDto signUpDto)
        {
            using var hmac = new HMACSHA512();

            AppUser user = new()
            {
                FullName = signUpDto.FullName,
                Email = signUpDto.Email,
                Age = signUpDto.Age,
                NormalizedEmail = signUpDto.Email.ToUpper(),
                Password = signUpDto.Password,
                Gender = signUpDto.Gender,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(signUpDto.Password)),
                PasswordSalt = hmac.Key
            };

            var result = await _userManager.CreateAsync(user, signUpDto.Password);

            if (!result.Succeeded)
                return Result.Failure<AppUserDto>(result.Errors.Select(e => new Error(e.Code, e.Description)));

            var userToReturn = _context.Users.First(u => u.UserName == signUpDto.Email);
            var roles = await _userManager.GetRolesAsync(userToReturn);

            AppUserDto userDto = new()
            {
                FullName = signUpDto.FullName,
                UserName = signUpDto.Email,
                Email = signUpDto.Email,
                Age = signUpDto.Age,
                Password = signUpDto.Password,
                Gender = signUpDto.Gender,
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Result.Success(userDto);
        }


        public Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            throw new NotImplementedException();
        }



        public Task<bool> AssignRole(string email, string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
