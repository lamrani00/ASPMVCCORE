using System;
using System.Collections.Generic;

namespace BLL
{
    public class Produit
    {
        public int ProduitId { get; set; }
        public string Designation { get; set; }
        public double Prix { get; set; }
        public DateTime DateExpiration { get; set; }
        public int QteStock { get; set; }
        public int CategorieId { get; set; }
        public Categorie Categorie { get; set; }
        public List<CommandeDetail> commandeDetails { get; set; }
    }
}
