﻿using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class MatrixIncDbInitializer
    {
        public static void Initialize(MatrixIncDbContext context)
        {
            // Look for any customers.
            if (context.Customers.Any())
            {
                return;   // DB has been seeded
            }
         
            var customers = new Customer[]
            {
                new Customer { Naam = "Neo", Achternaam = "Anderson", Land = "Matrix", Address = "6369AE", Postcode = "1234AB", Straatnaam = "Elm St", Huisnummer = "123", Active = true },
                new Customer { Naam = "Morpheus", Achternaam = "Smith", Land = "Matrix", Address = "289PW", Postcode = "4567CD", Straatnaam = "Oak St", Huisnummer = "456", Active = true },
                new Customer { Naam = "Trinity", Achternaam = "White", Land = "Matrix", Address = "1219KW" , Postcode = "7890EF", Straatnaam = "Pine St", Huisnummer = "789", Active = true }
            };

            context.Customers.AddRange(customers);

            var orders = new Order[]
            {
                new Order { Customer = customers[0], OrderDate = DateTime.Parse("2021-01-01")},
                new Order { Customer = customers[0], OrderDate = DateTime.Parse("2021-02-01")},
                new Order { Customer = customers[1], OrderDate = DateTime.Parse("2021-02-01")},
                new Order { Customer = customers[2], OrderDate = DateTime.Parse("2021-03-01")}
            };  
            context.Orders.AddRange(orders);


            var products = new Product[]
            {
                new Product { Name = "Makita", Description = "Makita accuradio", Price = 129.99m },
                new Product { Name = "Fietsslot", Description = "Zwaar kettingslot imbus ERT2", Price = 39.95m },
                new Product { Name = "Fietsketting", Description = "Sterke fietsketting alluminium", Price = 19.95m },
                new Product { Name = "Halogeenkoplamp", Description = "Heldere koplamp voor de auto", Price = 14.99m },
                new Product { Name = "Kozijnschroeven", Description = "Set van 100 buldexen plattenkop", Price = 12.50m },
                new Product { Name = "Coffeemakita", Description = "Makita koffiezetapparaat voor op de werkvloer", Price = 89.00m },

            };
            context.Products.AddRange(products);

            // Koppel producten aan orders
            orders[0].Products.Add(products[0]); // Makita
            orders[0].Products.Add(products[5]); // Coffeemakita
            orders[1].Products.Add(products[1]); // Fietsslot
            orders[2].Products.Add(products[2]); // Fietsketting
            orders[3].Products.Add(products[3]); // Halogeenkoplamp

            var parts = new Part[]
            {
                new Part { Name = "Tandwiel", Description = "Overdracht van rotatie in bijvoorbeeld de motor of luikmechanismen"},
                new Part { Name = "M5 Boutje", Description = "Bevestiging van panelen, buizen of interne modules"},
                new Part { Name = "Hydraulische cilinder", Description = "Openen/sluiten van zware luchtsluizen of bewegende onderdelen"},
                new Part { Name = "Koelvloeistofpomp", Description = "Koeling van de motor of elektronische systemen."}
            };
            context.Parts.AddRange(parts);

            context.SaveChanges();

            context.Database.EnsureCreated();
        }
    }
}
