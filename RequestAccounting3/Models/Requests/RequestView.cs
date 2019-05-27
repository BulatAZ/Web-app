using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestAccounting3.Models.Requests
{
    public class RequestView
    {
       
        public int id { get; set; }
        
        public string operatorId { get; set; }
       
        public string customerFirstName { get; set; }

        public string customerLastName { get; set; }

        public string text { get; set; }
       
        public DateTime requestDate { get; set; }

        public string customerPhone { get; set; }

        public string status { get; set; } 
       
    }
}
