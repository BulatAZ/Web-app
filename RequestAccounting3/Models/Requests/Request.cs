using RequestAccounting3.Models.Customers;
using RequestAccounting3.Models.Requests;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RequestAccounting3.Models
{
    public class Request
    {
        [Key]
        public int id { get; set; }        
        [Required]      
        public string operatorId { get; set; }
        [Required]
        public int customerId { get; set; } = 1;              
        [Required]
        public string text { get; set; }
        [Required]
        public DateTime requestDate { get; set; } = DateTime.Now;        
        [Required]
        public int statusId { get; set; } = 1;

        [ForeignKey("customerId")]
        public Customer Customer { get; set; }
        [ForeignKey("statusId")]
        public Status Status { get; set; }
    }
}
