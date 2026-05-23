using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Kitap_Kayıt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source = DESKTOP-696IELN; Initial Catalog = KitapVt; Integrated Security = True");
        private void btn_Listele_Click(object sender, EventArgs e)
        {
            Listele();
            Turler();
        }

        void Listele()
        {
            SqlCommand komut = new SqlCommand("Select KitapId,KitapAd, Yazar,Sayfa, Fiyat,Yayinevi,TurAd From TblKitaplar inner join TblTurler on TblKitaplar.Tur=TblTurler.TurId", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        void Turler()
        {
            SqlCommand komut = new SqlCommand("Select * From TblTurler", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmb_Tur.ValueMember = "TurId";
            cmb_Tur.DisplayMember = "TurAd";
            cmb_Tur.DataSource = dt;
            
        }

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutekle = new SqlCommand("insert into TblKitaplar(KitapAd,Yazar,Sayfa,Fiyat,Yayinevi,Tur) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komutekle.Parameters.AddWithValue("@p1", txt_Ad.Text);
            komutekle.Parameters.AddWithValue("@p2", txt_Yazar.Text);
            komutekle.Parameters.AddWithValue("@p3", txt_Sayfa.Text);
            komutekle.Parameters.AddWithValue("@p4", txt_Fiyat.Text);
            komutekle.Parameters.AddWithValue("@p5", txt_Yayinevi.Text);
            komutekle.Parameters.AddWithValue("@p6", cmb_Tur.SelectedIndex);
            komutekle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kitap veritabanına eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_ID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_Ad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_Yazar.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_Sayfa.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txt_Fiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txt_Yayinevi.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

        }

        private void btn_Sil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete From TblKitaplar where KitapId=@p1", baglanti);
            komutsil.Parameters.AddWithValue("@p1", txt_ID.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kitap veritabanından silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Listele();

        }

        private void btn_Guncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("Update TblKitaplar set KitapAd=@p1,Yazar=@p2,Sayfa=@p3,Fiyat=@p4,Yayinevi=@p5,Tur=@p6 where KitapId=@p7", baglanti);
            komutguncelle.Parameters.AddWithValue("@p1", txt_Ad.Text);
            komutguncelle.Parameters.AddWithValue("@p2", txt_Yazar.Text);
            komutguncelle.Parameters.AddWithValue("@p3", txt_Sayfa.Text);
            komutguncelle.Parameters.AddWithValue("@p4", txt_Fiyat.Text);
            komutguncelle.Parameters.AddWithValue("@p5", txt_Yayinevi.Text);
            komutguncelle.Parameters.AddWithValue("@p6", cmb_Tur.SelectedIndex);
            komutguncelle.Parameters.AddWithValue("@p7", txt_ID.Text);
            komutguncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kitap bilgisi güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            Listele();
        }
    }
}
