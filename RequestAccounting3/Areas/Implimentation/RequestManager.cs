namespace RequestAccounting3.Areas.Implimentation
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading.Tasks;

    using RequestAccounting3.Areas.Interfaces;
    using RequestAccounting3.Models;
    using RequestAccounting3.Models.Customers;
    using RequestAccounting3.Models.Requests;

    [SuppressMessage("ReSharper", "StyleCop.SA1600")]
    public class RequestManager : IRequestManager 
    {       
        private readonly RequestDBContext context;      

        public RequestManager(RequestDBContext context)
        {
            this.context = context;
        }

        private IEnumerable<RequestView> GetOperatorRequestList(string userId)
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

        public async Task <IEnumerable<RequestView>> GetOperatorRequestListAsync(string userId)
        {
            return await Task.Run(() => this.GetOperatorRequestList(userId));           
        }

        private void AddRequest(RequestCreate newRequest)
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

        public async Task AddRequestAsync(RequestCreate newRequest)
        {
            await Task.Run(() => this.AddRequest(newRequest));
        }

        private IEnumerable<RequestView> GetRequestList()
        {         
            var requests = from request in this.context.Requests
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

        public async Task<IEnumerable<RequestView>> GetRequestListAsync()
        {
            return await Task.Run(this.GetRequestList);
        }

        private RequestChange GetRequest(int requestId)
        {
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

        public async Task<RequestChange> GetRequestAsync(int requestId)
        {
            return await Task.Run(() => this.GetRequest(requestId));
        }

        private List<Status> GetStatusList()
        {
            var statusList = this.context.Statuses.ToList();            
            return statusList;
        }

        public async Task<List<Status>> GetStatusListAsync()
        {
            return await Task.Run(this.GetStatusList);
        }

        private void UpdateStatus (RequestChange theChangedRequest)
        {
            var request = this.context.Requests.FindAsync(theChangedRequest.id).Result;
            request.statusId = theChangedRequest.statusId;
            this.context.SaveChanges();
        }

        public async Task UpdateStatusAsync(RequestChange theChangedRequest)
        {
            await Task.Run(() => this.UpdateStatus(theChangedRequest));
        }
    }
}
