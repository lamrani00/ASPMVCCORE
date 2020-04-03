using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DAL
{
    public class Repository <T> : IRepository<T> where T : class
    {

        internal readonly DbContext _dbcontext;
        /// <summary>
        /// Public Constructor,initializes privately declared local variables.
        /// </summary>
        /// <param name="context"></param>
        public Repository(DbContext context)
        {
            _dbcontext = context;
        }


        #region les Méthodes
    public void Add(T Aajouter)
        {
            _dbcontext.Set<T>().Add(Aajouter);
        }



        public IQueryable<T> GetManyQueryable(Func<T, bool> where)
        {
            return _dbcontext.Set<T>().Where(where).AsQueryable();
        }


        // il faut que je revise  cette méthode
        public IQueryable<T> GetWithInclude(Expression<Func<T, bool>> predicate, params string[] include)
        {
            IQueryable<T> query = _dbcontext.Set<T>();
            query = include.Aggregate(query, (current, inc) => current.Include(inc));
            return query.Where(predicate);
        }

        public IEnumerable<T> Listes()
        {
            return _dbcontext.Set<T>().ToList();
        }

        public void modifier(T Amodifier)
        {
            _dbcontext.Set<T>().Attach(Amodifier);
            _dbcontext.Entry(Amodifier).State = EntityState.Modified;
        }

        public void Reload(T Tentity)
        {
            _dbcontext.Entry(Tentity).Reload();
        }

        public void Supprimer(int id)
        {
            var asup = Trouverparind(id);
            _dbcontext.Set<T>().Remove(asup);
        }



        public void Supprimer(Expression<Func<T, bool>> where)
        {
            var asup = Trouver(where);
            _dbcontext.Set<T>().Remove(asup);
        }

        public T Trouver(Expression<Func<T, bool>> expression)
        {
            return _dbcontext.Set<T>().Where(expression).SingleOrDefault();
        }


        public T Trouverparind(int id)
        {
            return _dbcontext.Set<T>().Find(id);
        }
        #endregion




    }
}
