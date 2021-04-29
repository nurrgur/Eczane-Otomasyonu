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
    public partial class frmilac : Form
    {
        public frmilac()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        private void listele()
        {
            bgl.baglanti();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT ilacId,ilacAdi,yapisi,adet,fiyat  FROM ilac where durum=1", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void frmilac_Load(object sender, EventArgs e)
        {
            listele();
        }
 


        private void btnekle_Click(object sender, EventArgs e)
        {
            SqlCommand komutekle = new SqlCommand("insert into ilac (ilacAdi,yapisi,adet,fiyat,durum)values (@i2,@i3,@i4,@i5,@i6)", bgl.baglanti());
           // komutekle.Parameters.AddWithValue("@i1",txtıd.Text);
            komutekle.Parameters.AddWithValue("@i2",txtad.Text);
            komutekle.Parameters.AddWithValue("@i3",txtyapisi.Text);
            komutekle.Parameters.AddWithValue("@i4",txtadet.Text);
            komutekle.Parameters.AddWithValue("@i5", txtfiyat.Text);
            komutekle.Parameters.AddWithValue("@i6", 1);
            komutekle.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komutguncelle = new SqlCommand("update ilac set ilacAdi=@p2,yapisi=@p3,adet=@p4,fiyat=@p5 where ilacId=@p1 ",bgl.baglanti());           
            komutguncelle.Parameters.AddWithValue("@p1", txtıd.Text);
            komutguncelle.Parameters.AddWithValue("@p2", txtad.Text);
            komutguncelle.Parameters.AddWithValue("@p3", txtyapisi.Text);
            komutguncelle.Parameters.AddWithValue("@p4", txtadet.Text);
            komutguncelle.Parameters.AddWithValue("@p5", txtfiyat.Text);
            komutguncelle.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele();




        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtıd.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtyapisi.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtadet.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtfiyat.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update ilac set durum=0 where ilacId=@p1  ",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",txtıd.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            bgl.baglanti();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT ilacId,ilacAdi,yapisi,adet,fiyat  FROM ilac where durum=1", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;


        }

        private void txtarama_TextChanged(object sender, EventArgs e)
        {
            bgl.baglanti();
            DataTable tablo2 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT ilacId,ilacAdi,yapisi,adet,fiyat " +
               " FROM ilac where ilacId like'" + txtarama.Text+"%'or ilacAdi like'"+txtarama.Text+"%'and durum=1", bgl.baglanti());
            da.Fill(tablo2);
            dataGridView1.DataSource = tablo2;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmliste fr = new frmliste();
            fr.Show();
            this.Hide();
        }
    }
}
