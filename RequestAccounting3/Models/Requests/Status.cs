namespace RequestAccounting3.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Status
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }

        public ICollection<User> Users { get; set; }
        public Status()
        {
            this.Users = new List<User>();
        }
    }
}
