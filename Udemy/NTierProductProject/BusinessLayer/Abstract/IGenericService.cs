using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        void TInsert(T entity);
        void TDelete(T entity);
        void TUpdate (T entity);
        List<T> TGetList();
        T TGetById(int id);
    }
}
