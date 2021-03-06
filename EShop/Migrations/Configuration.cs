namespace EShop.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using EShop.Models;
    internal sealed class Configuration : DbMigrationsConfiguration<EShop.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EShop.Models.ApplicationDbContext db)
        {
            
            db.Products.AddOrUpdate(
                x=>x.Title ,
                new Product
                  {
                    Title= "雅诗兰黛小棕瓶",
                    Description= "雅诗兰黛小棕瓶面部精华 特润修护肌透精华露30/50ml补水修护抗皱",
                    Price = 590,
                    ImageUrl = "esteelauder.jpg"
                },
                new Product
                {
                    Title = "sk-ii神仙水",
                    Description = "sk-ii神仙水护肤精华露面部精华液护肤补水A",
                    Price = 1450,
                    ImageUrl = "skii.jpg"
                },
                new Product
                {
                    Title = "科颜氏爽肤水",
                    Description = "科颜氏金盏花爽肤水250ml/500ml 化妆水 保湿 补水 ",
                    Price = 340,
                    ImageUrl = "kiehls.jpg"
                }
                );
        }
    }
}

//  This method will be called after migrating to the latest version.

//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
//  to avoid creating duplicate seed data. E.g.
//
//    context.People.AddOrUpdate(
//      p => p.FullName,
//      new Person { FullName = "Andrew Peters" },
//      new Person { FullName = "Brice Lambson" },
//      new Person { FullName = "Rowan Miller" }
//    );
//