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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        public OleDbConnection bag = new OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0;Data Source=datam.accdb");
        public DataTable tablo = new DataTable();
        public OleDbDataAdapter adtr = new OleDbDataAdapter();
        public OleDbCommand kmt = new OleDbCommand();
        public void listele()
        {
            tablo.Clear();
            bag.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select stokAdi,stokModeli,stokSeriNo,stokAdedi,stokTarih,kayitYapan From stokbil", bag);
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

            }
        }

        private void btnStokModelAra_Click(object sender, EventArgs e)
        {
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From stokbil", bag);
            if (radioButton1.Checked == true)
            {
                if (textBox6.Text.Trim() == "")
                {
                    tablo.Clear();
                    kmt.Connection = bag;
                    kmt.CommandText = "Select * from stokbil";
                    adtr.SelectCommand = kmt;
                    adtr.Fill(tablo);
                }
                if (Convert.ToBoolean(bag.State) == false)
                {
                    bag.Open();
                }
                if (textBox6.Text.Trim() != "")
                {
                    adtr.SelectCommand.CommandText = " Select * From stokbil" +
                         " where(stokAdi='" + textBox6.Text + "' )";
                    tablo.Clear();
                    adtr.Fill(tablo);
                    bag.Close();
                }


            }
            else if (radioButton2.Checked == true)
            {
                if (textBox6.Text.Trim() == "")
                {
                    tablo.Clear();
                    kmt.Connection = bag;
                    kmt.CommandText = "Select * from stokbil";
                    adtr.SelectCommand = kmt;
                    adtr.Fill(tablo);
                }
                if (Convert.ToBoolean(bag.State) == false)
                {
                    bag.Open();
                }
                if (textBox6.Text.Trim() != "")
                {
                    adtr.SelectCommand.CommandText = " Select * From stokbil" +
                         " where(stokModeli='" + textBox6.Text + "' )";
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

        private void Form4_Load(object sender, EventArgs e)
        {
            listele();
        }
    }
}
