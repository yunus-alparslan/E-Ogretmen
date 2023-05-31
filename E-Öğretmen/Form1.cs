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

namespace E_Öğretmen
{

    

     
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Sql Bağlantı

        SqlConnection databaseloginöğretmen = new SqlConnection("Data Source=DESKTOP-0DOOTGM\\SQLEXPRESS01;Initial Catalog=EOgretmen;Integrated Security=True");

        // Değişkenler
        int secturycodem;


        private void secturycode()
        {
           Random sectury = new Random();

            secturycodem = sectury.Next(100, 900);
            TextSectr.Text = "A" + "G" + secturycodem.ToString();

            if (TextSectr.Text == txtboxcode.Text)
            {
                MessageBox.Show("Test");
            }

        }

        private void gecirilensüre()
        {
           

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            gecirilensüre();
            secturycode();

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            databaseloginöğretmen.Open();
            SqlCommand cmdbaglan = new SqlCommand("Select * From Table_Öğretmen where ÖğretmenTc=@p1 and ÖğretmenSifre=@p2",databaseloginöğretmen);
            cmdbaglan.Parameters.AddWithValue("@p1", textTc.Text);
            cmdbaglan.Parameters.AddWithValue("@p2", textSifre.Text);

            SqlDataReader dr = cmdbaglan.ExecuteReader();
            // Güvenlik Kodu Kontrol
            if (TextSectr.Text == txtboxcode.Text)
            {
                if (dr.Read())
                {
                    E_Öğrenci FormÖğrenci = new E_Öğrenci();
                    FormÖğrenci.ogrtc = textTc.Text;
                    MessageBox.Show("Giriş Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FormÖğrenci.Show();
                    this.Hide();

                   

                }
                else
                {
                    MessageBox.Show("T.C veya Şifrenizi Kontrol Ediniz ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (txtboxcode.Text == "")
            {
                MessageBox.Show("Güvenlik Kodunu Boş Bırakmayınız", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Random sectury = new Random();
                secturycodem = sectury.Next(100, 900);
                TextSectr.Text = "A" + "G" + secturycodem.ToString();
                
                MessageBox.Show("Güvenlik Kodu Yanlış", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            databaseloginöğretmen.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
         
        }
    }
}
