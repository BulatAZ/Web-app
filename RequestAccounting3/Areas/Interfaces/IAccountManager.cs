namespace RequestAccounting3.Areas.Interfaces
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;

    using RequestAccounting3.Models.Users;

    public interface IAccountManager
    {
        IdentityResult identityResult { get; set; }

        Task<bool> RegisterAsync(RegisterViewModel newUser);

        Task<bool> SignInAsync(LoginViewModel user);

        Task SignInAsync(RegisterViewModel user, bool isPersistant);

        Task SigOutAsync();

        Task<string> GetUserIdAsync(string userName);
    }
}
