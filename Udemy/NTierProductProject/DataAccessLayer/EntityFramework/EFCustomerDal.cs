using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityFramework
{
    public class EFCustomerDal:GenericDal<Customer>,ICustomerDal
    {
        public EFCustomerDal(AppDbContext context) : base(context)
        {

        }
    }
}
