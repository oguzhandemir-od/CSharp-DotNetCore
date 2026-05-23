using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uygulama18
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Button btn = new Button();
            btn.Name = "Button1";
            btn.Text = "Tıklayın";
            btn.Location = new Point(50, 120);
            btn.Height = 50;
            btn.Width = 100;
            this.Controls.Add(btn);

            for(int i=1;i<=10;i++)
            {
                Label lbl = new Label();
                lbl.Name = "Label" + i;
                lbl.Text = "Label" + i;
                lbl.Location = new Point(20, i * 30);
                this.Controls.Add(lbl);
            }
        }
        int sayac = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            //pictureBox1.Location = new Point(100, 75);
            timer1.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac += 10;
            pictureBox1.Location = new Point(100, sayac);
        }
    }
}
