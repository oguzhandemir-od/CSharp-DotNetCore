using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalPublishing.Domain.Entities
{
    public class Tenant:BaseEntity
    {
        protected Tenant() { }

        public Tenant(string name, string code)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("Yayınevi adı boş olamaz",nameof(name));
            if (string.IsNullOrEmpty(code)) throw new ArgumentNullException("Yayınevi kodu boş olamaz", nameof(code));

            Name = name;
            Code = code;
            IsActive=true;
        }

        public string Name { get; private set; }
        public string Code { get; private set; }
        public bool IsActive { get; private set; }

        public void Deactivate()
        {
            IsActive = false;
        }
    }
}
