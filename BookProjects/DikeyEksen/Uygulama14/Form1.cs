using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uygulama14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int sayac =0;
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            label2.Text = sayac.ToString();
            if(sayac>=0&&sayac<=30)
            {
                this.BackColor = Color.Red;
            }
            if(sayac>30&&sayac<=40)
            {
                this.BackColor = Color.Yellow;
            }
            if(sayac>40&&sayac<=70)
            {
                this.BackColor = Color.Green;
            }
            if(sayac==71)
            {
                sayac = 0;
            }

        }
    }
}
