namespace RequestAccounting3.Models.Customers

{
    using System.ComponentModel.DataAnnotations;

    public class Customer
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        public string phone { get; set; }        
    }
}
