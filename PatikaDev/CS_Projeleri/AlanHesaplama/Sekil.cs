using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AlanHesaplama
{
    internal abstract class Sekil
    {
        #region Soyut Hesaplama Metotları
        public abstract double CevreHesapla();
        public abstract double AlanHesapla();
        public abstract double HacimHesapla();
        public abstract void Prizma();
        #endregion
    }
}
