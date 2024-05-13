using AutoMapper;
using Love_Note.UI.Server.Model.DTOs;
using LoveNote_Chat.Server.Data;
using LoveNote_Chat.Server.Model;
using LoveNote_Chat.Server.Model.DTOs;
using LoveNote_Chat.Server.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LoveNote_Chat.Server.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly LoveNoteChatDbContext _context;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;


        public AccountController(LoveNoteChatDbContext context, IMapper mapper, IAuthService authService)
        {
            _context = context;
            _mapper = mapper;
            _authService = authService;
            
        }


        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp([FromBody] SignUpRequestDto model)
        {
            var registerResult = await _authService.SignUp(model);

            if (registerResult.IsFailure)
            {
                return BadRequest(ResponseObjectDto<object>.Failure(registerResult.Errors));
            }

            //Add Token to verify the email
            var user = _mapper.Map<AppUser>(registerResult.Data);
            //var appUrl = $"{Request.Scheme}://{Request.Host}";
            //var confirmEmailEndpoint = $"{appUrl}/confirmemail";
            //var confirmationEmailSent = await _authService.SendConfirmationEmailAsync2(user, confirmEmailEndpoint);
            return Ok(ResponseObjectDto<object>.Success(registerResult.Data));
        }
    }
}
