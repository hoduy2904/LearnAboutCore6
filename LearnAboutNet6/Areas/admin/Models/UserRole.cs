using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnAboutNet6.Areas.admin.Models
{
    [NotMapped]
    public class UserRole : IdentityRole
    {
        public bool isChoose { get; set; }
        public string UserId { get; set; }
    }
}
