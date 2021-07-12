using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Collections;
namespace OnMuhasebeOtomasyonu
{
    public partial class siparisler : Form
    {
        public siparisler()
        {
            InitializeComponent();
        }

        public DataTable tablo = new DataTable();
        public DataTable tablo2 = new DataTable();
        public OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=datam.accdb");
        public OleDbDataAdapter adtr = new OleDbDataAdapter();
        public OleDbCommand kmt = new OleDbCommand();
        int id;
        private object listView1;

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void doldur()
        {
            comboBox3.Items.Clear();
            bag.Open();
            OleDbCommand kmt = new OleDbCommand("Select * from musteri", bag);
            OleDbDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                comboBox3.Items.Add(dr["adsoyad"].ToString());



            }
            bag.Close();
        }
        private void siparisler_Load(object sender, EventArgs e)
        {
            listele();
            doldur();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            //dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            try
            {
                kmt = new OleDbCommand("select * from stokbil where stokSeriNo='" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "'", bag);
                bag.Open();
                OleDbDataReader oku = kmt.ExecuteReader();
                oku.Read();
                if (oku.HasRows)
                {
                    pictureBox1.ImageLocation = oku[7].ToString();
                    id = Convert.ToInt32(oku[0].ToString());
                }
                bag.Close();
            }
            catch
            {
                bag.Close();
            }
        }
        public void listele2()
        {
            try
            {
                tablo2.Clear();
                bag.Open();
                OleDbDataAdapter adtr = new OleDbDataAdapter("select serino,musteri_adi,tutar,aciklama,tarih From cari order by id desc", bag);
                adtr.Fill(tablo2);
                dataGridView2.DataSource = tablo2;
                adtr.Dispose();
                bag.Close();
                try
                {
                    dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    //datagridview1'deki tüm satırı seç              
                 
                }
                catch
                {
                    ;
                }
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString());
            }

        }

        public void listele()
        {
            try
            {
                tablo.Clear();
                bag.Open();
                OleDbDataAdapter adtr = new OleDbDataAdapter("select stokAdi,stokModeli,stokSeriNo,stokAdedi,stokTarih,kayitYapan,olcu_birimi,afiyat,sfiyat From stokbil", bag);
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;
                adtr.Dispose();
                bag.Close();
                try
                {
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    //datagridview1'deki tüm satırı seç              
                    dataGridView1.Columns[0].HeaderText = "STOK ADI";
                    //sütunlardaki textleri değiştirme
                    dataGridView1.Columns[1].HeaderText = "STOK MODELİ";
                    dataGridView1.Columns[2].HeaderText = "STOK SERİNO";
                    dataGridView1.Columns[3].HeaderText = "STOK ADEDİ";
                    dataGridView1.Columns[4].HeaderText = "STOK TARİH";
                    dataGridView1.Columns[5].HeaderText = "KAYIT YAPAN";
                    dataGridView1.Columns[0].Width = 120;
                    //genişlik
                    dataGridView1.Columns[1].Width = 120;
                    dataGridView1.Columns[2].Width = 120;
                    dataGridView1.Columns[3].Width = 80;
                    dataGridView1.Columns[4].Width = 100;
                    dataGridView1.Columns[5].Width = 120;
                }
                catch
                {
                    ;
                }
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString());
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                tablo.Clear();
                bag.Open();
                OleDbDataAdapter adtr = new OleDbDataAdapter("select stokAdi,stokModeli,stokSeriNo,stokAdedi,stokTarih,kayitYapan,olcu_birimi,afiyat,sfiyat From stokbil where stokSeriNo='"+textBox6.Text+"'", bag);
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;
                adtr.Dispose();
                bag.Close();
                try
                {
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    //datagridview1'deki tüm satırı seç              
                    dataGridView1.Columns[0].HeaderText = "STOK ADI";
                    //sütunlardaki textleri değiştirme
                    dataGridView1.Columns[1].HeaderText = "STOK MODELİ";
                    dataGridView1.Columns[2].HeaderText = "STOK SERİNO";
                    dataGridView1.Columns[3].HeaderText = "STOK ADEDİ";
                    dataGridView1.Columns[4].HeaderText = "STOK TARİH";
                    dataGridView1.Columns[5].HeaderText = "KAYIT YAPAN";
                    dataGridView1.Columns[0].Width = 120;
                    //genişlik
                    dataGridView1.Columns[1].Width = 120;
                    dataGridView1.Columns[2].Width = 120;
                    dataGridView1.Columns[3].Width = 80;
                    dataGridView1.Columns[4].Width = 100;
                    dataGridView1.Columns[5].Width = 120;
                }
                catch
                {
                    ;
                }
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString());
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox9.Text = textBox3.Text;
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(textBox4.Text) < int.Parse(textBox13.Text))
                {
                    MessageBox.Show("Stok Limitini Aşamazsınız");
                    textBox13.Text = textBox4.Text;
                }
            }
            catch (Exception hata)
            {

                MessageBox.Show("Ürün Seçtiğine Emin Misin?"+hata.Message);
            }
            
            
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            textBox10.Text = textBox8.Text;
        }

        private void btnStokEkle_Click(object sender, EventArgs e)
        {
            if (textBox13.Text.Trim() != "" && comboBox3.Text.Trim() != "" && textBox11.Text.Trim() != "")
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "INSERT INTO cari(serino,musteri_adi,odeme_tipi,alim_miktari,tutar,aciklama,tarih) VALUES ('" + textBox9.Text + "','" + comboBox3.Text + "','" + comboBox2.Text + "','" + textBox13.Text + "','" + (int.Parse(textBox10.Text)*int.Parse(textBox13.Text)).ToString() + "','" + textBox11.Text + "','" + dateTimePicker2.Text + "') ";
                kmt.ExecuteNonQuery();
                kmt.Dispose();
                bag.Close();
                listele();

                MessageBox.Show("Sipariş İşlemi Tamamlandı ! ", "İşlem Sonucu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele2();
               /* printDocument1.DefaultPageSettings.PaperSize = printDocument1.PrinterSettings.PaperSizes[5];
                printDocument1.Print();*/
            }
        }

        private void printPreviewControl1_Click(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs ffff)
        {

            try
            {
                //ÇİZİM BAŞLANGICI
                Font myFont = new Font("Calibri", 7); //font oluşturduk
                SolidBrush sbrush = new SolidBrush(Color.Black);//fırça oluşturduk
                Pen myPen = new Pen(Color.Black); //kalem oluşturduk

                ffff.Graphics.DrawString("Düzenlenme Tarihi: " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString(), myFont, sbrush, 50, 25);
                ffff.Graphics.DrawLine(myPen, 25, 45, 770, 45); // Çizgi çizdik... 1. Kalem, 2. X, 3. Y Koordinatı, 4. Uzunluk, 5. BitişX

                myFont = new Font("Calibri", 8, FontStyle.Bold);//Fatura başlığı yazacağımız için fontu kalın yaptık ve puntoyu büyütüp 15 yaptık.
                ffff.Graphics.DrawString("Fatura", myFont, sbrush, 175, 65);
                ffff.Graphics.DrawLine(myPen, 25, 95, 770, 95); //çizgi çizdik.

                myFont = new Font("Calibri", 6, FontStyle.Bold); //Detay başlığını yazacağımız için fontu kalın yapıp puntoyu 10 yaptık.
                ffff.Graphics.DrawString("Seri No", myFont, sbrush, 25, 110); //Detay başlığı
                ffff.Graphics.DrawString("Müşteri", myFont, sbrush, 90, 110); //Detay başlığı
                ffff.Graphics.DrawString("Tutar", myFont, sbrush, 145, 110); // Detay başlığı
                ffff.Graphics.DrawString("Açıklama", myFont, sbrush, 220, 110); //Detay başlığı
                ffff.Graphics.DrawString("Tarih", myFont, sbrush, 315, 110); //Detay başlığı
                ffff.Graphics.DrawLine(myPen, 25, 125, 770, 125); //Çizgi çizdik.

                int y = 150; //y koordinatının yerini belirledik.(Verilerin yazılmaya başlanacağı yer)

                myFont = new Font("Calibri", 6); //fontu 10 yaptık.

                int i = 0;//satır sayısı için değişken tanımladık.
                if (i <= dataGridView2.Rows.Count)//döngüyü son satırda sonlandıracağız.
                {
                    ffff.Graphics.DrawString(dataGridView2[0, i].Value.ToString(), myFont, sbrush, 25, y);//1.sütun
                    ffff.Graphics.DrawString(dataGridView2[1, i].Value.ToString(), myFont, sbrush, 90, y);//2.sütun
                      ffff.Graphics.DrawString(dataGridView2[2, i].Value.ToString(), myFont, sbrush, 145, y);//3.sütun        
                   
                    ffff.Graphics.DrawString(dataGridView2[3, i].Value.ToString(), myFont, sbrush, 220, y);//4.sütun
                    ffff.Graphics.DrawString(dataGridView2[4, i].Value.ToString(), myFont, sbrush, 310, y);//5.sütun
                    y += 20; //y koordinatını arttırdık.
                    i += 1; //satır sayısını arttırdık

                    //yeni sayfaya geçme kontrolü
                  
                }
                //çoklu sayfa kontrolü
             /*   if (i < dataGridView2.RowCount - 1)
                {
                    ffff.HasMorePages = true;
                }
                else
                {
                    ffff.HasMorePages = false;
                    i = 0;
                }*/
                StringFormat myStringFormat = new StringFormat();
                myStringFormat.Alignment = StringAlignment.Far;
            }
            catch
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 mnu = new Form2();
            mnu.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }
    }
}
