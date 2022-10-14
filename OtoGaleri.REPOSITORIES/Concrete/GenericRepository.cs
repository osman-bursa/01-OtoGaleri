using OtoGaleri.ENTITIES.Entities;
using OtoGaleri.REPOSITORIES.Abstract;
using OtoGaleri.REPOSITORIES.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace OtoGaleri.REPOSITORIES.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly OtoGaleriDbContext _context;

        public GenericRepository(OtoGaleriDbContext context)
        {
            _context = context;
        }

        public bool Activate(int id)
        {
            T activated = GetByID(id);
            activated.AktifMi = true;
            return Update(activated);
        }

        public bool Add(T item)
        {
            // set for Magazalar, Kullanicilar, Araclar
            try
            {
                _context.Set<T>().Add(item);
                return Save() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Add(List<T> item)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    // checks the items transactions, if any of them is not added, then all the items need to be removed from the list. Similar to commit - rollback logic
                    _context.Set<T>().AddRange(item);
                    ts.Complete();

                    return Save() > 0;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Any( );
        }

        public List<T> GetActive()
        {
            return _context.Set<T>().Where(x => x.AktifMi == true).ToList();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetByDefault(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().FirstOrDefault(exp);
        }

        public T GetByID(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Where(exp).ToList();
        }

        public bool Remove(T item)
        {
            item.AktifMi = false;
            return Update(item); // instead of deleting from db, we deactivate the item
        }

        public bool Remove(int id)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    T item = GetByID(id);
                    item.AktifMi = false;
                    ts.Complete();
                    return Update(item);
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveAll(Expression<Func<T, bool>> exp)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var koleksiyon = GetDefault(exp);
                    int count = 0;

                    foreach (var item in koleksiyon)
                    {
                        item.AktifMi = false;
                        bool opResult = Update(item);
                        if (opResult) count++; // for each item check if the update is successful and increase count
                    }

                    if (koleksiyon.Count == count) ts.Complete();
                    else return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public bool Update(T item)
        {
            try
            {
                _context.Set<T>().Update(item);
                return Save() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
