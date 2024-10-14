using Microsoft.AspNetCore.Identity;
using Store.Data.Entities.IdentityEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository
{
    public class StoreIdentityContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Noran Medhat",
                    Email = "Noranmedht63@gmail.com",
                    UserName = "NoranMedhat",
                    Address = new Address
                    {
                        FirstName = "Noran",
                        LastName = "Medhat",
                        City = "Mansoura",
                        State = "Dakhalia",
                        Street = "18",
                        PostalCode = "12345"
                    }
                };
                await userManager.CreateAsync(user, "Password123!");
            }
        }
    }
}
