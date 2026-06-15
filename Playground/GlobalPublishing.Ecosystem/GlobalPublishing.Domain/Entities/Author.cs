using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalPublishing.Domain.Entities
{
    public class Author:BaseEntity,IMustHaveTenant
    {
        protected Author() { }

        public Author(string firstName,string lastName,int tenantId)
        {
            if (string.IsNullOrEmpty(firstName)) throw new ArgumentException("İsim boş olamaz");
            if (string.IsNullOrEmpty(lastName)) throw new ArgumentException("Soyisim boş olamaz");

            FirstName = firstName;
            LastName = lastName;
            TenantId = tenantId;
            IsDeleted = false;
            _books = new List<Book>();

        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public bool IsDeleted { get; private set; }
        public int TenantId { get; private set; }

        private readonly List<Book> _books;

        public IReadOnlyCollection<Book> Books=>_books.AsReadOnly();

        public void AddBook(Book book)
        {
            if (book== null) throw new ArgumentNullException(nameof(book));

            if (_books.Any(b => b.ISBN == book.ISBN))
                throw new InvalidOperationException("Bu kitap zaten yazara eklenmiş.");

            _books.Add(book);
        }

        public void SoftDelete()
        {
            IsDeleted = true;
        }
    }
}
