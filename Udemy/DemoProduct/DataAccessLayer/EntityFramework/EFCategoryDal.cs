using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityFramework
{
    public class EFCategoryDal:GenericDal<Category>,ICategoryDal
    {
        public EFCategoryDal(AppDbContext context) : base(context)
        {

        }
    }
}
