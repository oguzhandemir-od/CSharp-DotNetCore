using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uygulama5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sehir1, sehir2, sehir3;
            sehir1 = "Ankara - Mamak";
            sehir2 = "Bursa - Osmangazi";
            sehir3 = "İzmir - Karşıyaka";
            listBox1.Items.Add(sehir1);
            listBox1.Items.Add(sehir2);
            listBox1.Items.Add(sehir3);
        }
    }
}
