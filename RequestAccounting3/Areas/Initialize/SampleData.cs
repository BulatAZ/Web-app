using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using RequestAccounting3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestAccounting3.Areas.Initialize
{
    public class SampleData
    {              
       
        public static void Initialize(RequestDBContext context)
        {
            
            if (!context.Statuses.Any())
            {
                context.Statuses.AddRange(
                    new Status { name = "Registered" },
                    new Status { name = "Processed" },
                    new Status { name = "Closed" },
                    new Status { name = "Rejected" }
                );
                context.SaveChanges();
            }
        }
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
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
                User admin = new User { UserName = adminName, firstName = adminName };
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
                User user = new User { UserName = operatorName, firstName = operatorName };
                IdentityResult result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "operator");
                }
            }
        }
    }
}
