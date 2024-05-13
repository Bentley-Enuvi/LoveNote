﻿using System.ComponentModel.DataAnnotations;

namespace LoveNote_Chat.Server.Model.DTOs
{
    public class LoginRequestDto
    {
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
