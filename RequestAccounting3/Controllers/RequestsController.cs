using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RequestAccounting3.Areas.Implimentation;
using RequestAccounting3.Areas.Interfaces;
using RequestAccounting3.Models;
using RequestAccounting3.Models.Requests;

namespace RequestAccounting3.Controllers
{
    
    public class RequestsController : Controller
    {       
        private IRequestManager requestManager;
        private IAccountManager accountManager;       

        // поскольку в классе Startup в методе ConfigureServices
        // контекст данных устанавливается как сервис, то в конструкторе контроллера можем получить переданный контекст данных.
        
        public RequestsController(IRequestManager request, IAccountManager accoountManager)
        {      
            this.requestManager = request;
            this.accountManager = accoountManager;
        }
        [Authorize(Roles = "operator")]
        public async Task<ActionResult> OperatorRequest()
        {            
            string userId = await this.accountManager.GetUserIdAsync(this.User.Identity.Name);
            var requests = this.requestManager.GetOperatorRequestList(userId);            
            return this.View(requests);           
        }
        [Authorize(Roles = "operator")]
        public IActionResult Create()
        {
            return this.View();
        }
        [HttpPost]       
        public async Task<ActionResult> Create(RequestCreate newRequest)
        {
            if (ModelState.IsValid)
            {
                string userId = await this.accountManager.GetUserIdAsync(User.Identity.Name);
                //await Task.Yield(); ////
                newRequest.operatorId = userId;
                this.requestManager.AddRequest(newRequest);
                return RedirectToAction("Index", "Home");
            }        
            return this.View(newRequest);
        }

        [Authorize(Roles = "engineer")]
        public IActionResult AllRequest()
        {
            var requests = this.requestManager.GetRequestList();
            return this.View(requests);
        }

        [HttpGet]
        [Authorize(Roles = "engineer")]
        // првильно работает только при таком - id - наименовании параметра. ?????
        public IActionResult ChangeStatus(int id)
        {
            var request = this.requestManager.GetRequest(id);
            // второй параметр это value, третий параметр - имя поли
            this.ViewBag.Status = new SelectList(this.requestManager.GetStatusList(), "id", "name");
            return this.View(request);
        }
      
        [HttpPost]
        public IActionResult ChangeStatus(RequestChange theChangedRequest)
        {
            this.requestManager.UpdateStatus(theChangedRequest);            
            return this.RedirectToAction("AllRequest", "Requests");
        }
    }
}