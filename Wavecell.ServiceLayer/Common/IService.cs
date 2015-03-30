using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Wavecell.ServiceLayer.Common
{
    public interface IService<T>
    {
        T Get(Expression<Func<T, bool>> where);
        IList<T> GetAll();
        IList<T> GetMany(Expression<Func<T, bool>> where);
        T Update(T entity);
        T Add(T entity);
        IValidationDictionary ValidationDictionary { get; set; }
    }
}
