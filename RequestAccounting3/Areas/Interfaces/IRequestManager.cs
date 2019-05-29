// ReSharper disable StyleCop.SA1633
namespace RequestAccounting3.Areas.Interfaces
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using RequestAccounting3.Models;
    using RequestAccounting3.Models.Requests;

    public interface IRequestManager
    {     

        Task <List<Status>> GetStatusListAsync();

        Task<IEnumerable<RequestView>> GetOperatorRequestListAsync(string userId);

        Task<IEnumerable<RequestView>> GetRequestListAsync();  

        Task AddRequestAsync(RequestCreate request);

        Task UpdateStatusAsync(RequestChange theChangedRequest);
    }
}
