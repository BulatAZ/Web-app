using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RequestAccounting3.Models
{
    public class Status
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
    }
}
