namespace RequestAccounting3.Models
{
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser 
    {
        public string firstName { get; set; }

        public string lastName { get; set; }
    }
}
