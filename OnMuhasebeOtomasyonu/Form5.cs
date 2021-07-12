using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace OnMuhasebeOtomasyonu
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
       
        public DataTable tablo = new DataTable();
        public DataTable tablo2 = new DataTable();
        public OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=datam.accdb");
        public OleDbDataAdapter adtr = new OleDbDataAdapter();
        public OleDbCommand kmt = new OleDbCommand();
        int id;
        
        private void Form5_Load(object sender, EventArgs e)
        {
           
            listele();
            doldur();


        }
        public void listele2()
        {
            try
            {
                tablo2.Clear();
                bag.Open();
                OleDbDataAdapter adtr = new OleDbDataAdapter("select serino,musteri_adi,tutar,aciklama,tarih From cari where tarih>='"+dateTimePicker2.Text+"' and tarih<'"+dateTimePicker3.Text+"'     order by id desc", bag);
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
        public void doldur()
        {
            bag.Open();
            kmt = new OleDbCommand("Select * from stokbil",bag);
            OleDbDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["stokSeriNo"].ToString());
              
                //Veya
                //textBox1.Text = dr.GetString(0);
                //textBox2.Text = dr.GetString(1);
                //textBox3.Text = dr.GetString(2);

            }
            bag.Close();
        }
        public void listele()
        {
            try
            {
                tablo.Clear();
                bag.Open();
                OleDbDataAdapter adtr = new OleDbDataAdapter("select * From cari", bag);
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;
                adtr.Dispose();
                bag.Close();
                try
                {
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    //datagridview1'deki tüm satırı seç              
                    dataGridView1.Columns[1].HeaderText = "STOK SERİNO";
                    //sütunlardaki textleri değiştirme
                    dataGridView1.Columns[2].HeaderText = "MÜŞTERİ ADI";
                    dataGridView1.Columns[3].HeaderText = "ÖDEME TİPİ";
                    dataGridView1.Columns[4].HeaderText = "ALIM MİKTARI";
                    dataGridView1.Columns[5].HeaderText = "BİRİM SATIŞ FİYATI";
                    dataGridView1.Columns[6].HeaderText = "AÇIKLAMA";
                    dataGridView1.Columns[7].HeaderText = "TARİH";
                    dataGridView1.Columns[8].Width = 120;
                    //genişlik
                    dataGridView1.Columns[0].Width = 0;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            bag.Open();
            kmt = new OleDbCommand("Select * from stokbil where stokSeriNo='"+comboBox1.Text+"'", bag);
            OleDbDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
            textBox6.Text= dr["sfiyat"].ToString();
            }
            bag.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            this.Hide();
        }

        private void btnStokEkle_Click(object sender, EventArgs e)
        {

            if ( textBox2.Text.Trim() != ""  && textBox4.Text.Trim() != "" && textBox5.Text.Trim() != "")
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "INSERT INTO cari(serino,musteri_adi,odeme_tipi,alim_miktari,tutar,aciklama,tarih) VALUES ('" + comboBox1.Text + "','" + textBox2.Text + "','" + comboBox2.Text + "','" + textBox4.Text + "','" + textBox6.Text + "','" + textBox5.Text + "','" + dateTimePicker1.Text + "') ";
                kmt.ExecuteNonQuery();
                kmt.Dispose();
                bag.Close();       
                listele();
             
                MessageBox.Show("Kayıt İşlemi Tamamlandı ! ", "İşlem Sonucu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnStokSil_Click(object sender, EventArgs e)
        {

            try
            {
                DialogResult cevap;
                cevap = MessageBox.Show("Kaydı silmek istediğinizden eminmisiniz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes && dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim() != "")
                {
                    bag.Open();
                    kmt.Connection = bag;
                    kmt.CommandText = "DELETE from cari WHERE serino='" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "' ";
                    kmt.ExecuteNonQuery();
                    kmt.Dispose();
                    bag.Close();
                    listele();
                }
            }
            catch
            {
                ;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                comboBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            }
            catch 
            {

              ;
            }
          
         
        }

        private void btnStokGuncelle_Click(object sender, EventArgs e)
        {

            if (comboBox1.Text.Trim() != "" && textBox5.Text.Trim() != "")
            {


                string sorgu = "UPDATE cari SET serino='" + comboBox1.Text+ "',musteri_adi='" + textBox2.Text + "',odeme_tipi='" + comboBox2.Text + "',alim_miktari='" + textBox4.Text + "',tutar='" + textBox6.Text + "',aciklama='" + textBox5.Text + "',tarih='" + dateTimePicker1.Text + "' WHERE id=" + dataGridView1.CurrentRow.Cells[0].Value.ToString();
                OleDbCommand kmt = new OleDbCommand(sorgu, bag);
                bag.Open();
                kmt.ExecuteNonQuery();
                kmt.Dispose();
                bag.Close();
                listele();
                MessageBox.Show("Güncelleme İşlemi Tamamlandı !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Boş Alan Bırakmayınız !");
            }
        }

        private void btnStokModelAra_Click(object sender, EventArgs e)
        {
            bag.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From cari", bag);
            if (radioButton1.Checked == true)
            {
                if (textBox1.Text.Trim() == "")
                {
                    tablo.Clear();
                    kmt.Connection = bag;
                    kmt.CommandText = "Select * from cari";
                    adtr.SelectCommand = kmt;
                    adtr.Fill(tablo);
                }
                if (Convert.ToBoolean(bag.State) == false)
                {
                    bag.Open();
                }
                if (textBox1.Text.Trim() != "")
                {
                    adtr.SelectCommand.CommandText = " Select * From cari" +
                         " where(serino='" + textBox1.Text + "' )";
                    tablo.Clear();
                    adtr.Fill(tablo);
                    bag.Close();
                }


            }
            else if (radioButton2.Checked == true)
            {
                if (textBox1.Text.Trim() == "")
                {
                    tablo.Clear();
                    kmt.Connection = bag;
                    kmt.CommandText = "Select * from cari";
                    adtr.SelectCommand = kmt;
                    adtr.Fill(tablo);
                }
                if (Convert.ToBoolean(bag.State) == false)
                {
                    bag.Open();
                }
                if (textBox1.Text.Trim() != "")
                {
                    adtr.SelectCommand.CommandText = " Select * From cari" +
                         " where(musteri_adi='" + textBox1.Text + "' )";
                    tablo.Clear();
                    adtr.Fill(tablo);
                    bag.Close();
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir arama türü seçiniz...");
            }
        }

        private void button1_Click(object sender, EventArgs ffff)
        {
            listele2();
            printDocument1.Print();
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
                while (i <= dataGridView2.Rows.Count)//döngüyü son satırda sonlandıracağız.
                {
                    ffff.Graphics.DrawString(dataGridView2[0, i].Value.ToString(), myFont, sbrush, 25, y);//1.sütun
                    ffff.Graphics.DrawString(dataGridView2[1, i].Value.ToString(), myFont, sbrush, 90, y);//2.sütun
                    ffff.Graphics.DrawString(dataGridView2[2, i].Value.ToString(), myFont, sbrush, 145, y);//3.sütun        

                    ffff.Graphics.DrawString(dataGridView2[3, i].Value.ToString(), myFont, sbrush, 220, y);//4.sütun
                    ffff.Graphics.DrawString(dataGridView2[4, i].Value.ToString(), myFont, sbrush, 310, y);//5.sütun
                    y += 20; //y koordinatını arttırdık.
                    i += 1; //satır sayısını arttırdık

                    //yeni sayfaya geçme kontrolü
                    if (y > 1000)
                    {
                        ffff.Graphics.DrawString("(Devamı -->)", myFont, sbrush, 700, y + 50);
                        y = 50;
                        break; //burada yazdırma sınırına ulaştığımız için while döngüsünden çıkıyoruz
                               //çıktığımızda while baştan başlıyor i değişkeni değer almaya devam ediyor
                               //yazdırma yeni sayfada başlamış oluyor
                    }
                }
               //çoklu sayfa kontrolü
                   if (i < dataGridView2.RowCount - 1)
                   {
                       ffff.HasMorePages = true;
                   }
                   else
                   {
                       ffff.HasMorePages = false;
                       i = 0;
                   }
                StringFormat myStringFormat = new StringFormat();
                myStringFormat.Alignment = StringAlignment.Far;
            }
            catch
            {
            }
        }
            
        }
    }
    
    

