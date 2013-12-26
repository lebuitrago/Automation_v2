using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Web;
using Automation_v2.Models;
using System.Linq.Expressions;

namespace Automation_v2.DAL
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal Automation_v2_DBContext context;
        internal DbSet<TEntity> dbSet;

        // Constructor accepts a database context instance & initializes the entity set variable
        public GenericRepository(Automation_v2_DBContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        /// <summary>
        /// The Get method uses lambda expressions
        /// </summary>
        /// <param name="filter"> Allows the calling code to specify a filter condition</param>
        /// 
        /// The code Expression<Func<TEntity, bool>> filter means the caller will provide a lambda expression based on the TEntity type, 
        /// and this expression will return a Boolean value. For example, if the repository is instantiated for the Student entity type, 
        /// the code in the calling method might specify student => student.LastName == "Smith" for the filter parameter. 

        /// <param name="orderBy"> Allows the calling code to specify a column to order the results by</param>
        /// 
        /// The code Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy also means the caller will provide a lambda expression. 
        /// But in this case, the input to the expression is an IQueryable object for the TEntity type. The expression will return an ordered 
        /// version of that IQueryable object. For example, if the repository is instantiated for the Student entity type, the code in the 
        /// calling method might specify q => q.OrderBy(s => s.LastName) for the orderBy parameter.

        /// <param name="includeProperties"> Lets the caller provide a comma-delimited list of navigation properties for eager loading</param>
        /// 
        /// <returns>Ordered or UnOrdered List</returns>
        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            // Create an IQueryable object
            IQueryable<TEntity> query = dbSet;

            // FILTER
            if (filter != null)
            {
                // Apply the filter expression
                query = query.Where(filter);
            }

            // INCLUDEPROPERTIES
            // Parse the comma-delimited list
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                // Apply the eager-loading expressions
                query = query.Include(includeProperty);
            }

            // ORDERBY
            if (orderBy != null)
            {
                // Apply the orderBy expression
                return orderBy(query).ToList();
            }
            else
            {
                // Return results from the unordered query
                return query.ToList();
            }
        }

        /// <summary>
        /// No need to provide an eager loading parameter in the GetByID signature, because you can't do eager loading 
        /// with the Find method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TEntity GetById(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}