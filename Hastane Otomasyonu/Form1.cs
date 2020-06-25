using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hastane_Otomasyonu
{
    public partial class Form1 : Form
    {
        int a = 3;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (textBox1.Text == "111111")
            {
             //   MessageBox.Show("Giriş başarılı");
                Hide();
                Form2 f2 = new Form2();
                f2.ShowDialog();
            }
            else
            {
                a--;
                if (a == 0)
                {
                    MessageBox.Show("Şifrenizi 3 kere yanlış girdiniz, program kapanacaktır.");
                    Environment.Exit(0);
                }
                MessageBox.Show("Şifre yanlış lütfen tekrar deneyiniz. "+a.ToString()+" deneme hakkınız kaldı.");
                textBox1.Clear();
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
