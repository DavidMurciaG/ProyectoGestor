using ProyectoGestor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGestor.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();
            //Si provincia contiene algo 
            if (context.Provinces.Any())
            {
                return;//Es que la base de datos esta inicializada por lo cual no devolvemos nada
            }

            //Provincias
            var provinces = new Province[]
            {
                new Province{Name="Huesca"},
                new Province{Name="Teruel"},
                new Province{Name="Zaragoza"}
            };

            foreach (Province pr in provinces)
            {
                context.Provinces.Add(pr);
            }
            context.SaveChanges();

            //Localidades
            var localities = new Locality[]
            {
                new Locality{Name="Monzon" , ProvinceID=provinces.Single(i=>i.Name == "Huesca").ID},
                new Locality{Name="Huesca" , ProvinceID=provinces.Single(i=>i.Name == "Huesca").ID},
                new Locality{Name="Teruel", ProvinceID=provinces.Single(i =>i.Name == "Teruel").ID},
                new Locality{Name="Alcañiz", ProvinceID=provinces.Single(i =>i.Name == "Teruel").ID},
                new Locality{Name="Zaragoza", ProvinceID=provinces.Single(i=>i.Name == "Zaragoza").ID},
                new Locality{Name="Utebo", ProvinceID=provinces.Single(i=>i.Name == "Zaragoza").ID}
            };

            foreach (Locality l in localities)
            {
                context.Localities.Add(l);
            }
            context.SaveChanges();

            //Clientes
            var clients = new Client[]
            {
                new Client{Name="Oliver", LastName="Sanchis", Email="Osanchis@gmail.com", PhoneNumber="647566919", CIF="A-12345678", Address="Calle España", LocalityID=localities.Single(s=>s.Name=="Huesca").ID},
                new Client{Name="Ainoa", LastName="Cortes", Email="Acortes@gmail.com", PhoneNumber="645546119", CIF="A-12333678", Address="Calle Cadiz", LocalityID=localities.Single(s=>s.Name=="Utebo").ID},
                new Client{Name="Saul", LastName="Benito", Email="Sbenito@gmail.com", PhoneNumber="644446119", CIF="A-12222678", Address="Av Madrid", LocalityID=localities.Single(s=>s.Name=="Alcañiz").ID},
            };

            foreach (Client c in clients)
            {
                context.Clients.Add(c);
            }
            context.SaveChanges();

            //Categorias
            var productCategories = new ProductCategory[]
            {
                new ProductCategory{Category="Bobinas"},
                new ProductCategory{Category="Condensadores"},
                new ProductCategory{Category="Diodos"}
            };

            foreach (ProductCategory pc in productCategories)
            {
                context.ProductCategories.Add(pc);
            }
            context.SaveChanges();

            //Productos
            var products = new Product[]
            {
                new Product{Name="HELLA 5DA 749 475-601 Bobina de encendido", Price=117.33f, Description="Bobina de encendido", ProductCategoryID=productCategories.Single(a =>a.Category=="Bobinas").ID},
                new Product{Name="CONDENSADOR - COD. AFT - 87317242", Price=866.67f, Description="", ProductCategoryID=productCategories.Single(a =>a.Category=="Condensadores").ID},

            };

            foreach (Product p in products)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();

            //Pedidos
            var orders = new Order[]
            {
                //new Order{NumOrder="P1", Date=DateTime.Parse("01-09-2020"), ClientID=clients.Single(b=>b.Name=="Oliver").ID}
                //ProductID=products.Single(d=>d.Name=="HELLA 5DA 749 475-601 Bobina de encendido").ID
                new Order{OrderID=1, Date=DateTime.Parse("01-09-2020"), ClientID=clients.Single(b=>b.Name=="Oliver").ID},
                new Order{OrderID=2, Date=DateTime.Parse("03-09-2020"), ClientID=clients.Single(b=>b.Name=="Saul").ID},
            };

            foreach (Order o in orders)
            {
                context.Orders.Add(o);
            }
            context.SaveChanges();

            //Facturas
            var invoices = new Invoice[]
            {
                new Invoice{NumInvoice="F1", Cost=117.33f, IsPaid=false, OrderID=1}
            };

            foreach (Invoice i in invoices)
            {
                context.Invoices.Add(i);
            }
            context.SaveChanges();

            //PedidosProductos
            var orderProducts = new OrderProduct[]
            {
                new OrderProduct{OrderID=1, ProductID = products.Single(p => p.Name=="HELLA 5DA 749 475-601 Bobina de encendido").ID},
                new OrderProduct{OrderID=2, ProductID = products.Single(p => p.Name=="CONDENSADOR - COD. AFT - 87317242").ID}

            };

            foreach (OrderProduct op in orderProducts)
            {
                context.OrderProducts.Add(op);
            }
            context.SaveChanges();
        }
    }
}
