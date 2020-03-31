using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class Categorie
    {
        public Categorie()
        {
            Produits = new List<Produit>();
        }
        public int CategorieId { get; set; }
        public string NomCategorie { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public List<Produit> Produits { get; set; }
    }
}
