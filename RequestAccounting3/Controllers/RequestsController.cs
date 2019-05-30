// ReSharper disable StyleCop.SA1633
// ReSharper disable StyleCop.SA1600
namespace RequestAccounting3.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    using RequestAccounting3.Areas.Interfaces;
    using RequestAccounting3.Models.Requests;

    public class RequestsController : Controller
    {       
        private IRequestManager requestManager;
        private IAccountManager accountManager;       

        // поскольку в классе Startup в методе ConfigureServices
        // контекст данных устанавливается как сервис, то в конструкторе контроллера можем получить переданный контекст данных.
        
        public RequestsController(IRequestManager request, IAccountManager accountManager)
        {      
            this.requestManager = request;
            this.accountManager = accountManager;
        }

        [Authorize(Roles = "operator")]
        public async Task<ActionResult> OperatorRequest()
        {            
            var userId = await this.accountManager.GetUserIdAsync(this.User.Identity.Name);
            var requests = await this.requestManager.GetOperatorRequestListAsync(userId);
           
            return this.View(requests);           
        }

        [Authorize(Roles = "operator")]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = "operator")]
        public async Task<ActionResult> Create(RequestCreate newRequest)
        {
            if (this.ModelState.IsValid)
            {
                newRequest.operatorId = await this.accountManager.GetUserIdAsync(this.User.Identity.Name);             
                await this.requestManager.AddRequestAsync(newRequest);
                return this.RedirectToAction("Index", "Home");
            }
            
            return this.View(newRequest);
        }

        [Authorize(Roles = "engineer")]
        public async Task<IActionResult> AllRequest()
        {
            var requests = await this.requestManager.GetRequestListAsync();
            return this.View(requests);
        }

        [HttpGet]
        [Authorize(Roles = "engineer")]               
        // почему правильно работает только при наименовании параметра как  id ?????
        public async Task<IActionResult> ChangeStatus(int id)
        {
            var statusList = await this.requestManager.GetStatusListAsync();
            this.ViewBag.Status = new SelectList(statusList, "id", "name");          
            return this.View(new RequestChange() { id = id });
        }

        [HttpPost]
        [Authorize(Roles = "engineer")]
        public async Task<IActionResult> ChangeStatus(RequestChange theChangedRequest)
        {
            await this.requestManager.UpdateStatusAsync(theChangedRequest);
            return this.RedirectToAction("AllRequest", "Requests");
        }
    }
}