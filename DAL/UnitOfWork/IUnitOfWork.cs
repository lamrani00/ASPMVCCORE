using Microsoft.EntityFrameworkCore;
using System;
namespace DAL
{
    // déclaration les méthodes qui servent à valider les transactions
    public interface IUnitOfWork : IDisposable
    {
       
 
        // cette interface pour généraliser l'implimentation sur tous les services 
        IRepository<T> Repository<T>() where T : class;
        /// <summary>
        /// il joue le role de comit 
        /// </summary>
        /// <returns></returns>
        int complete();
    }
    public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        TContext Context { get; }
    }
}
