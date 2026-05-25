using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repositories
{
    // GenericRepository
    public class GenericDal<T> : IGenericDal<T> where T : class
    {
        private readonly AppDbContext _context;

        public GenericDal(AppDbContext context)
        {
            _context = context;
        }

        public void Delete(T item)
        {
            _context.Remove(item);
            _context.SaveChanges();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            return _context.Set<T>().ToList();
        }

        public void Insert(T item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public void Update(T item)
        {
            _context.Update(item);
            _context.SaveChanges();
        }
    }
}
