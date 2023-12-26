using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using OzturkOtoMarketWEBUI.identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OzturkOtoMarketWEBUI.Entity
{
    public class DataInitializer: DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {

            var Kategoriler = new List<Category>()
            {
                new Category() { Name ="İKONİK", Description="İkonik arbalar"},
                new Category() { Name ="NADİR", Description="Nadir arabalar"}, 
                new Category() { Name ="KLASİK", Description="Klasik arabalar"},
                new Category() { Name ="GÖRÜNÜŞ", Description="Görünüşlü arabalar"},
               
               
            };

            foreach (var kategori in Kategoriler)
            {
                context.Categories.Add(kategori);
            }
            context.SaveChanges();

            var urunler = new List<Product>()
            {
                new Product() { Name ="Araba1", Description = "Geleceğe Dönüş", Price =400, Stock = 10, IsApproved =true, CategoryId =3, Image="araba1.jpg" },
                new Product() { Name ="Araba2", Description = "WW Beetle", Price =300, Stock = 10, IsApproved =false, CategoryId =4,Image="araba2.jpg"},
                new Product() { Name ="Araba3", Description = "SUV", Price =450, Stock = 10, IsApproved =true, CategoryId =2,Image="araba3.jpg"},

                new Product() { Name ="Araba4", Description = "Bugatti", Price =700, Stock = 8, IsApproved =true, CategoryId =1,Image="araba4.png",},
                new Product() { Name ="Araba5", Description = "Kırmızı BMW", Price =600, Stock = 4, IsApproved =true, CategoryId =1,Image="araba5.jpg"},
                new Product() { Name ="Araba6", Description = "Klasik", Price =500, Stock = 3, IsApproved =true, CategoryId =3,Image="araba6.jpg"},

                new Product() { Name ="Araba7", Description = "Beyaz Honda", Price =300, Stock = 5, IsApproved =true, CategoryId =1,Image="araba7.png" },
                new Product() { Name ="Araba8", Description = "Beyaz Mercedes", Price =350, Stock = 40, IsApproved =true, CategoryId =3,Image="araba8.jpg"},
                new Product() { Name ="Araba9", Description = "Defender", Price =400, Stock = 50, IsApproved =false, CategoryId =2,Image="araba9.png" },

                new Product() { Name ="Araba10", Description = "Mustang", Price =200, Stock = 10, IsApproved =true, CategoryId =3,Image="araba10.png" },
                new Product() { Name ="Araba11", Description = "Nissan Skyline", Price =300, Stock = 10, IsApproved =true, CategoryId =1,Image="araba11.png" },
                new Product() { Name ="Araba12", Description = "Lacivert BMW", Price =500, Stock = 10, IsApproved =true, CategoryId =1,Image="araba12.jpg" },

                new Product() { Name ="Araba13", Description = "Klasik Chevrolet", Price= 200, Stock = 10, IsApproved =true, CategoryId =3,Image="araba13.png" },
                new Product() { Name ="Araba14", Description = "BMW 507", Price =300, Stock = 10, IsApproved =true, CategoryId =1,Image="araba14.jpg" },
                new Product() { Name ="Araba15", Description = "Cadillac Esclade", Price =800, Stock = 10, IsApproved =true, CategoryId =2,Image="araba15.jpg" },

                new Product() { Name ="Araba16", Description = "Maisto Chevrolet", Price =400, Stock = 8, IsApproved =true, CategoryId =3,Image="araba16.png"},
                new Product() { Name ="Araba17", Description = "Dekoratif Metal Araba", Price =30, Stock = 3, IsApproved =false, CategoryId =3,Image="araba17.jpg"},
                new Product() { Name ="Araba18", Description = "Mitsubishi Eclipse", Price =600, Stock = 5, IsApproved =true, CategoryId =1,Image="araba18.jpg"},

                new Product() { Name ="Araba19", Description = "Chevrolet Camaro", Price =700, Stock = 10, IsApproved =true, CategoryId =3,Image="araba19.png" },
                new Product() { Name ="Araba20", Description = "Chevrolet Camaro 1967", Price =800, Stock = 30, IsApproved =true, CategoryId =3 ,Image="araba20.png" },
                new Product() { Name ="Araba21", Description = "Audi a3", Price =900, Stock = 20, IsApproved =false, CategoryId =4, Image="araba21.jpg"}



            };

            foreach(var urun in urunler)
            {
                context.Products.Add(urun);
            }
            context.SaveChanges();



            if (!context.Roles.Any(i => i.Name == "admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);

                var role = new ApplicationRole() { Name = "admin", Description = "admin rolü" };
                manager.Create(role);

            }


            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);

                var role = new ApplicationRole() { Name = "user", Description = "user rolü" }; ;
                manager.Create(role);

            }

            if (!context.Users.Any(i => i.Name == "kenissha"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser() { Name = "MUSA", Surname = "BORA", UserName = "BYBORA", Email = "bora_musa@outlook.com" };
                manager.Create(user, "434343");
                manager.AddToRole(user.Id, "admin");
                manager.AddToRole(user.Id, "user");

            }

            if (!context.Users.Any(i => i.Name == "kabisko"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser() { Name = "MAHMUT", Surname = "CAN", UserName = "CANDUMBS", Email = "mahmutcr039@gmail.com" };
                manager.Create(user, "555555");
                manager.AddToRole(user.Id, "user");

            }


            base.Seed(context);
        }
    }


}