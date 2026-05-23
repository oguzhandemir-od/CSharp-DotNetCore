using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class Hayvanlar:Canlilar
    {
        protected void Adaptasyon()
        {
            Console.WriteLine("Hayvanlar adaptasyon kurabilir");
        }


    }

    public class Surungenler:Hayvanlar
    {
        public Surungenler()
        {
            base.Adaptasyon();
            base.Beslenme();
            base.Bosaltim();
            base.Solunum();
        }
        public void SurunerekHareket()
        {
            Console.WriteLine("Sürüngenler sürünerek hareket eder");
        }

        public override void UyaranaTepki()
        {
            base.UyaranaTepki();
            Console.WriteLine("Hayvanlar temasa tepki verir");
        }

    }

    public class Kuslar:Hayvanlar
    {
        public Kuslar()
        {
            base.Adaptasyon();
            base.Beslenme();
            base.Bosaltim();
            base.Solunum();
            base.UyaranaTepki();
        }
        public void Ucmak()
        {
            Console.WriteLine("Kuşlar uçar");
        }
    }
}
