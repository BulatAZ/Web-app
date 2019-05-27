namespace RequestAccounting3.Areas.Implimentation
{
    using System.Collections.Generic;
    using System.Linq;

    using RequestAccounting3.Areas.Interfaces;
    using RequestAccounting3.Models;
    using RequestAccounting3.Models.Customers;
    using RequestAccounting3.Models.Requests;

    public class RequestManager : IRequestManager 
    {       
        private RequestDBContext context;

        public RequestManager(RequestDBContext _context)
        {
            this.context = _context;            
        }

        public IEnumerable<RequestView> GetOperatorRequestList(string userId)
        {       
         var requests = from request in this.context.Requests.Where(a => a.operatorId == userId)
                              join status in this.context.Statuses on request.statusId equals status.id
                              join customer in this.context.Customer on request.customerId equals customer.id
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
            var customer = this.context.Customer.FirstOrDefault(a => 
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
                this.context.Customer.Add(customer);
            }
            var request = new Request
            {
                operatorId = newRequest.operatorId,                
                requestDate = newRequest.requestDate,
                text = newRequest.text,
                customerId = customer.id,
            };
            this.context.Requests.Add(request);
            this.context.SaveChanges();
        }
        public IEnumerable<RequestView> GetRequestList()
        {            
             var requests = from request in this.context.Requests
                           join status in this.context.Statuses on request.statusId equals status.id
                           join customer in this.context.Customer on request.customerId equals customer.id
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
            var requestChange = from request in this.context.Requests.Where(req => req.id == requestId)
                                join status in this.context.Statuses on request.statusId equals status.id
                                join customer in this.context.Customer on request.customerId equals customer.id
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
            Request request = this.context.Requests.FindAsync(theChangedRequest.id).Result;
            request.statusId = theChangedRequest.statusId;
            this.context.SaveChanges();
        }
    }
}
