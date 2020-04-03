using BLL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DAL
{
    public class CategorieRep : Repository<Categorie>, ICategorieRep
    {
        public ASPMVCCOREContext context
        {
            get { return context as ASPMVCCOREContext; }
        } 

        public CategorieRep(ASPMVCCOREContext context)
            :base(context)
        {

        }
        /// <summary>
        ///  cette méthode joue le role de pagination
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public IEnumerable<Categorie> CategoriesparProduit(int pageindex, int pagesize=10)
        {
            return context.Categories.Include(c => c.Produits)
                .Skip((pageindex - 1) * pagesize)
                .Take(pagesize).ToList();
               

        }
    }
}
