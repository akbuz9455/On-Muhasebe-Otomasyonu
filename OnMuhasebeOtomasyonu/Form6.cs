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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        public DataTable tablo = new DataTable();
        public OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=datam.accdb");
        public OleDbDataAdapter adtr = new OleDbDataAdapter();
        public OleDbCommand kmt1 = new OleDbCommand();

        private void Form6_Load(object sender, EventArgs e)
        {
            textBox3.Text = DateTime.Now.ToShortDateString();
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bag.Open();
            kmt1.Connection = bag;
            kmt1.CommandText = "INSERT INTO notlar(adi,not_,ktarih,gtarih) VALUES ('" +textBox1.Text+ "','"+textBox2.Text+"','"+textBox3.Text+"','"+maskedTextBox1.Text+"')";
            kmt1.ExecuteNonQuery();


            bag.Close();
            listele();
            MessageBox.Show("Ajandanıza Notunuz Başarıyla Kaydedildi");
        }
        void listele()
        {
            tablo.Clear();
            bag.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From notlar", bag);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            adtr.Dispose();
            bag.Close();
            dataGridView1.Columns[1].HeaderText = "NOT ADI";
            //sütunlardaki textleri değiştirme
            dataGridView1.Columns[2].HeaderText = "NOT İÇERİĞİ";
            dataGridView1.Columns[3].HeaderText = "NOT KAYIT TARİHİ";
            dataGridView1.Columns[4].HeaderText = "NOT GÖSTERİM TARİHİ";
            dataGridView1.Columns[2].Width = 240;
            dataGridView1.Columns[4].Width = 140;
            dataGridView1.Columns[3].Width = 140;
            dataGridView1.Columns[0].Visible=false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
