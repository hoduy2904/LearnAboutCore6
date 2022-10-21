using Microsoft.AspNetCore.Identity;

namespace LearnAboutNet6.Areas.admin.Models
{
    public class UserViewModel
    {
       public IdentityUser IdentityUser { get; set; }
        public List<UserRole>? UserRoles { get; set; }
    }
}
