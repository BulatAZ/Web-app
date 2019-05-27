using Microsoft.AspNetCore.Identity;
using RequestAccounting3.Models.Users;
using System.Threading.Tasks;

namespace RequestAccounting3.Areas.Interfaces
{
    public interface IAccountManager
    {
        IdentityResult result { get; set; }

        Task<bool> RegisterAsync(RegisterViewModel newUser);

        Task<bool> SignInAsync(LoginViewModel user);

        Task SignInAsync(RegisterViewModel user, bool isPersistant);

        Task SigOutAsync();

        Task<string> GetUserIdAsync(string userName);
    }
}
