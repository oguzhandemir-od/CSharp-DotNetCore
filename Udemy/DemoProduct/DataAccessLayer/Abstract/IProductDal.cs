using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Abstract
{
    // IProductRepository
    public interface IProductDal:IGenericDal<Product>
    {
    }
}
