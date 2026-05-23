using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingUygulamasi
{
    internal class Kullanici
    {
        private int _kullaniciID;
        private string _kullaniciAdi;
        private string _kullaniciSifresi;
        private int _verdigiOy;
        private bool _oyVerdiMi;

        public int KullaniciID { get => _kullaniciID; set => _kullaniciID = value; }
        public string KullaniciAdi { get => _kullaniciAdi; set => _kullaniciAdi = value; }
        public string KullaniciSifresi { get => _kullaniciSifresi; set => _kullaniciSifresi = value; }
        public int VerdigiOy { get => _verdigiOy; set => _verdigiOy = value; }
        public bool OyVerdiMi { get => _oyVerdiMi; set => _oyVerdiMi = value; }

        public Kullanici()
        {
        }
        
        

    }
}
