using Microsoft.AspNetCore.Identity;
using RequestAccounting3.Areas.Interfaces;
using RequestAccounting3.Models;
using RequestAccounting3.Models.Customers;
using RequestAccounting3.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestAccounting3.Areas.Implimentation
{
    public class RequestManager : IRequestManager 
    {       
        private RequestDBContext context;

        public RequestManager(RequestDBContext _context)
        {
            this.context = _context;            
        }

        public IEnumerable<RequestView> GetOperatorRequestList(string userId)
        {
            /*var requests = context.Requests.Where(a => a.operatorId == userId).Join(context.Statuses,
               p => p.statusId,
               c => c.id,
               (p, c) => new RequestView
               {
                   id = p.id,                   
                   customerFirstName = p.customerFirstName,
                   customerLastName = p.customerLastName,
                   text = p.text,
                   requestDate = p.requestDate,
                   phone = p.phone,
                   status = c.name
               });*/

            var requests = from request in context.Requests.Where(a => a.operatorId == userId)
                              join status in context.Statuses on request.statusId equals status.id
                              join customer in context.Customer on request.customerId equals customer.id
                              select new RequestView
                              {
                                  id = request.id,
                                  customerFirstName = customer.firstName,
                                  customerLastName = customer.lastName,
                                  text = request.text,
                                  requestDate = request.requestDate,
                                  customerPhone = customer.phone,
                                  status = status.name
                              };             
            return requests;           
        }
        public void AddRequest(RequestCreate newRequest)
        {
            var customer = context.Customer.FirstOrDefault(a => 
                a.firstName == newRequest.customerFirstName &&
                a.lastName == newRequest.customerLastName &&
                a.phone == newRequest.customerPhone);
           
            if (customer == null)
            {
                customer = new Customer()
                {
                    firstName = newRequest.customerFirstName,
                    lastName = newRequest.customerLastName,
                    phone = newRequest.customerPhone
                };
                context.Customer.Add(customer);
            }
            Request request = new Request
            {
                operatorId = newRequest.operatorId,                
                requestDate = newRequest.requestDate,
                text = newRequest.text,
                customerId = customer.id,
            };            
            context.Requests.Add(request);
            context.SaveChanges();
        }

        public IEnumerable<RequestView> GetRequestList()
        {            
             var requests = from request in context.Requests
                           join status in context.Statuses on request.statusId equals status.id
                           join customer in context.Customer on request.customerId equals customer.id
                           select new RequestView
                           {
                               id = request.id,
                               operatorId = request.operatorId,
                               customerFirstName = customer.firstName,
                               customerLastName = customer.lastName,
                               text = request.text,
                               requestDate = request.requestDate,
                               customerPhone = customer.phone,
                               status = status.name
                           };
            return requests;
        }

        public RequestChange GetRequest(int requestId)
        {
            //Request request = context.Requests.FindAsync(requestId).Result;
            var requestChange = from request in context.Requests.Where(req => req.id == requestId)
                                join status in context.Statuses on request.statusId equals status.id
                                join customer in context.Customer on request.customerId equals customer.id
                                select new RequestChange
                                {
                                    id = request.id,
                                    customerFirstName = customer.firstName,
                                    customerLastName = customer.lastName,
                                    text = request.text,
                                    requestDate = request.requestDate,
                                    customerPhone = customer.phone,                                   
                         };
              
           
            return requestChange.First();
        }

        public List<Status> GetStatusList()
        {
            var statusList = context.Statuses.ToList();            
            return statusList;
        }
        public void UpdateStatus (RequestChange theChangedRequest)
        {
            Request request = context.Requests.FindAsync(theChangedRequest.id).Result;
            request.statusId = theChangedRequest.statusId;           
            context.SaveChanges();
        }
    }
}
