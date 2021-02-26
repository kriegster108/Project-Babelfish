using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace TranslationStation.DataModel.Models.EF
{
    public interface IGenericDataRepository<T>
    {
        IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);
        IList<T> GetList(Func<T, bool> where, 
            params Expression<Func<T,object>>[] navigationProperties);
        T GetSingle(Func<T, bool> where,
            params Expression<Func<T, object>>[] navigationProperties);
        Task<IList<T>> GetAllAsync(params Expression<Func<T, object>>[] navigationProperties);
        //Task<IList<T>> GetListAsync(Func<T, bool> where, 
        //    params Expression<Func<T,object>>[] navigationProperties);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> @where,
            params Expression<Func<T, object>>[] navigationProperties);

    }

    public class GenericDataRepository<T> : IGenericDataRepository<T> where T : class
    {
        private readonly TranslationContext _translationContext;
        public GenericDataRepository(TranslationContext translationContext)
        {
            _translationContext = translationContext;
        }

        public virtual IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _translationContext.Set<T>();
 
                //Apply eager loading
                dbQuery = navigationProperties.Aggregate(dbQuery, (current, navigationProperty) => current.Include<T, object>(navigationProperty));

                var list = dbQuery
                    .AsNoTracking()
                    .ToList<T>();
            return list;
        }
 
        public virtual IList<T> GetList(Func<T, bool> where, 
             params Expression<Func<T,object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _translationContext.Set<T>();
                 
                //Apply eager loading
                dbQuery = navigationProperties.Aggregate(dbQuery, (current, navigationProperty) => current.Include<T, object>(navigationProperty));

                var list = dbQuery
                    .AsNoTracking().AsEnumerable()
                    .Where(@where)
                    .ToList<T>();
            return list;
        }
 
        public virtual T GetSingle(Func<T, bool> where,
             params Expression<Func<T, object>>[] navigationProperties)
        {
            T item = null;
            IQueryable<T> dbQuery = _translationContext.Set<T>();
             
            //Apply eager loading
            dbQuery = navigationProperties.Aggregate(dbQuery, (current, navigationProperty) => current.Include<T, object>(navigationProperty));

            item = dbQuery
                .AsNoTracking() //Don't track any changes for the selected item
                .FirstOrDefault(where); //Apply where clause
            return item;
        }

        public async Task<IList<T>> GetAllAsync(params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _translationContext.Set<T>();
 
            //Apply eager loading
            dbQuery = navigationProperties.Aggregate(dbQuery, (current, navigationProperty) => current.Include<T, object>(navigationProperty));

            var list = await dbQuery
                .AsNoTracking()
                .ToListAsync<T>();
            return list;
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> @where,
            params Expression<Func<T, object>>[] navigationProperties)
        {
            T item = null;
            IQueryable<T> dbQuery = _translationContext.Set<T>();
             
            //Apply eager loading
            dbQuery = navigationProperties.Aggregate(dbQuery, (current, navigationProperty) => current.Include<T, object>(navigationProperty));

            item = await dbQuery
                .AsNoTracking()
                .FirstOrDefaultAsync(where); //Apply where clause
            return item;
        }
    }
}
