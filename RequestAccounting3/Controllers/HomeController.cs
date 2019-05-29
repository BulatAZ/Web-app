
namespace RequestAccounting3.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    public class HomeController : Controller
    {
        private readonly ILogger logger;
        // поскольку в классе Startup в методе ConfigureServices
        // контекст данных устанавливается как сервис, то в конструкторе контроллера можем получить переданный контекст данных.
        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;
        }

        public IActionResult Index()
        {
            this.logger.LogInformation("Request on index from homeC");
            return this.View();
        }

        public IActionResult Info()
        {

            return this.View();
        }


    }
}