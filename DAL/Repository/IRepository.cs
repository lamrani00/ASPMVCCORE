using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL
{
   public interface IRepository <TEntity> where TEntity : class
    {
        void Add(TEntity nouveau);
        IEnumerable<TEntity> Listes();
        TEntity Trouver(Expression<Func<TEntity,bool>> expression);
        TEntity Trouverparind (int id);
        void Supprimer (int id);
        void modifier(TEntity Amodifier);
        void Supprimer(Expression<Func<TEntity, bool>> where);
        IQueryable<TEntity> GetManyQueryable(Func<TEntity, bool> where);
        IQueryable<TEntity> GetWithInclude(Expression<Func<TEntity, bool>> predicate, params string[] include);
        void Reload(TEntity entity);

    }
}
