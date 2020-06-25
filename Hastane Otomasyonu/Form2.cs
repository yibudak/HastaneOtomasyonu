using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hastane_Otomasyonu
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            poliklinikHastaEkle();
            servisHastaEkle();
            tetkikListele();
            tetkikKabulListele();
            ilacListele();
        }

        OleDbConnection veritabani = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=hastaneDB.mdb");
        


        private void tetkikListele()
        {
            comboBox9.Items.Clear();
            veritabani.Open();
            OleDbCommand komut2 = new OleDbCommand();
            komut2.Connection = veritabani;
            komut2.CommandText = ("Select * from poliklinik");
            OleDbDataReader oku = komut2.ExecuteReader();
            while (oku.Read())
            {

                comboBox9.Items.Add(oku["isim"].ToString() + " " + oku["soyisim"].ToString());

            }
            veritabani.Close();
            veritabani.Open();
            OleDbCommand komut3 = new OleDbCommand();
            komut3.Connection = veritabani;
            komut3.CommandText = ("Select * from servis");
            OleDbDataReader oku2 = komut3.ExecuteReader();
            while (oku2.Read())
            {

                comboBox9.Items.Add(oku2["isim"].ToString() + " " + oku2["soyisim"].ToString());

            }
            veritabani.Close();



        }

        private void tetkikKabulListele()
        {
            listView2.Items.Clear();
            veritabani.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = veritabani;
            komut.CommandText = ("Select * from tetkik");
            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem item = new ListViewItem(oku["isim"].ToString());
                item.SubItems.Add(oku["tetkik"].ToString());
                listView2.Items.Add(item);
            }

            veritabani.Close();
        }

        private void ilacListele()
        {
            listView1.Items.Clear();
            veritabani.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = veritabani;
            komut.CommandText = ("Select * from ilaclar");
            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem item = new ListViewItem(oku["ilac"].ToString());
                item.SubItems.Add(oku["miktari"].ToString());
                listView1.Items.Add(item);
            }

            veritabani.Close();

            veritabani.Open();
            OleDbCommand komut3 = new OleDbCommand();
            komut3.Connection = veritabani;
            komut3.CommandText = ("Select * from ilaclar");
            OleDbDataReader oku2 = komut3.ExecuteReader();
            while (oku2.Read())
            {

                comboBox11.Items.Add(oku2["ilac"].ToString());

            }
            veritabani.Close();

        }
        private void TextBoxTemizle()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);
        }
        private void poliklinikHastaEkle()
        {
            comboBox5.Items.Clear();
            comboBox5.ResetText();
            veritabani.Open();
            OleDbCommand komut2 = new OleDbCommand();
            komut2.Connection = veritabani;
            komut2.CommandText = ("Select * from poliklinik");
            OleDbDataReader oku = komut2.ExecuteReader();
            while (oku.Read())
            {

                comboBox5.Items.Add(oku["isim"].ToString() + " " + oku["soyisim"].ToString());

            }
            veritabani.Close();


        }

        private void servisHastaEkle()
        {
            comboBox8.Items.Clear();
            comboBox8.ResetText();
            veritabani.Open();
            OleDbCommand komut2 = new OleDbCommand();
            komut2.Connection = veritabani;
            komut2.CommandText = ("Select * from servis");
            OleDbDataReader oku = komut2.ExecuteReader();
            while (oku.Read())
            {

                comboBox8.Items.Add(oku["isim"].ToString() + " " + oku["soyisim"].ToString());

            }
            veritabani.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            if (radioButton1.Checked == true)
            {
                groupBox2.Enabled = true;
            }
            else
            {
                groupBox2.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            if (radioButton2.Checked == true)
            {
                groupBox3.Enabled = true;
            }
            else
            {
                groupBox3.Enabled = false;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            comboBox3.ResetText();
            comboBox3.Enabled = true;
            veritabani.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = veritabani;
            komut.CommandText = ("Select * from doktorlar");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                if (oku["alan"].ToString() == comboBox2.SelectedIndex.ToString())
                {
                    comboBox3.Items.Add(oku["isim"].ToString());
                }
                
            }
            veritabani.Close();
            comboBox4.Enabled = true;
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                veritabani.Open();
                OleDbCommand komut = new OleDbCommand();
                komut.Connection = veritabani;
                komut.CommandText = "insert into poliklinik(isim,soyisim,kurum,bolum,doktor,saat) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.SelectedItem.ToString() + "','" + comboBox2.SelectedItem.ToString() + "','" + comboBox3.SelectedItem.ToString() + "','" + comboBox4.SelectedItem.ToString() + "')";
                komut.ExecuteNonQuery();
                veritabani.Close();
                poliklinikHastaEkle();
                

            }
            else
            {
                veritabani.Open();
                OleDbCommand komut = new OleDbCommand();
                komut.Connection = veritabani;
                komut.CommandText = "insert into servis(isim,soyisim,kurum,servis,numara,kat) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.SelectedItem.ToString() + "','" + comboBox6.SelectedItem.ToString() + "','" + comboBox7.SelectedItem.ToString() + "','" + label9.Text + "')";
                komut.ExecuteNonQuery();
                veritabani.Close();
                servisHastaEkle();
            }
            MessageBox.Show("Hasta sisteme eklendi");
            tetkikListele();


        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBox9.Enabled = true;
            veritabani.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = veritabani;
            komut.CommandText = ("Select * from poliklinik");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                if (oku["isim"].ToString()+" "+oku["soyisim"].ToString() == comboBox5.SelectedItem.ToString())
                {
                    textBox4.Text = oku["isim"].ToString();
                    textBox5.Text = oku["kurum"].ToString();
                    textBox3.Text = oku["bolum"].ToString();
                    textBox6.Text = oku["soyisim"].ToString();
                    textBox7.Text = oku["saat"].ToString();
                    textBox8.Text = oku["doktor"].ToString();
                }

            }
            veritabani.Close();
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            label9.Visible = true;
            if (comboBox6.SelectedIndex != 0)
            {
                
                label9.Text = ((comboBox6.SelectedIndex * 3) / 2).ToString();
            }
            else
            {
                label9.Text = "1";
            }
            
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            veritabani.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = veritabani;
            komut.CommandText = ("Select * from servis");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                if (oku["isim"].ToString() + " " + oku["soyisim"].ToString() == comboBox8.SelectedItem.ToString())
                {
                    textBox9.Text = oku["kat"].ToString();
                    textBox10.Text = oku["numara"].ToString();
                    textBox11.Text = oku["servis"].ToString();
                    textBox12.Text = oku["soyisim"].ToString();
                    textBox13.Text = oku["kurum"].ToString();
                    textBox14.Text = oku["isim"].ToString();  
                    
                }

            }
            veritabani.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int x = 0;
            veritabani.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = veritabani;
            komut.CommandText = ("Select * from servis");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                if (comboBox8.SelectedItem != null)
                {
                    if (oku["isim"].ToString() + " " + oku["soyisim"].ToString() == comboBox8.SelectedItem.ToString())
                    {
                        DialogResult dialog = new DialogResult();
                        dialog = MessageBox.Show("Hasta taburcu edilecek, onaylıyor musunuz?", "Taburcu Onayı", MessageBoxButtons.YesNo);
                        if (dialog == DialogResult.Yes)
                        {
                            x = 1;
                        }
                        else
                        {
                            MessageBox.Show("İşlem iptal edildi.");
                        }

                    }
                }


            }
            veritabani.Close();
            if (x == 1)
            {
              
                veritabani.Open();
                OleDbCommand komut2 = new OleDbCommand();
                komut2.Connection = veritabani;
                komut2.CommandText = "delete from servis where isim = '" + textBox14.Text + "'";
                komut2.ExecuteNonQuery();
                veritabani.Close();
                servisHastaEkle();
                MessageBox.Show("Hastanın tedavisi tamamlandı.");
                TextBoxTemizle();
                tetkikListele();
            }
   
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x = 0;
            veritabani.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = veritabani;
            komut.CommandText = ("Select * from poliklinik");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                if (comboBox5.SelectedItem != null)
                {
                    if (oku["isim"].ToString() + " " + oku["soyisim"].ToString() == comboBox5.SelectedItem.ToString())
                    {
                        DialogResult dialog = new DialogResult();
                        dialog = MessageBox.Show("Hastanın tedavisi tamamlandı, onaylıyor musunuz?", "Tedavi Onayı", MessageBoxButtons.YesNo);
                        if (dialog == DialogResult.Yes)
                        {
                            x = 1;
                        }
                        else
                        {
                            MessageBox.Show("İşlem iptal edildi.");
                        }

                    }
                }


            }
            veritabani.Close();
            if (x == 1)
            {
             
                veritabani.Open();
                OleDbCommand komut2 = new OleDbCommand();
                komut2.Connection = veritabani;
                komut2.CommandText = "delete from poliklinik where isim = '" + textBox4.Text + "'";
                komut2.ExecuteNonQuery();
                veritabani.Close();
                poliklinikHastaEkle();
                MessageBox.Show("Hastanın tedavisi tamamlandı.");
                TextBoxTemizle();
                tetkikListele();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hastaya, "+comboBox11.SelectedItem + " adlı ilaç " + textBox17.Text.ToString() + " adet yazıldı.");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            veritabani.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = veritabani;
            komut.CommandText = "insert into tetkik(isim,tetkik) values ('" + comboBox9.SelectedItem + "','" + comboBox10.SelectedItem + "')";
            komut.ExecuteNonQuery();
            veritabani.Close();
            tetkikKabulListele();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            veritabani.Open();
            OleDbCommand komut2 = new OleDbCommand();
            komut2.Connection = veritabani;
            komut2.CommandText = "delete from tetkik where isim = '" + listView2.FocusedItem.Text + "'";
            MessageBox.Show(listView2.FocusedItem.Text + " kişisinin tetkik sonuçları kabul edilmiştir.");
            komut2.ExecuteNonQuery();
            veritabani.Close();
            tetkikKabulListele();
            
        }


        private void button7_Click(object sender, EventArgs e)
        {
            veritabani.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = veritabani;
            komut.CommandText = "insert into ilaclar(ilac,miktari) values ('" + textBox15.Text + "','" + textBox16.Text + "')";
            komut.ExecuteNonQuery();
            veritabani.Close();
            ilacListele();
        }

    }
}
