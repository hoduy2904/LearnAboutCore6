using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LearnAboutNet6.Models
{
    public class CoreContext : IdentityDbContext
    {
        public CoreContext(DbContextOptions<CoreContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //SEED roles
            IdentityRole role = new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "admin",
            };

            builder.Entity<IdentityRole>().HasData(role);

            //SEED USER
            var hash = new PasswordHasher<IdentityUser>();
            IdentityUser user = new IdentityUser
            {
                UserName = "admin",
            };
           hash.HashPassword(user, "admin");

            builder.Entity<IdentityUser>().HasData(user);

            
        }
        
    }
}
