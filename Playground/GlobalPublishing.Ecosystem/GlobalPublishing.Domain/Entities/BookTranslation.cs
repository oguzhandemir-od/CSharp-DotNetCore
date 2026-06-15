using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalPublishing.Domain.Entities
{
    public class BookTranslation:BaseEntity,IMustHaveTenant
    {
        protected BookTranslation() { }

        public BookTranslation(int bookId,int languageId,string title, string description,int tenantId)
        {
            if (title == null) throw new ArgumentNullException(nameof(title),"Başlık boş olamaz");
            if (description == null) throw new ArgumentNullException(nameof(description),"Açıklama boş olamaz");

            BookId = bookId;
            LanguageId = languageId;
            Title = title;
            Description = description;
            TenantId=tenantId;
        }

        public int BookId { get; set; }
        public int LanguageId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; private set; }
        public int TenantId { get; private set; }

        public void SoftDelete()
        {
            IsDeleted = true;
        }
    }
}
