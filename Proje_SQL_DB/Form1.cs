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

namespace Proje_SQL_DB
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnKategorı_Click(object sender, EventArgs e)
        {
            FrmKategori fr = new FrmKategori();
            fr.Show();  
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

            SqlConnection baglanti = new SqlConnection(@"Data Source=D15\SQLEXPRESS;Initial Catalog=SatisVT;Integrated Security=True");
            //Ürünlerin durum seviyesi
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Execute TEST4",baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();

            baglanti.Open();
            //ürünler tablosunda her bir kategoride kaç tane ürün olduğunu chartta göster.
            SqlCommand komut2 = new SqlCommand("select KATEGORIAD,count(URUNSTOK) from TBLKATEGORI inner join TBLURUNLER on TBLKATEGORI.KATEGORIID=TBLURUNLER.KATEGORI GROUP BY KATEGORIAD",baglanti);
            SqlDataReader dr = komut2.ExecuteReader();
            while(dr.Read())
            {
                //kategoriler chart serisinin içine xy noktaları (dr'de okuduğun 0. index)=x ve (1. index)=y ... olan 
                chart1.Series["Kategoriler"].Points.AddXY(dr[0], dr[1]);
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select MUSTERISEHIR, count(*) from MUSTERI Group by MUSTERISEHIR", baglanti);
            SqlDataReader dr2 = komut3.ExecuteReader();
            while(dr2.Read())
            {
                chart2.Series["Şehirler"].Points.AddXY(dr2[0], dr2[1]);
            }
            baglanti.Close();



        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void BtnMusteri_Click(object sender, EventArgs e)
        {
            FrmMusteri fr = new FrmMusteri();
            fr.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
