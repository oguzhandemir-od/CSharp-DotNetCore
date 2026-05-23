using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uygulama16
{
    public partial class Form1 : Form
    {
        //void SayiGetir()
        //{
        //    Random rnd = new Random();
        //    int sayi;
        //    sayi = rnd.Next(100,1000);
        //    label1.Text = sayi.ToString();

        //}

        void HarfGetir()
        {
            Random rnd = new Random();
            string[] harfler = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
            int sayi;
            sayi = rnd.Next(0, harfler.Length);
            label1.Text = harfler[sayi].ToString();
        }
        public Form1()
        {
            InitializeComponent();
            //SayiGetir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SayiGetir();
            HarfGetir();
        }
    }
}
