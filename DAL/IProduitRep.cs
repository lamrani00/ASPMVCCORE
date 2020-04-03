using BLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
   public interface IProduitRep : IRepository<Produit>
    {
        IEnumerable<Produit> ProduitAvecCategorie(int pageindex, int pagesize);
    }
}
