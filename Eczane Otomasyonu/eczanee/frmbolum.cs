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
namespace eczanee
{
    public partial class frmbolum : Form
    {
        public frmbolum()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        private void frmbolum_Load(object sender, EventArgs e)
        {
            bgl.baglanti();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select bolumId ,bolumAdi from bolum where durum=1", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmliste fr = new frmliste();
            fr.Show();
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtbolumid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtbolumadi.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            SqlCommand komutekle = new SqlCommand("insert into bolum (bolumAdi,durum)values (@b2,@b3)", bgl.baglanti());
            komutekle.Parameters.AddWithValue("@b2", txtbolumadi.Text);
            komutekle.Parameters.AddWithValue("@b3", 1);
         
            komutekle.ExecuteNonQuery();
            //bgl.baglanti().Close();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select bolumId ,bolumAdi from bolum where durum=1", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update bolum set durum=0 where bolumId=@p1 ", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtbolumid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            bgl.baglanti();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT bolumId,bolumAdi FROM bolum where durum=1", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void txtidara_TextChanged(object sender, EventArgs e)
        {
            bgl.baglanti();
            DataTable tablo2 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT bolumId,bolumAdi FROM bolum where bolumId like'" + txtidara.Text + "%'or bolumAdi like'" + txtidara.Text + "%'and durum=1", bgl.baglanti());
            da.Fill(tablo2);
            dataGridView1.DataSource = tablo2;
        }

        private void btngucelle_Click(object sender, EventArgs e)
        {
            SqlCommand komutguncelle = new SqlCommand("update bolum set bolumAdi=@p2  where bolumId=@p1 ", bgl.baglanti());
            komutguncelle.Parameters.AddWithValue("@p1", txtbolumid.Text);
            komutguncelle.Parameters.AddWithValue("@p2", txtbolumadi.Text);
            komutguncelle.ExecuteNonQuery();
            bgl.baglanti().Close();
            bgl.baglanti();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select bolumId ,bolumAdi from bolum where durum=1", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
    }
}
