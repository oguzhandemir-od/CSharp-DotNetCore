using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Abstract
{
    // IGenericRepository
    public interface IGenericDal<T> where T : class
    {
        void Insert(T item);
        void Delete(T item);
        void Update(T item);
        List<T> GetList();
        T GetById(int id);
    }
}
