using BLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    /// <summary>
    /// cette interface me pemet d'ajouter des méthodes spéciales
    /// </summary>
    public interface ICategorieRep :IRepository<Categorie>
    {
        IEnumerable<Categorie> CategoriesparProduit(int pageindex, int pagesize);
    }
}