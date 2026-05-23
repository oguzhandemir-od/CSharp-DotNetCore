using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uygulama9_Nesne
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ev evsnf = new Ev();
            evsnf.renk = "Mavi";
            evsnf.kat = "5";
            evsnf.yakit = 'D';
            evsnf.fiyat = 78000;

            label1.Text = "Renk: " + evsnf.renk;
            label2.Text = "Kat: " + evsnf.kat;
            label3.Text = "Yakıt Türü: " + evsnf.yakit.ToString();
            label4.Text = "Fiyat: " + evsnf.fiyat.ToString();

        }
    }
}
