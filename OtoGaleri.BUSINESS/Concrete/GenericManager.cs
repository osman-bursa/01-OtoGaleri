﻿using OtoGaleri.BUSINESS.Abstract;
using OtoGaleri.ENTITIES.Entities;
using OtoGaleri.REPOSITORIES.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OtoGaleri.BUSINESS.Concrete
{
    public class GenericManager<T> : IGenericService<T> where T : BaseEntity
    {
        private readonly IGenericRepository<T> _repository;

        public GenericManager(IGenericRepository<T> repository)
        {
            _repository = repository;
        }
        public bool Activate(int id)
        {
            if (id == 0 || GetByID(id) == null)
                return false;
            else
                return _repository.Activate(id);
        }

        public bool Add(T item)
        {
            return _repository.Add(item);
        }

        public bool Add(List<T> item)
        {
            return _repository.Add(item);
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return _repository.Any(exp);
        }

        public List<T> GetActive()
        {
            return _repository.GetActive();
        }

        public List<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetByDefault(Expression<Func<T, bool>> exp)
        {
            return _repository.GetByDefault(exp);
        }

        public T GetByID(int id)
        {
            return _repository.GetByID(id);
        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            return _repository.GetDefault(exp);
        }

        public bool Remove(T item)
        {
            if (item == null)
                return false;

            return _repository.Remove(item);
        }

        public bool Remove(int id)
        {
            if (id <= 0)
                return false;
            else
                return _repository.Remove(id);
        }

        public bool RemoveAll(Expression<Func<T, bool>> exp)
        {
            return _repository.RemoveAll(exp);
        }

        public bool Update(T item)
        {
            if (item == null)
                return false;
            else
                return _repository.Update(item);
        }
    }
}
