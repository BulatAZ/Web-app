// ReSharper disable StyleCop.SA1600
namespace RequestAccounting3.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using RequestAccounting3.Areas.Interfaces;
    using RequestAccounting3.Models;

    [Authorize(Roles = "admin")]
    public class RolesController : Controller
    {       
        private readonly IRolesManager rolesManager;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, IRolesManager rolesManager)
        {
          
            this.rolesManager = rolesManager;
        }

        public async Task<IActionResult> Index() => this.View(await this.rolesManager.GetRolesAsync());

        public IActionResult Create() => this.View();

        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var result = await this.rolesManager.CreateAsync(name);
                if (result)
                {
                    return this.RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in this.rolesManager.identityResult.Errors)
                    {
                        this.ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return this.View(name);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            await this.rolesManager.DeleteAsync(id);            
            return this.RedirectToAction("Index");
        }

        public async Task<IActionResult> UserList() => this.View(await this.rolesManager.GetUsersAsync());

        public async Task<IActionResult> Edit(string userId)
        {
            var result = await this.rolesManager.GetUserRoles(userId);
            if (result != null)
            {
                return this.View(result);
            }
            
            return this.NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string userId, List<string> roles)
        {
            var resultIsSuccessful = await this.rolesManager.UpdateUserRoles(userId, roles);           
            if (resultIsSuccessful)
            {              
                return this.RedirectToAction("UserList");
            }

            return this.NotFound();
        }
    }
}