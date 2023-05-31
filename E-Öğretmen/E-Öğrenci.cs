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
    public partial class E_Öğrenci : Form
    {
        public E_Öğrenci()
        {
            InitializeComponent();
        }



        void gecenler()
        {
            baglanti.Open();

            SqlCommand geçenler = new SqlCommand("Select Count(*) from Table_Öğrenci where ÖgrOrtalaması>40", baglanti);

            SqlDataReader gec = geçenler.ExecuteReader();

            while (gec.Read())
            {

                label19.Text = gec[0].ToString();
            }
            baglanti.Close();
        }


        void kalanlar()
        {
            baglanti.Open();
            SqlCommand kalanlar = new SqlCommand("Select Count(*) from Table_Öğrenci where ÖgrOrtalaması<50", baglanti);

            SqlDataReader kalan = kalanlar.ExecuteReader();

            while (kalan.Read())
            {

                label20.Text = kalan[0].ToString();
            }
            baglanti.Close();
        }

        // Sql Bağlantı
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-0DOOTGM\\SQLEXPRESS01;Initial Catalog=EOgretmen;Integrated Security=True");

        public string ogrtc;
        private void E_Öğrenci_Load(object sender, EventArgs e)
        {
            this.table_ÖğrenciTableAdapter.Fill(this.eOgretmenDataSet1.Table_Öğrenci);

            // öğretmen bilgileri çekme.
            ogrtctext.Text = ogrtc;

            baglanti.Open();

            SqlCommand ögrbilgileri = new SqlCommand("Select * from Table_Öğretmen where id=@p1",baglanti);
            ögrbilgileri.Parameters.AddWithValue("@p1", ogrtctext.Text);

            SqlDataReader readbilgiler = ögrbilgileri.ExecuteReader();

            while (readbilgiler.Read())
            {
                label11.Text = readbilgiler[1] +" "+ readbilgiler[2].ToString();
            }


            baglanti.Close();

            gecenler();
            kalanlar();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Sql Bağlantı  Open
            baglanti.Open();
            SqlCommand komutsql = new SqlCommand("insert into Table_Öğrenci(Ögrİsim,ÖgrSoyadı,ÖgrNo,ÖgrŞube,ÖgrNot1,ÖgrNot2,ÖgrProje) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7)", baglanti);
            komutsql.Parameters.AddWithValue("@p1",textİsim.Text);
            komutsql.Parameters.AddWithValue("@p2", textSoyad.Text);
            komutsql.Parameters.AddWithValue("@p3", textNo.Text);
            komutsql.Parameters.AddWithValue("@p4", textSube.Text);
            komutsql.Parameters.AddWithValue("@p5", ögrnot1.Text);
            komutsql.Parameters.AddWithValue("@p6", ögrnot2.Text);
            komutsql.Parameters.AddWithValue("@p7", ögrproje.Text);
            komutsql.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Eklendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.table_ÖğrenciTableAdapter.Fill(this.eOgretmenDataSet1.Table_Öğrenci);
            // Sql Bağlantı  Close
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
        



        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textİsim.Text = "";
            textSoyad.Text = "";
            textNo.Text = "";
            textSube.Text = "";
            ögrnot1.Text = "";
            ögrnot2.Text = "";
            ögrproje.Text = "";
            label13.Text = "NULL";
            label14.Text = "NULL";
            label16.Text = "NULL";
            label17.Text = "NULL";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            label23.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textİsim.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            textNo.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            textSube.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            ögrnot1.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            ögrnot2.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            ögrproje.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();



            label13.Text = ögrnot1.Text;
            label14.Text = ögrnot2.Text;
            label16.Text = ögrproje.Text;
            // 
            int ortalama, s1, s2, s3;

            s1 = Convert.ToInt32(ögrnot1.Text);
            s2 = Convert.ToInt32(ögrnot2.Text);
            s3 = Convert.ToInt32(ögrproje.Text);

            ortalama = (s1 + s2 + s3) / 3;
            label17.Text = ortalama.ToString();

            baglanti.Open();

            SqlCommand güncelle = new SqlCommand("Update Table_Öğrenci set ÖgrOrtalaması=@q3 where Ögrİd=@pd", baglanti);
            güncelle.Parameters.AddWithValue("@pd", label23.Text);
            güncelle.Parameters.AddWithValue("@q3", int.Parse(label17.Text));
            güncelle.ExecuteNonQuery();
            baglanti.Close();
            this.table_ÖğrenciTableAdapter.Fill(this.eOgretmenDataSet1.Table_Öğrenci);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Delete Öğrenci
            baglanti.Open();
            SqlCommand delete = new SqlCommand("Delete from Table_Öğrenci where Ögrİsim=@q2", baglanti);
            delete.Parameters.AddWithValue("@q2", textİsim.Text);
            delete.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Başarılı Şekildi Öğrenci Silindi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            // Delete Öğrenci
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gecenler();
            kalanlar();


            this.table_ÖğrenciTableAdapter.Fill(this.eOgretmenDataSet1.Table_Öğrenci);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {




        }

        private void güncellenicekToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlCommand ogrgöster = new SqlCommand("Update Table_Öğrenci set Ögrİsim=@a2,ÖgrSoyadı=@q2,ÖgrŞube=@q4,ÖgrNot1=@q5,ÖgrNot2=@q6,ÖgrProje=@q7 where Ögrİd=@fq3", baglanti);
            ogrgöster.Parameters.AddWithValue("@a2", textİsim.Text);
            ogrgöster.Parameters.AddWithValue("@q2", textSoyad.Text);
            ogrgöster.Parameters.AddWithValue("@q4", textSube.Text);
            ogrgöster.Parameters.AddWithValue("@q5", ögrnot1.Text);
            ogrgöster.Parameters.AddWithValue("@q6", ögrnot2.Text);
            ogrgöster.Parameters.AddWithValue("@q7", ögrproje.Text);
            ogrgöster.Parameters.AddWithValue("@fq3", label23.Text);
            ogrgöster.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Başarılı Şekildi Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }
    }
}
