namespace RequestAccounting3.Areas.Initialize
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;

    using RequestAccounting3.Models;

    public class SampleData
    {              
       
        public static void InitializeStatusAsync(RequestDBContext context)
        {           
            if (!context.Statuses.Any())
            {
                context.Statuses.AddRange(
                    new Status { name = "Registered" },
                    new Status { name = "Processed" },
                    new Status { name = "Closed" },
                    new Status { name = "Rejected" });
                context.SaveChanges();
            }
        }

        public static async Task InitializeUsersAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminName = "admin";            
            string operatorName = "Tom";
            string engineerName = "Bruce";
            string password = "P@ssw0rd";
            string superPassword = "P@ssw0rd123";
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }

            if (await roleManager.FindByNameAsync("engineer") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("engineer"));
            }

            if (await roleManager.FindByNameAsync("operator") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("operator"));
            }

            if (await userManager.FindByNameAsync(adminName) == null)
            {
                var admin = new User { UserName = adminName, firstName = adminName };
                IdentityResult result = await userManager.CreateAsync(admin, superPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }

            if (await userManager.FindByNameAsync(engineerName) == null)
            {
                User engineer = new User { UserName = engineerName, firstName = engineerName };
                IdentityResult result = await userManager.CreateAsync(engineer, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(engineer, "engineer");
                }
            }

            if (await userManager.FindByNameAsync(operatorName) == null)
            {
                var user = new User { UserName = operatorName, firstName = operatorName };
                IdentityResult result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "operator");
                }
            }
        }
    }
}
