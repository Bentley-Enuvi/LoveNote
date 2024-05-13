using LoveNote_Chat.Server.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LoveNote_Chat.Server.Data
{
    public class LoveNoteChatDbContext : IdentityDbContext<IdentityUser>
    {
        public LoveNoteChatDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
    }
}
