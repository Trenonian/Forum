using System;
using System.Linq;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace forum.Models
{
    public class SampleData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
            context.Database.Migrate();

            #region admin
            var admin = await userManager.FindByNameAsync("admin");
            if (admin == null)
            {
                admin = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "amon-ra@sbcglobal.net",
                    Signature = "Adeptus Mechanicus"
                    

                };
                await userManager.CreateAsync(admin, "admin");
                
                await userManager.AddClaimAsync(admin, new Claim("IsAdmin", "true"));
                await userManager.AddToRoleAsync(admin, "admin");
            }
            #endregion

            #region lumberjack
            var lumber = await userManager.FindByNameAsync("lumberjack");
            if (lumber == null)
            {
                lumber = new ApplicationUser
                {
                    UserName = "lumberjack",
                    Email = "mountainman@fake.com",
                    Signature = "And my axe!"
                };
                await userManager.CreateAsync(lumber, "sticksandstones");
            }
            #endregion

            #region flower
            var flower = await userManager.FindByNameAsync("FlowerPower");
            if (flower == null)
            {
                flower = new ApplicationUser
                {
                    UserName = "FlowerPower",
                    Email = "daisy@fake.com",
                    Signature = "Flowers are the best."
                };
                await userManager.CreateAsync(flower, "weedkiller");
            }
            #endregion
            
            #region jimmy
            var jimmy = await userManager.FindByNameAsync("jimmy");
            if (jimmy == null)
            {
                jimmy = new ApplicationUser
                {
                    UserName = "jimmy",
                    Email = "jimmy@fake.com"
                };
                await userManager.CreateAsync(jimmy, "john");
            }
            #endregion
            
            #region samurai
            var samurai = await userManager.FindByNameAsync("samurai");
            if (samurai == null)
            {
                samurai = new ApplicationUser
                {
                    UserName = "samurai",
                    Email = "blade@fake.com",
                    Signature = "The perfect sword."
                };
                await userManager.CreateAsync(samurai, "ninja");
            }
            #endregion
            
            #region mary
            var mary = await userManager.FindByNameAsync("MarySue");
            if (mary == null)
            {
                mary = new ApplicationUser
                {
                    UserName = "MarySue",
                    Email = "protagonist@fake.com",
                    Signature = "Everything is awesome!"
                };
                await userManager.CreateAsync(mary, "chosenOne");
            }
            #endregion

            #region user template
            //#region user
            //var user = await userManager.FindByNameAsync("");
            //if (user == null)
            //{
            //    user = new ApplicationUser
            //    {
            //        UserName = "",
            //        Email = "@fake.com",
            //        Signature = ""
            //    };
            //    await userManager.CreateAsync(user, "");
            //}
            //#endregion
            #endregion

            context.Boards.AddRange(
                new Board { Name = "Help" },
                new Board { Name = "Funny" },
                new Board { Name = "Off Topic" },
                new Board { Name = "" },
                new Board { Name = "" },
                new Board { Name = "" },
                new Board { Name = "" },
                new Board { Name = "" },
                new Board { Name = "" },
                new Board { Name = "" }

            );

        }

    }
}
