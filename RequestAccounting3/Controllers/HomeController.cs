
namespace RequestAccounting3.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {

        // поскольку в классе Startup в методе ConfigureServices
        // контекст данных устанавливается как сервис, то в конструкторе контроллера можем получить переданный контекст данных.
        public HomeController()
        {
            
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Info()
        {

            return this.View();
        }


    }
}