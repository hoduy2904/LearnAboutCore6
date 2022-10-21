using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LearnAboutNet6.Areas.admin.Controllers
{
    public class RoleController : BaseController
    {
        private RoleManager<IdentityRole> roleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {

            var role = roleManager.Roles.AsEnumerable();
            return View(role);
        }

        public async Task<IActionResult> Edit(string Id)
        {
            var role = await roleManager.FindByIdAsync(Id);
            if (role != null)
                return View(role);
            return RedirectToAction(nameof(Index));
        }
        [HttpPut]
        public async Task<IActionResult> Edit(IdentityRole identityRole)
        {
            if (ModelState.IsValid)
            {
                var role = await roleManager.FindByIdAsync(identityRole.Id);
                if (role != null)
                {
                    var result = await roleManager.UpdateAsync(role);
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View(identityRole);
        }

        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(string Id)
        {
            var role = await roleManager.FindByIdAsync(Id);
            if (role != null)
                return View(role);
            return RedirectToAction(nameof(Index));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string Id)
        {
            var role = await roleManager.FindByIdAsync(Id);
            if (role != null)
            {
                var result = await roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(role);
        }
    }
}
