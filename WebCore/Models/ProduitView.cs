using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Models
{
    public class ProduitView
    {
        private readonly IUnitOfWork unitOfWork;
        public IEnumerable<Produit> produits {get; set;}

        public ProduitView(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;            
        }

       public void all ()
        {           
            produits = unitOfWork.Repository<Produit>().Listes();
        }
       
    }
}
