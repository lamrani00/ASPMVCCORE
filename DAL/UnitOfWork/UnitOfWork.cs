using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ASPMVCCOREContext Context;

     //   public ASPMVCCOREContext Context { get; }

        /// <summary>
        ///  Attention dans le pattern de UoW Generic, le context était  passé en parametre
        /// </summary>
        /// <param name="_context"></param>

        public UnitOfWork(ASPMVCCOREContext dContext) 
        {
            Context = dContext;
            //categories = new CategorieRep(context);
            //produits = new ProduitRep(context);
        }
        //public ICategorieRep categories { get; set; }

        //public IProduitRep produits { get; set; }

            // j'ai remplaçé les implimentation ci-dessous afin de factoriser et éviter d'ajouter trop de ligne du code.
      public IRepository<T> Repository<T>() where T : class
        {
         return new Repository<T> (Context) ;
        }

        public int complete()
        {
            return Context.SaveChanges();
        }




          #region Dispose

           private bool disposed = false;



        //public void Dispose()
        //{
        // context.Dispose();
        //}

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
           {
               if (!disposed && disposing)
               {
                   Context.Dispose();
               }
               this.disposed = true;
           }

           /// <summary>
           /// Dispose method 
           /// </summary>
           public void Dispose()
           {
               Dispose(true);
               GC.SuppressFinalize(this);
           }

           #endregion







        /*
         
           public Dictionary<Type, object> repositories = new Dictionary<Type, object>();

           public IRepository<T> Repository<T>() where T : class
           {
               if (repositories.Keys.Contains(typeof(T)))
               {
                   return repositories[typeof(T)] as IRepository<T>;
               }

               IRepository<T> repo = new GenericRepository<T>(Context);
               repositories.Add(typeof(T), repo);
               return repo;
           }         
    
            */
    }
}
