using Microsoft.EntityFrameworkCore;
using RequestAccounting3.Models.Customers;

namespace RequestAccounting3.Models
{
    public class RequestDBContext : DbContext
    {
        public DbSet<Request> Requests { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Customer> Customer{ get; set; }

        // Через параметр options в конструктор контекста данных будут передаваться настройки контекста.        
        public RequestDBContext(DbContextOptions<RequestDBContext> options)
            : base(options)
        {
            // В конструкторе с помощью вызова Database.EnsureCreated() по определению моделей будет создаваться база данных
            // (если она отсутствует). Подход CodeFirst
            Database.EnsureCreated();
        }
    }
}
