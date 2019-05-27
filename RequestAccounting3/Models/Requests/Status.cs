namespace RequestAccounting3.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Status
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
    }
}
