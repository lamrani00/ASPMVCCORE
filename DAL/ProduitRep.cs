using BLL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ProduitRep : Repository<Produit>, IProduitRep
    {
        public ASPMVCCOREContext context { get { return context as ASPMVCCOREContext; } }




        public ProduitRep(ASPMVCCOREContext context ) :base(context)
        {
            
        }
        public IEnumerable<Produit> ProduitAvecCategorie(int pageindex, int pagesize)
        {
            return context.Produits.Include(c => c.Categorie)
            .Skip((pageindex - 1) * pagesize)
            .Take(pagesize).ToList();
        }
    }
}
