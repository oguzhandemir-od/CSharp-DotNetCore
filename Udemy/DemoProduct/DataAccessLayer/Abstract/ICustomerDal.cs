using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace DataAccessLayer.Abstract
{
    // ICustomerRepository
    public interface ICustomerDal : IGenericDal<Customer>
    {

    }
}
