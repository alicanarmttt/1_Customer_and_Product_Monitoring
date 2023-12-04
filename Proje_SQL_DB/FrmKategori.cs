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
    public partial class FrmKategori : Form
    {
        public FrmKategori()
        {
            InitializeComponent();
        }

   
        SqlConnection baglanti = new SqlConnection(@"Data Source=D15\SQLEXPRESS;Initial Catalog=SatisVT;Integrated Security=True");

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("update TBLKATEGORI set KATEGORIAD=@p1 where KATEGORIID=@p2", baglanti);
            komut4.Parameters.AddWithValue("@p1", TxtKategoriAd.Text);
            komut4.Parameters.AddWithValue("@p2", TxtKategoriID.Text);
            komut4.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncellendi.");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("select * from TBLKATEGORI", baglanti);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                dataGridView3.DataSource = dt;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("insert into TBLKATEGORI(KATEGORIAD) Values (@p1)",baglanti);
            komut2.Parameters.AddWithValue("@p1", TxtKategoriAd.Text);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kategori kaydetme işlemi başarıyla gerçekleşti.");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Delete from TBLKATEGORI Where KATEGORIID=@p1",baglanti);
            komut3.Parameters.AddWithValue("@p1", TxtKategoriID.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kategoriyi silme işlemi gerçekleşti.");
        }

        private void dtgKategoriVeri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtKategoriID.Text = dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtKategoriAd.Text = dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void FrmKategori_Load(object sender, EventArgs e)
        {

        }



        //Data Source=D15\SQLEXPRESS;Initial Catalog=SatisVT;Integrated Security=True
    }
}
