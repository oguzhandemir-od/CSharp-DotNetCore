using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Modelleme
{
    public class Arac:Tasit
    {
        #region Fields
        private string marka, model, renk;
        private int yil;
        #endregion

        #region Properties
        public string Marka
        {
            get
            {
                return marka;
            }

            set
            {
                marka = value;
            }
        }

        public string Model
        {
            get
            {
                return model;
            }

            set
            {
                model = value;
            }
        }

        public string Renk
        {
            get
            {
                return renk;
            }

            set
            {
                renk = value;
            }
        }

        public int Yil
        {
            get
            {
                return yil;
            }

            set
            {
                yil = value;
            }
        }
        #endregion

        #region Constructors
        public Arac()
        {

        }

        public Arac(string marka,string model,string renk,int yil)
        {
            Marka = marka;
            Model = model;
            Renk = renk;
            Yil = yil;
        }


        #endregion

        #region Methods
        public void Calistir() => Console.WriteLine("Araç çalıştı.");

        public void Durdur() => Console.WriteLine("Araç durduruldu.");

        public override string ToString()
        {
            Console.WriteLine(new string('-', 30));
            Console.WriteLine($"{Marka}");
            Console.WriteLine($"{Model}");
            Console.WriteLine($"{Renk}");
            Console.WriteLine($"{Yil}");
            Console.WriteLine($"{Motor}");
            Console.WriteLine($"{Hacim}");
            Console.WriteLine("");
            return "";
        }
        #endregion


    }
}
