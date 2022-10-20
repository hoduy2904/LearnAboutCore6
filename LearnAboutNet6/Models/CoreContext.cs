using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LearnAboutNet6.Models
{
    public class CoreContext : IdentityDbContext
    {
        public CoreContext(DbContextOptions<CoreContext> options):base(options)
        {

        }
    }
}
