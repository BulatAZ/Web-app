namespace RequestAccounting3.Models
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class UserDBContext : IdentityDbContext<User>
    {
        public UserDBContext(DbContextOptions<UserDBContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
    }
}
