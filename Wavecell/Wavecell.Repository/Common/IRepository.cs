using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Wavecell.Repository.Common
{
    public interface IRepository<T>
    {
        T Add(T entity);
        T Get (Expression<Func<T,bool>> where);
        IList<T> GetAll();
        IList<T> GetMany(Expression<Func<T, bool>> where);

        T Update(T entity);
    }
}
