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
            account = _account;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel newUser)
        {
            if (ModelState.IsValid)
            {               
                // добавляем пользователя
                       
                if (await account.RegisterAsync(newUser))
                {
                    // установка куки. bool: является ли куки постоянным(true) или сеансовым(false) время жизни куки                   
                    await account.SignInAsync(newUser, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in account.identityResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(newUser);
        }
        /// <summary>
        /// Авторизация. 
        /// </summary>       
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {               
                if (await account.SignInAsync(model))
                {
                    // проверяем, принадлежит ли URL приложению
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Wrong login and (or) password");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            // удаляем аутентификационные куки          
            await account.SigOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}