using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Automation_v2.Models;
using System.Linq.Expressions;
using System.Data;
using System.Data.Entity;

namespace Automation_v2.DAL
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
         IEnumerable<TEntity> Get(
             Expression<Func<TEntity, bool>> filter = null,
             Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
             string includeProperties = "");
         TEntity GetById(object id);
         void Insert(TEntity entity);
         void Delete(object id);
         void Delete(TEntity entityToDelete);
         void Update(TEntity entityToUpdate);
    }
}