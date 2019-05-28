namespace RequestAccounting3.Areas.Implimentation
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;

    using RequestAccounting3.Areas.Interfaces;
    using RequestAccounting3.Models;
    using RequestAccounting3.Models.Users;

    public class AccountManager : IAccountManager
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public IdentityResult identityResult { get; set; }

        private User user;

        public AccountManager(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public async Task<bool> SignInAsync(LoginViewModel user)
        {
            //последний параметр: блокировка при сбое = false 
            var outcome = await this.signInManager.PasswordSignInAsync(
                              user.UserName,
                              user.Password,
                              user.RememberMe, 
                              false);
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
            var result = await this.userManager.CreateAsync(this.user, newUser.Password);           
            return result.Succeeded;           
        }

        public async Task SigOutAsync()
        {           
            await this.signInManager.SignOutAsync();
        }

        public async Task SignInAsync(RegisterViewModel newUser, bool isPersistant)
        {           
            await this.signInManager.SignInAsync(this.user, isPersistant);
        }

        public async Task<string> GetUserIdAsync(string userName)
        {            
           var userOperator = await this.userManager.FindByNameAsync(userName);
           return userOperator.Id;
        }
    }
}
