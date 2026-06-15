using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalPublishing.Domain.Entities
{
    public class Book:BaseEntity,IMustHaveTenant
    {
        protected Book() { }

        public Book(string isbn,int pageCount,int tenantId)
        {
            if(pageCount<0) throw new ArgumentOutOfRangeException(nameof(pageCount),"Sayfa sayısı 0 veya 0'dan küçük olamaz");
            if (string.IsNullOrEmpty(isbn)) throw new ArgumentNullException("ISBN boş olamaz");

            ISBN = isbn;
            PageCount = pageCount;
            TenantId = tenantId;
            IsDeleted = false;
            _bookTranslations= new List<BookTranslation>();
        }

        public string ISBN { get; private set; }
        public int PageCount { get; private set; }
        public bool IsDeleted { get; private set; }
        public int TenantId { get; private set; }

        private readonly List<BookTranslation> _bookTranslations;

        public IReadOnlyCollection<BookTranslation> BookTranslations => _bookTranslations.AsReadOnly();

        public void AddTranslation(BookTranslation translation)
        {
            if(translation == null) throw new ArgumentNullException(nameof(translation));

            if (_bookTranslations.Any(t => t.LanguageId == translation.LanguageId))
                throw new InvalidOperationException("Bu dildeki çeviri bu kitaba eklenmiş");

            _bookTranslations.Add(translation);
        }

        public void SoftDelete()
        {
            IsDeleted = true;
            foreach (var translation in _bookTranslations)
                translation.SoftDelete();
        }
    }
}
