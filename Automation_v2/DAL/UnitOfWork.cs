using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Automation_v2.Models;
using System.Data;
using System.Data.Entity;

namespace Automation_v2.DAL
{
    public class UnitOfWork : IDisposable
    {
        private Automation_v2_DBContext context = new Automation_v2_DBContext();
        private Dictionary<Type, object> _repositories = new Dictionary<Type,object>();

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            // Checks if the Dictionary Key contains the Model class
            if (_repositories.Keys.Contains(typeof(TEntity)))
            {
                // Return the repository for that Model class
                return _repositories[typeof(TEntity)] as IGenericRepository<TEntity>;
            }

            // If the repository for that Model class does not exist, then CREATE it
            var repository = new GenericRepository<TEntity>(context);

            // Add it to the dictionary
            _repositories.Add(typeof(TEntity), repository);

            return repository;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}