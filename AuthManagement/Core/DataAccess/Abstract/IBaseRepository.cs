using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Abstract
{
    public interface IBaseRepository<T> where T : class, IEntity, new()
    {

        List<T> GetAll(Expression<Func<T, bool>> filter = null);//içerisinde ....geçenleri getir fonksiyonu

        T Get(Expression<Func<T, bool>> filter);//yukardakinin null olasın hali

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        bool Any(Expression<Func<T, bool>> exp);

    }
}
