namespace RequestAccounting3.Areas.Interfaces
{
    using System.Collections.Generic;

    using RequestAccounting3.Models;
    using RequestAccounting3.Models.Requests;

    public interface IRequestManager
    {
        List<Status> GetStatusList();

        IEnumerable<RequestView> GetOperatorRequestList(string userId);

        IEnumerable<RequestView> GetRequestList();

        RequestChange GetRequest(int requestId);

        void AddRequest(RequestCreate request);        

        void UpdateStatus(RequestChange theChangedRequest);
    }
}
