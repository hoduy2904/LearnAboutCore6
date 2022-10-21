using LearnAboutNet6.Areas.admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearnAboutNet6.Areas.admin.Controllers
{
    public class UserController : BaseController
    {
        private UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public UserController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var users = userManager.Users.AsEnumerable();
            return View(users);
        }

        public async Task<IActionResult> Edit(string Id)
        {
            var user=await userManager.FindByIdAsync(Id);
            if (user != null)
            {
                var userRoles = new List<UserRole>();

                var roles = await roleManager.Roles.ToListAsync();
                foreach (var item in roles)
                {
                    UserRole userRole = new UserRole
                    {
                        Id = item.Id,
                        ConcurrencyStamp = item.ConcurrencyStamp,
                        Name = item.Name,
                        NormalizedName = item.Name,
                        UserId = user.Id
                    };
                    if (await userManager.IsInRoleAsync(user, item.Name))
                    {
                        userRole.isChoose = true;
                    }
                    else
                    {
                        userRole.isChoose = false;
                    }
                    userRoles.Add(userRole);
                }

                return View(new UserViewModel
                {
                    IdentityUser = user,
                    UserRoles = userRoles
                });
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(IdentityUser identityUser, string[] roles)
        {
            var user = await userManager.FindByIdAsync(identityUser.Id);
            user.PhoneNumber=identityUser.PhoneNumber;
            user.PhoneNumberConfirmed = identityUser.PhoneNumberConfirmed;
            user.EmailConfirmed = identityUser.EmailConfirmed;
            user.Email = identityUser.Email;

           var result= await userManager.UpdateAsync(user);

            await userManager.AddToRolesAsync(user, roles);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Edit), new {Id=identityUser.Id});
        }

        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(string Id)
        {
            var user = await userManager.FindByIdAsync(Id);
            if (user != null)
                return View(user);
            return RedirectToAction(nameof(Index));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string Id)
        {
            var user = await userManager.FindByIdAsync(Id);
            if (user != null)
            {
              var result=  await userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(user);
        }
    }
}
