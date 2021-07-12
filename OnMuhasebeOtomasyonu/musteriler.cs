using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//access veritabanı kullanacağımız için
using System.Data.OleDb;
namespace OnMuhasebeOtomasyonu
{
    public partial class musteriler : Form
    {
        public musteriler()
        {
            InitializeComponent();
        }

        OleDbConnection baglan = new OleDbConnection("provider=microsoft.ace.oledb.12.0;data source=" + Application.StartupPath + "\\datam.accdb");
        DataTable tablo = new DataTable();
        DataTable tablo2 = new DataTable();
        public void listele()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox3.Text = "";
            comboBox2.Text = "";
            maskedTextBox1.Text = "";

            tablo.Clear();
            baglan.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter
          ("select * from musteri", baglan);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            dataGridView1.Columns[0].Visible = false;
            baglan.Close();
        }
        public void doldur()
        {
            comboBox1.Items.Clear();
            baglan.Open();
            OleDbCommand kmt = new OleDbCommand("Select * from musteri", baglan);
            OleDbDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["adsoyad"].ToString());

              

            }
            baglan.Close();
        }
        private void musteriler_Load(object sender, EventArgs e)
        {
            doldur();
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (baglan.State == ConnectionState.Open)
            {

                baglan.Close();
            }
            baglan.Open();

            OleDbCommand kmt;

            kmt = new OleDbCommand
            ("INSERT INTO musteri(tc,adsoyad,d_tarih,tel,k_tarih,k_karti,durum) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + maskedTextBox1.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox3.Text + "','" + comboBox2.Text + "')", baglan);
            kmt.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("Kayıt Başarılı");
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbCommand kmt;
            baglan.Open();
            kmt = new OleDbCommand("Delete from musteri WHERE tc = '" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "'", baglan);
            kmt.ExecuteNonQuery();
            kmt.Dispose();
            baglan.Close();
            MessageBox.Show("İşleminiz başarılı");
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbCommand kmt;
            baglan.Open();
            kmt = new OleDbCommand("UPDATE musteri SET tc='" + textBox1.Text + "',adsoyad='" + textBox2.Text + "',d_tarih='" + maskedTextBox1.Text + "',tel='" + textBox5.Text + "',k_tarih='" + textBox6.Text + "',k_karti='" + textBox3.Text + "',durum='" + comboBox2.Text + "'where tc='" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "'", baglan);
            kmt.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("İşleminiz başarılı");
            listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tablo2.Clear();
            baglan.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter
          ("select * from cari where musteri_adi ='" + comboBox1.Text + "'", baglan);
            adtr.Fill(tablo2);
            dataGridView2.DataSource = tablo2;
            dataGridView2.Columns[0].Visible = false;
            baglan.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        }
    }
}
