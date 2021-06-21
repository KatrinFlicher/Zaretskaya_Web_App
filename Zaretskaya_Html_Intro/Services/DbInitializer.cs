using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zaretskaya_Html_Intro.DAL.Data;
using Zaretskaya_Html_Intro.DAL.Entities;

namespace Zaretskaya_Html_Intro.Services
{
    public class DbInitializer
    {
        public static async Task Seed(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            //создать БД, если она еще не создана
            context.Database.EnsureCreated();

            //проверка наличия ролей
            if (!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };
                //создать роль admin
                await roleManager.CreateAsync(roleAdmin);
            }

            //проверка наличия пользователей
            if (!context.Users.Any())
            {
                //создать пользователя user@mail.ru
                var user = new ApplicationUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru"
                };
                await userManager.CreateAsync(user, "123456");
                //создать пользователя admin@mail.ru
                var admin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru"
                };
                await userManager.CreateAsync(admin, "123456");
                //назначить роль admin
                admin = await userManager.FindByEmailAsync("admin@mail.ru");
                await userManager.AddToRoleAsync(admin, "admin");
            }

            if (!context.DrugGroups.Any())
            {
                context.DrugGroups.AddRange(new List<DrugGroup>
            {
                new DrugGroup{Name="Sedative"},
                new DrugGroup{Name="Anesthetize"},
                new DrugGroup{Name="Antipyretic"},
                new DrugGroup{Name="Antihistamines"},
                new DrugGroup{Name="Eubiotic"},
                new DrugGroup{Name="Dietary supplements"}
            });
                await context.SaveChangesAsync();
            }

            if (!context.Drugs.Any())
            {
                context.Drugs.AddRange(new List<Drug>
            {
                new Drug{Name="Adaptol", Description="For calm feeling", Price=20, GroupId=1, Image="adaptol.jpg"},
                new Drug{Name="Bilzol", Description="Bil zol, stal dobr", Price=15, GroupId=1, Image="bilzol.jpg"},
                new Drug{Name="Cod", Description="Code is not compiled", Price=24, GroupId=4, Image="cod.jpg"},
                new Drug{Name="Nebilet", Description="Against death", Price=1000, GroupId=2, Image="nebilet.jpg"},
                new Drug{Name="Noshpa", Description="Against brain pain", Price=20, GroupId=2, Image="noshpa.jpg"},
                new Drug{Name="Syprastin", Description="Against allergy", Price=31, GroupId=4, Image="sypra.jpg"},
            });
                await context.SaveChangesAsync();
            }
        }
    }
}
