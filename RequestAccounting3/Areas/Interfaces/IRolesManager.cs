namespace RequestAccounting3.Areas.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;

    using RequestAccounting3.Models;
    using RequestAccounting3.Models.Users;

    public interface IRolesManager
    {
        IdentityResult identityResult { get; set; }

        Task<IEnumerable<IdentityRole>> GetRolesAsync();

        Task<bool> CreateAsync(string roleName);
      
        Task DeleteAsync(string id);

        Task<IEnumerable<User>> GetUsersAsync();

        Task<ChangeRoleViewModel> GetUserRoles(string userId);

        Task<bool> UpdateUserRoles(string userId, List<string> roles);
    }
}
