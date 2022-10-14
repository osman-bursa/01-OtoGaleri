using OtoGaleri.ENTITIES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OtoGaleri.REPOSITORIES.Abstract
{
    // BaseEntity den miras alanlar buraya uygundur. where T : class da iş görür fakat convention bir base entity kullanmaktır.
    public interface IGenericRepository<T> where T : BaseEntity
    {
        bool Add(T item);
        bool Add(List<T> item);
        bool Update(T item);
        bool Remove(T item);
        bool Remove(int id);
        bool RemoveAll(Expression<Func<T, bool>> exp);
        T GetByID(int id);
        T GetByDefault(Expression<Func<T, bool>> exp);
        List<T> GetActive();
        List<T> GetDefault(Expression<Func<T, bool>> exp);
        List<T> GetAll();
        bool Activate(int id);
        bool Any(Expression<Func<T, bool>> exp);
        int Save();
    }
}
