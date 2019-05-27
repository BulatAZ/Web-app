using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RequestAccounting3.Models.Requests
{
    public class RequestChange
    {       
        public int id { get; set; }

        public string operatorId { get; set; }
        
        public string customerFirstName { get; set; }

        public string customerLastName { get; set; }

        public string text { get; set; }
        
        public DateTime requestDate { get; set; }
        
        public string customerPhone { get; set; }
       
        public int statusId { get; set; }
       
    }
}
