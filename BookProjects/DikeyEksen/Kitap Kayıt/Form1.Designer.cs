namespace Kitap_Kayıt
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_ID = new System.Windows.Forms.Label();
            this.lbl_Ad = new System.Windows.Forms.Label();
            this.lbl_Yazar = new System.Windows.Forms.Label();
            this.lbl_Sayfa = new System.Windows.Forms.Label();
            this.lbl_Fiyat = new System.Windows.Forms.Label();
            this.lbl_Yayinevi = new System.Windows.Forms.Label();
            this.lbl_Tur = new System.Windows.Forms.Label();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.txt_Ad = new System.Windows.Forms.TextBox();
            this.txt_Yazar = new System.Windows.Forms.TextBox();
            this.txt_Sayfa = new System.Windows.Forms.TextBox();
            this.txt_Fiyat = new System.Windows.Forms.TextBox();
            this.txt_Yayinevi = new System.Windows.Forms.TextBox();
            this.cmb_Tur = new System.Windows.Forms.ComboBox();
            this.btn_Listele = new System.Windows.Forms.Button();
            this.btn_Kaydet = new System.Windows.Forms.Button();
            this.btn_Sil = new System.Windows.Forms.Button();
            this.btn_Guncelle = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_ID
            // 
            this.lbl_ID.AutoSize = true;
            this.lbl_ID.Location = new System.Drawing.Point(21, 19);
            this.lbl_ID.Name = "lbl_ID";
            this.lbl_ID.Size = new System.Drawing.Size(87, 25);
            this.lbl_ID.TabIndex = 0;
            this.lbl_ID.Text = "Kitap ID:";
            // 
            // lbl_Ad
            // 
            this.lbl_Ad.AutoSize = true;
            this.lbl_Ad.Location = new System.Drawing.Point(11, 56);
            this.lbl_Ad.Name = "lbl_Ad";
            this.lbl_Ad.Size = new System.Drawing.Size(97, 25);
            this.lbl_Ad.TabIndex = 1;
            this.lbl_Ad.Text = "Kitap Adı:";
            // 
            // lbl_Yazar
            // 
            this.lbl_Yazar.AutoSize = true;
            this.lbl_Yazar.Location = new System.Drawing.Point(39, 92);
            this.lbl_Yazar.Name = "lbl_Yazar";
            this.lbl_Yazar.Size = new System.Drawing.Size(69, 25);
            this.lbl_Yazar.TabIndex = 2;
            this.lbl_Yazar.Text = "Yazar:";
            // 
            // lbl_Sayfa
            // 
            this.lbl_Sayfa.AutoSize = true;
            this.lbl_Sayfa.Location = new System.Drawing.Point(39, 130);
            this.lbl_Sayfa.Name = "lbl_Sayfa";
            this.lbl_Sayfa.Size = new System.Drawing.Size(69, 25);
            this.lbl_Sayfa.TabIndex = 3;
            this.lbl_Sayfa.Text = "Sayfa:";
            // 
            // lbl_Fiyat
            // 
            this.lbl_Fiyat.AutoSize = true;
            this.lbl_Fiyat.Location = new System.Drawing.Point(48, 167);
            this.lbl_Fiyat.Name = "lbl_Fiyat";
            this.lbl_Fiyat.Size = new System.Drawing.Size(60, 25);
            this.lbl_Fiyat.TabIndex = 4;
            this.lbl_Fiyat.Text = "Fiyat:";
            // 
            // lbl_Yayinevi
            // 
            this.lbl_Yayinevi.AutoSize = true;
            this.lbl_Yayinevi.Location = new System.Drawing.Point(16, 201);
            this.lbl_Yayinevi.Name = "lbl_Yayinevi";
            this.lbl_Yayinevi.Size = new System.Drawing.Size(92, 25);
            this.lbl_Yayinevi.TabIndex = 5;
            this.lbl_Yayinevi.Text = "Yayınevi:";
            // 
            // lbl_Tur
            // 
            this.lbl_Tur.AutoSize = true;
            this.lbl_Tur.Location = new System.Drawing.Point(60, 236);
            this.lbl_Tur.Name = "lbl_Tur";
            this.lbl_Tur.Size = new System.Drawing.Size(48, 25);
            this.lbl_Tur.TabIndex = 6;
            this.lbl_Tur.Text = "Tür:";
            // 
            // txt_ID
            // 
            this.txt_ID.Location = new System.Drawing.Point(114, 16);
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.Size = new System.Drawing.Size(186, 30);
            this.txt_ID.TabIndex = 7;
            // 
            // txt_Ad
            // 
            this.txt_Ad.Location = new System.Drawing.Point(114, 56);
            this.txt_Ad.Name = "txt_Ad";
            this.txt_Ad.Size = new System.Drawing.Size(186, 30);
            this.txt_Ad.TabIndex = 8;
            // 
            // txt_Yazar
            // 
            this.txt_Yazar.Location = new System.Drawing.Point(114, 92);
            this.txt_Yazar.Name = "txt_Yazar";
            this.txt_Yazar.Size = new System.Drawing.Size(186, 30);
            this.txt_Yazar.TabIndex = 9;
            // 
            // txt_Sayfa
            // 
            this.txt_Sayfa.Location = new System.Drawing.Point(114, 130);
            this.txt_Sayfa.Name = "txt_Sayfa";
            this.txt_Sayfa.Size = new System.Drawing.Size(186, 30);
            this.txt_Sayfa.TabIndex = 10;
            // 
            // txt_Fiyat
            // 
            this.txt_Fiyat.Location = new System.Drawing.Point(114, 167);
            this.txt_Fiyat.Name = "txt_Fiyat";
            this.txt_Fiyat.Size = new System.Drawing.Size(186, 30);
            this.txt_Fiyat.TabIndex = 11;
            // 
            // txt_Yayinevi
            // 
            this.txt_Yayinevi.Location = new System.Drawing.Point(114, 203);
            this.txt_Yayinevi.Name = "txt_Yayinevi";
            this.txt_Yayinevi.Size = new System.Drawing.Size(186, 30);
            this.txt_Yayinevi.TabIndex = 12;
            // 
            // cmb_Tur
            // 
            this.cmb_Tur.FormattingEnabled = true;
            this.cmb_Tur.Location = new System.Drawing.Point(114, 239);
            this.cmb_Tur.Name = "cmb_Tur";
            this.cmb_Tur.Size = new System.Drawing.Size(186, 33);
            this.cmb_Tur.TabIndex = 13;
            // 
            // btn_Listele
            // 
            this.btn_Listele.Location = new System.Drawing.Point(114, 292);
            this.btn_Listele.Name = "btn_Listele";
            this.btn_Listele.Size = new System.Drawing.Size(186, 35);
            this.btn_Listele.TabIndex = 14;
            this.btn_Listele.Text = "Listele";
            this.btn_Listele.UseVisualStyleBackColor = true;
            this.btn_Listele.Click += new System.EventHandler(this.btn_Listele_Click);
            // 
            // btn_Kaydet
            // 
            this.btn_Kaydet.Location = new System.Drawing.Point(114, 333);
            this.btn_Kaydet.Name = "btn_Kaydet";
            this.btn_Kaydet.Size = new System.Drawing.Size(186, 35);
            this.btn_Kaydet.TabIndex = 15;
            this.btn_Kaydet.Text = "Kaydet";
            this.btn_Kaydet.UseVisualStyleBackColor = true;
            this.btn_Kaydet.Click += new System.EventHandler(this.btn_Kaydet_Click);
            // 
            // btn_Sil
            // 
            this.btn_Sil.Location = new System.Drawing.Point(114, 374);
            this.btn_Sil.Name = "btn_Sil";
            this.btn_Sil.Size = new System.Drawing.Size(186, 35);
            this.btn_Sil.TabIndex = 16;
            this.btn_Sil.Text = "Sil";
            this.btn_Sil.UseVisualStyleBackColor = true;
            this.btn_Sil.Click += new System.EventHandler(this.btn_Sil_Click);
            // 
            // btn_Guncelle
            // 
            this.btn_Guncelle.Location = new System.Drawing.Point(114, 415);
            this.btn_Guncelle.Name = "btn_Guncelle";
            this.btn_Guncelle.Size = new System.Drawing.Size(186, 35);
            this.btn_Guncelle.TabIndex = 17;
            this.btn_Guncelle.Text = "Güncelle";
            this.btn_Guncelle.UseVisualStyleBackColor = true;
            this.btn_Guncelle.Click += new System.EventHandler(this.btn_Guncelle_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(318, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(838, 434);
            this.dataGridView1.TabIndex = 18;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 471);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_Guncelle);
            this.Controls.Add(this.btn_Sil);
            this.Controls.Add(this.btn_Kaydet);
            this.Controls.Add(this.btn_Listele);
            this.Controls.Add(this.cmb_Tur);
            this.Controls.Add(this.txt_Yayinevi);
            this.Controls.Add(this.txt_Fiyat);
            this.Controls.Add(this.txt_Sayfa);
            this.Controls.Add(this.txt_Yazar);
            this.Controls.Add(this.txt_Ad);
            this.Controls.Add(this.txt_ID);
            this.Controls.Add(this.lbl_Tur);
            this.Controls.Add(this.lbl_Yayinevi);
            this.Controls.Add(this.lbl_Fiyat);
            this.Controls.Add(this.lbl_Sayfa);
            this.Controls.Add(this.lbl_Yazar);
            this.Controls.Add(this.lbl_Ad);
            this.Controls.Add(this.lbl_ID);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_ID;
        private System.Windows.Forms.Label lbl_Ad;
        private System.Windows.Forms.Label lbl_Yazar;
        private System.Windows.Forms.Label lbl_Sayfa;
        private System.Windows.Forms.Label lbl_Fiyat;
        private System.Windows.Forms.Label lbl_Yayinevi;
        private System.Windows.Forms.Label lbl_Tur;
        private System.Windows.Forms.TextBox txt_ID;
        private System.Windows.Forms.TextBox txt_Ad;
        private System.Windows.Forms.TextBox txt_Yazar;
        private System.Windows.Forms.TextBox txt_Sayfa;
        private System.Windows.Forms.TextBox txt_Fiyat;
        private System.Windows.Forms.TextBox txt_Yayinevi;
        private System.Windows.Forms.ComboBox cmb_Tur;
        private System.Windows.Forms.Button btn_Listele;
        private System.Windows.Forms.Button btn_Kaydet;
        private System.Windows.Forms.Button btn_Sil;
        private System.Windows.Forms.Button btn_Guncelle;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

