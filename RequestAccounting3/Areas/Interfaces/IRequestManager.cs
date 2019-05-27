using RequestAccounting3.Models;
using RequestAccounting3.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestAccounting3.Areas.Interfaces
{
    public interface IRequestManager
    {
        IEnumerable<RequestView> GetOperatorRequestList(string userId);

        IEnumerable<RequestView> GetRequestList();

        RequestChange GetRequest(int requestId);

        void AddRequest(RequestCreate request);

        List<Status> GetStatusList();

        void UpdateStatus(RequestChange theChangedRequest);

    }
}
