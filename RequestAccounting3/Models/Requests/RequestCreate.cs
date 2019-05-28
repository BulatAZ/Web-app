namespace RequestAccounting3.Models.Requests
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class RequestCreate
    {
       
        public string operatorId { get; set; }
        [Required]
        [Display(Name = "Customer first name")]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "No more than 25 characters")]
        public string customerFirstName { get; set; }
        [Required]
        [Display(Name = "Customer last name")]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "No more than 25 characters")]
        public string customerLastName { get; set; }
        [Required]
        [Display(Name = "Phone number")]
        [DataType(DataType.PhoneNumber)]
        public string customerPhone { get; set; }       
        [Required]
        [Display(Name = "Text")]
        [DataType(DataType.Text)]
        public string text { get; set; }
        [Required]
        [Display(Name = "Reguest date")]
        [DataType(DataType.DateTime)]
        public DateTime requestDate { get; set; } = DateTime.Now;        
      
    }
}
