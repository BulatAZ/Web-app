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
        private IRequestManager _requestManager;
        private IAccountManager _accountManager;       

        // поскольку в классе Startup в методе ConfigureServices
        // контекст данных устанавливается как сервис, то в конструкторе контроллера можем получить переданный контекст данных.
        
        public RequestsController(IRequestManager request, IAccountManager accoountManager)
        {      
            this._requestManager = request;
            this._accountManager = accoountManager;
        }
        [Authorize(Roles = "operator")]
        public async Task<ActionResult> OperatorRequest()
        {            
            string userId = await _accountManager.GetUserIdAsync(User.Identity.Name);
            var requests = _requestManager.GetOperatorRequestList(userId);            
            return View(requests);           
        }
        [Authorize(Roles = "operator")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]       
        public async Task<ActionResult> Create(RequestCreate newRequest)
        {
            if (ModelState.IsValid)
            {
                string userId = await _accountManager.GetUserIdAsync(User.Identity.Name);
                //await Task.Yield(); ////
                newRequest.operatorId = userId;              
                _requestManager.AddRequest(newRequest);
                return RedirectToAction("Index", "Home");
            }        
            return View(newRequest);
        }

        [Authorize(Roles = "engineer")]
        public IActionResult AllRequest()
        {
            var requests = _requestManager.GetRequestList();
            return View(requests);
        }

        [HttpGet]
        [Authorize(Roles = "engineer")]
        // првильно работает только при таком - id - наименовании параметра. ?????
        public IActionResult ChangeStatus(int id)
        {
            var request = _requestManager.GetRequest(id);
            // второй параметр это value, третий параметр - имя поли
            ViewBag.Status = new SelectList(_requestManager.GetStatusList(), "id", "name");
            return View(request);
        }
      
        [HttpPost]
        public IActionResult ChangeStatus(RequestChange theChangedRequest)
        {
            _requestManager.UpdateStatus(theChangedRequest);            
            return RedirectToAction("AllRequest", "Requests");
        }
    }
}