using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uygulama10_Nesne
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ogrenci ogr = new Ogrenci();
            ogr.Ad = tb_Ad.Text;
            ogr.Soyad = tb_Soyad.Text;
            ogr.Kulup = tb_Kulup.Text;

            Notlar ntl = new Notlar();
            ntl.Sinav11 = Convert.ToInt32(tb_Sinav1.Text);
            ntl.Sinav21 = Convert.ToInt32(tb_Sinav2.Text);
            ntl.Sinav31 = Convert.ToInt32(tb_Sinav3.Text);
            ntl.Ortalama = (ntl.Sinav11 + ntl.Sinav21 + ntl.Sinav31) / 3;
            tb_Ortalama.Text = ntl.Ortalama.ToString();

            listBox1.Items.Add(ogr.Ad + " " + ogr.Soyad + " " + ogr.Kulup + " " + "Ortalama: " + ntl.Ortalama);




        }
    }
}
