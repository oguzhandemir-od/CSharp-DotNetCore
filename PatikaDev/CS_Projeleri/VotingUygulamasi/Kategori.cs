using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingUygulamasi
{
    internal class Kategori
    {
        private int _kategoriID;
        private string _kategoriAdi;
        private int _oySayisi;
        private double _oyYuzdesi;
        private List<Kategori> _kategoriList;
        private static Kategori _kategori;

        public string KategoriAdi { get => _kategoriAdi; set => _kategoriAdi = value; }
        public int OySayisi { get => _oySayisi; set => _oySayisi = value; }
        public double OyYuzdesi { get => _oyYuzdesi; set => _oyYuzdesi = value; }
        public List<Kategori> KategoriList { get => _kategoriList; set => _kategoriList = value; }

        public static Kategori Basla()
        {
            if (_kategori == null)
                _kategori = new Kategori();
            return _kategori;
        }

        public Kategori()
        {
            
        }
    }
}
