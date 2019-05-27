using Microsoft.AspNetCore.Mvc;
using RequestAccounting3.Areas.Interfaces;
using RequestAccounting3.Models.Users;
using System.Threading.Tasks;

namespace RequestAccounting3.Controllers
{
    public class AccountController : Controller
    {        
        private readonly IAccountManager account;

        public AccountController(IAccountManager _account)
        {
            this.account = _account;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel newUser)
        {
            if (this.ModelState.IsValid)
            {               
                // добавляем пользователя
                       
                if (await this.account.RegisterAsync(newUser))
                {
                    // установка куки. bool: является ли куки постоянным(true) или сеансовым(false) время жизни куки                   
                    await this.account.SignInAsync(newUser, false);
                    return this.RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in this.account.identityResult.Errors)
                    {
                        this.ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return this.View(newUser);
        }
        /// <summary>
        /// Авторизация. 
        /// </summary>       
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return this.View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (this.ModelState.IsValid)
            {               
                if (await this.account.SignInAsync(model))
                {
                    // проверяем, принадлежит ли URL приложению
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && this.Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return this.Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return this.RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    this.ModelState.AddModelError("", "Wrong login and (or) password");
                }
            }

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            // удаляем аутентификационные куки          
            await this.account.SigOutAsync();
            return this.RedirectToAction("Index", "Home");
        }
    }
}