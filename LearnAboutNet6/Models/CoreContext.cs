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
            string IdRole= "7af5f491-152e-4063-b721-0d91096d6f96";
            string IdUser= "9481ed98-2610-4d4d-9055-7a639d79a697";
            //SEED roles
            IdentityRole role = new IdentityRole
            {
                Id=IdRole,
                Name = "Admin",
                NormalizedName = "ADMIN",
            };

            builder.Entity<IdentityRole>().HasData(role);

            //SEED USER
            var hash = new PasswordHasher<IdentityUser>();
            IdentityUser user = new IdentityUser
            {

                Id = IdUser,
                UserName = "admin",
                PasswordHash = hash.HashPassword(null, "admin"),
                EmailConfirmed=true,
                NormalizedUserName="ADMIN"
            };
            builder.Entity<IdentityUser>().HasData(user);
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = IdRole,
                UserId = IdUser
            });


        }
        
    }
}
