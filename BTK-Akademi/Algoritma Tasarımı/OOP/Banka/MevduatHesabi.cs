using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Banka
{
    public class MevduatHesabi : IBankaHesap
    {
        private decimal _bakiye;
        public decimal Bakiye => _bakiye;
        
        public bool Cek(decimal miktar)
        {
            if (_bakiye>=miktar)
            {
                _bakiye -= miktar;
                return true;
            }
            Console.WriteLine("\a Bakiye yetersiz!");
            return false;
        }

        public void Yatir(decimal miktar) => _bakiye += miktar;

        public override string ToString() => $"Mevduat hesabı bakiye bilgisi: {_bakiye,6:C}";
        
    }
}
