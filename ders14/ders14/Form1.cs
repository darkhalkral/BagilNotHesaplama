using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Collections;
using ders14_dll;

namespace ders14
{
    public partial class Form1 : Form
    {
        OleDbConnection con;
        OleDbDataAdapter da;
        DataTable dt = new DataTable();
        ArrayList ogr = new ArrayList();
        nothesapla hesapla = new nothesapla();
        public Form1()
        {
            InitializeComponent();
        }
        void baglanti()
        {
            dt.Clear();
            ogr.Clear();
            listView1.Items.Clear();
            con = new OleDbConnection("Provider=Microsoft.JET.Oledb.4.0; Data Source=C:\\Users\\halid\\source\\repos\\ogrnothesap.mdb");
            da = new OleDbDataAdapter("Select * from ogrenci", con);
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ogr.Add(dt.Rows[i]["ogrno"].ToString());
                listView1.Items.Add(dt.Rows[i]["ogrno"].ToString());
                ogr.Add(dt.Rows[i]["ad"].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i]["ad"].ToString());
                ogr.Add(dt.Rows[i]["soyad"].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i]["soyad"].ToString());
                ogr.Add(dt.Rows[i]["vize"].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i]["vize"].ToString());
                ogr.Add(dt.Rows[i]["final"].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i]["final"].ToString());
                ogr.Add(dt.Rows[i]["ort"].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i]["ort"].ToString());
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.MultiSelect = false;
            listView1.Sort();
            listView1.Columns.Add("Öğrenci No");
            listView1.Columns.Add("Ad");
            listView1.Columns.Add("Soyad");
            listView1.Columns.Add("Vize");
            listView1.Columns.Add("Final");
            listView1.Columns.Add("Ortalama");
            listView1.Columns.Add("Harf Notu");
            baglanti();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                textBox1.Text = listView1.SelectedItems[0].Text;
                textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
                textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
                textBox4.Text = listView1.SelectedItems[0].SubItems[3].Text;
                textBox5.Text = listView1.SelectedItems[0].SubItems[4].Text;
            }
        }         

        private void button4_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float ort = ((Convert.ToInt32(textBox4.Text)) * 0.4f) + ((Convert.ToInt32(textBox5.Text)) * 0.6f);
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText="Insert into ogrenci values("+textBox1.Text+",'"+textBox2.Text+"','"+textBox3.Text+"'," + textBox4.Text + "," + textBox5.Text + ",'" + ort + "')";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            baglanti();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(listView1.SelectedItems[0].Text);
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "delete from ogrenci where ogrno=" + id;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            baglanti();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(listView1.SelectedItems[0].Text);
            float ort = ((Convert.ToInt32(textBox4.Text)) * 0.4f) + ((Convert.ToInt32(textBox5.Text)) * 0.6f);
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "update ogrenci set ogrno="+textBox1.Text+",ad='"+textBox2.Text+"',soyad='"+textBox3.Text+"',vize="+textBox4.Text+",final="+textBox5.Text+",ort="+ort+" where ogrno=" + id;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            baglanti();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            float sınıfort = hesapla.sınıfort();
            double sapma = hesapla.standartsapma(sınıfort);
            string harfnotu = "";
            for (int i = 0; i < ogr.Count/6; i++)
            {
                
                harfnotu = hesapla.harfnotu(Convert.ToInt32(ogr[((i+1)*6)-1]), sınıfort, sapma);
                listView1.Items[i].SubItems.Add(harfnotu);
            }
        }
    }
}
