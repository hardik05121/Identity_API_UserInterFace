using HelpingHands_API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HelpingHands_API.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole,string>
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

		public DbSet<ApplicationUser> ApplicationUsers { get; set; }
		public DbSet<ApplicationRole> ApplicationRoles { get; set; }
		public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }
		
    }
}
