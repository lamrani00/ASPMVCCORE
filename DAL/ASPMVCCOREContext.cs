using BLL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
   public class ASPMVCCOREContext : DbContext

    {
        public ASPMVCCOREContext(DbContextOptions<ASPMVCCOREContext> options) 
            :base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Produit> Produits { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CommandeDetail>().HasKey(s => new { s.ProduitId, s.CommandeId });
            modelBuilder.Entity<Categorie>().HasData(new Categorie { CategorieId = 1, NomCategorie = "Fruit pies",
                Description =
                    "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies."
           , ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/applepie.jpg"
            });
            modelBuilder.Entity<Categorie>().HasData(new Categorie { CategorieId = 2, Description = "Cheese cakes" });
            modelBuilder.Entity<Categorie>().HasData(new Categorie { CategorieId = 3, Description = "Seasonal pies" });
            modelBuilder.Entity<Produit>().HasData(new Produit
            {
                ProduitId = 1,
                Designation = "Apple Pie",
                Prix = 12.95,
                DateExpiration = DateTime.Parse( "23/03/2021"),
                QteStock = 100,
                CategorieId = 1        
            });
            modelBuilder.Entity<Produit>().HasData(new Produit
            {             
                ProduitId = 2,
                Designation = "Blueberry Cheese Cake",
                Prix = 20,
                DateExpiration = DateTime.Parse("12/02/2022"),
                QteStock = 50,
                CategorieId = 2
            });
            modelBuilder.Entity<Produit>().HasData(new Produit
            {
                ProduitId = 4,
                Designation = "Happy holidays with this pie",
                Prix = 70,
                DateExpiration = DateTime.Parse("16/10/2020"),
                QteStock = 300,
                CategorieId=1
            });
            modelBuilder.Entity<Produit>().HasData(new Produit
            {
                ProduitId = 5,
                Designation = "Happy holidays with this pie",
                Prix = 170,
                DateExpiration = DateTime.Parse("16/10/2020"),
                QteStock = 200,
                CategorieId = 3
            });
        }
    }
}
