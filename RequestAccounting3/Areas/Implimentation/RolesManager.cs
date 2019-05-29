using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestAccounting3.Areas.Implimentation
{
    using Microsoft.AspNetCore.Identity;

    using RequestAccounting3.Areas.Interfaces;
    using RequestAccounting3.Models;
    using RequestAccounting3.Models.Users;

    // Почему roles? чтобы отличаться от класса RoleManager из Identity 
    public class RolesManager : IRolesManager
    {
        RoleManager<IdentityRole> roleManager;
        UserManager<User> userManager;
        public IdentityResult identityResult { get; set; }

        public RolesManager(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task<bool> CreateAsync(string roleName)
        {
            this.identityResult = await Task.Run(() => this.roleManager.CreateAsync(new IdentityRole(roleName)));
            return this.identityResult.Succeeded;
        }      

        public async Task DeleteAsync(string roleId)
        {
            var role = await this.roleManager.FindByIdAsync(roleId);
            if (role != null)
            {
                this.identityResult = await this.roleManager.DeleteAsync(role);
            }
        }
        
        public async Task<IEnumerable<IdentityRole>> GetRolesAsync()
        {
           return await Task.Run(() => this.roleManager.Roles.ToList());
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await Task.Run(() => this.userManager.Users.ToList());
        }

        public async Task<ChangeRoleViewModel> GetUserRoles(string userId)
        {
            User user = await this.userManager.FindByIdAsync(userId);
            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await this.userManager.GetRolesAsync(user);
                var allRoles = this.roleManager.Roles.ToList();
                var model = new ChangeRoleViewModel
                                                {
                                                    UserId = user.Id,
                                                    UserName = user.UserName,
                                                    UserRoles = userRoles,
                                                    AllRoles = allRoles
                                                };
                return model;
            }

            return null;
        }

        public async Task<bool> UpdateUserRoles(string userId, List<string> roles)
        {
            User user = await this.userManager.FindByIdAsync(userId);
            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await this.userManager.GetRolesAsync(user);
                // получаем все роли
                //var allRoles = this.roleManager.Roles.ToList();
                // получаем список ролей, которые были добавлены
                var addedRoles = roles.Except(userRoles);
                // получаем роли, которые были удалены
                var removedRoles = userRoles.Except(roles);

                await this.userManager.AddToRolesAsync(user, addedRoles);

                await this.userManager.RemoveFromRolesAsync(user, removedRoles);
                
                return true;
            }

            return false;
        }
    }
}
