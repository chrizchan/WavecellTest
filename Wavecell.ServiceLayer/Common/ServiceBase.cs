using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wavecell.Repository.Common;

namespace Wavecell.ServiceLayer.Common
{
    public class ServiceBase<T> : IService<T> where T : class
    {

        private readonly IRepository<T> _repository;

        protected ServiceBase(IRepository<T> repository)
        {
            _repository = repository;
        }

        public T Add(T entity)
        {
            if (IsValid(entity, Action.Create))
                _repository.Add(entity);

            return entity;

        }

        protected IRepository<T> Repository { get { return _repository; } }

        public T Get(Expression<Func<T, bool>> @where)
        {
            return _repository.Get(where);
        }

        public IList<T> GetAll()
        {
            var list = _repository.GetAll();
            return list;
        }

        public IList<T> GetMany(Expression<Func<T, bool>> @where)
        {
            return _repository.GetMany(where);
        }

        public T Update(T entity)
        {
            if (IsValid(entity, Action.Update))
                _repository.Update(entity);

            return entity;
        }

        #region Validation
        protected bool IsValid(T info, Action action, params string[] args)
        {
            if (ValidationDictionary == null)
                return true;

            var isValidData = ValidateData(info, action, args);

            if (isValidData)
            {
                //business rules should prompt one by one
                ValidateRules(info, action, args);
            }

            return isValidData;
        }

        //overridable
        protected virtual bool ValidateData(T info, Action action, params string[] args)
        {
            return true;
        }

        //overridable
        protected virtual void ValidateRules(T info, Action action, params string[] args)
        {
            //when overriden, this will throw exceptions
        }

        public enum Action
        {
            Create,
            Update,
            Delete,
            Custom
        }
        public IValidationDictionary ValidationDictionary { get; set; }

        #endregion

    }
}
