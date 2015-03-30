using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wavecell.DataAccess;
using Wavecell.Entities;

namespace Wavecell.Repository.Common
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : EntityBase
    {
       protected virtual IQueryable<T> DbSet { get; private set; }

        protected RepositoryBase()
        {
            Db = new WavecellDbContext();            
            DbSet = Db.Set<T>().AsNoTracking();            
        }
        public WavecellDbContext Db { get; set; }

        public T Add(T entity)
        {
            Db.Set<T>().Add(entity);
            Db.SaveChanges();
            
            return entity;
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return DbSet.Where(where).FirstOrDefault();
        }

        public IList<T> GetAll()
        {
            return DbSet.ToList();
        }
        public IList<T> GetMany(Expression<Func<T, bool>> where)
        {
            return DbSet.Where(where).ToList();
        }

        public T Update(T entity)
        {
            var originalValues = Db.Set<T>().Find(entity.Id);
            Db.Entry(originalValues).CurrentValues.SetValues(entity);
            try
            {
                Db.SaveChanges();
            }
            catch (Exception ex)
            {
                var x = ((System.Data.Entity.Validation.DbEntityValidationException)ex).EntityValidationErrors;
            }
            return entity;
        }
    }
}
