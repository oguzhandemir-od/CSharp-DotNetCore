using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fow45
{
    internal class Ucgen
    {
        private double _birinciKenar;
        private double _ikinciKenar;
        private double _ucuncuKenar;

        public double BirinciKenar { get => _birinciKenar; set => _birinciKenar = value; }
        public double IkinciKenar { get => _ikinciKenar; set => _ikinciKenar = value; }
        public double UcuncuKenar { get => _ucuncuKenar; set => _ucuncuKenar = value; }

        public Ucgen()
        {
            _birinciKenar = BirinciKenar;
            _ikinciKenar = IkinciKenar;
            _ucuncuKenar = UcuncuKenar;
        }

        

        public double CevreHesapla()
        {
            return BirinciKenar+IkinciKenar+UcuncuKenar;
        }

        public bool IkizkenarKontrol()
        {
            if (BirinciKenar==IkinciKenar || BirinciKenar==UcuncuKenar || IkinciKenar==UcuncuKenar)
            {
                return true;

            }
            else
                return false;
        }
    }
}
