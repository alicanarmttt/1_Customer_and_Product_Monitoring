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
    public partial class FrmMusteri : Form
    {

        SqlConnection baglanti = new SqlConnection(@"Data Source=D15\SQLEXPRESS;Initial Catalog=SatisVT;Integrated Security=True");
        
        void Listele()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from MUSTERI", baglanti);
            SqlDataAdapter da=new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView3.DataSource = dt;
            baglanti.Close();
        }
        public FrmMusteri()
        {
            InitializeComponent();
        }

        //tblsehirler tablosundan şehirleri alıyoruz
        private void FrmMusteri_Load(object sender, EventArgs e)
        {
            Listele();
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select * from TBLSEHIR", baglanti);
            SqlDataReader dr=komut1.ExecuteReader();
            while (dr.Read())
            {
                CmbSehir.Items.Add(dr["SEHIRAD"]);

            }
            baglanti.Close();
        }

        private void BtnListe_Click(object sender, EventArgs e)
        {
            Listele();
        }

        //Satıra tıklandığında bilgiler textboxlarda gözükür.
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtID.Text = dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtAD.Text = dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString();
            CmbSehir.Text = dataGridView3.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtBakiye.Text = dataGridView3.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(" insert into MUSTERI (MUSTERIAD,MUSTERISOYAD,MUSTERISEHIR,MUSTERIBAKIYE) Values (@p1,@p2,@p3,@p4)",baglanti);
            komut.Parameters.AddWithValue("@p1", TxtAD.Text);
            komut.Parameters.AddWithValue("@P2",TxtSoyad.Text);
            komut.Parameters.AddWithValue("@P3",CmbSehir.Text);
            komut.Parameters.AddWithValue("@P4",(Decimal.Parse(TxtBakiye.Text)));
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Müşteri hizmete kaydedildi.");
            Listele(); 


        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from MUSTERI Where MUSTERIAD=@p1",baglanti);
            komut.Parameters.AddWithValue("@p1",TxtAD.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView3.DataSource = dt;
        }

        private void TxtID_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {

        }

        private void CmbSehir_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
//Data Source = D15\SQLEXPRESS; Initial Catalog = SatisVT; Integrated Security = True