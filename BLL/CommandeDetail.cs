using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
   public class CommandeDetail
    {
        public int CommandeId { get; set; }
        public Commande Commande { get; set; }
        public int ProduitId { get; set; }
        public Produit Produit { get; set; }
        public int Somme { get; set; }

  
    }
}
