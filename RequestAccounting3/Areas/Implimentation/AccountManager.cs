using Microsoft.AspNetCore.Identity;
using RequestAccounting3.Areas.Interfaces;
using RequestAccounting3.Models;
using RequestAccounting3.Models.Users;
using System.Threading.Tasks;

namespace RequestAccounting3.Areas.Implimentation
{
    public class AccountManager : IAccountManager
    {

        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        public IdentityResult result { get; set; }
        private User user;

        public AccountManager(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
        }

        public async Task<bool> SignInAsync(LoginViewModel user)
        {
            //последний параметр: блокировка при сбое = false 
            var outcome = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, user.RememberMe, false);
            return outcome.Succeeded;           
        }

        public async Task<bool> RegisterAsync(RegisterViewModel newUser)
        {
            this.user = new User
            {
                UserName = newUser.UserName,
                firstName = newUser.firstName,
                lastName = newUser.lastName,
                PhoneNumber = newUser.Phone
            };
            // добавляем пользователя
            var result = await _userManager.CreateAsync(user, newUser.Password);           
            return result.Succeeded;           
        }

        public async Task SigOutAsync()
        {           
            await _signInManager.SignOutAsync();
        }

        public async Task SignInAsync(RegisterViewModel newUser, bool isPersistant)
        {           
            await _signInManager.SignInAsync(user, isPersistant);
        }

        public async Task<string> GetUserIdAsync(string userName)
        {            
           User user = await _userManager.FindByNameAsync(userName);
           return user.Id;
        }
    }
}
