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
    public partial class frmkayit : Form
    {
        public frmkayit()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        private void frmkayit_Load(object sender, EventArgs e)
        {
            bgl.baglanti();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select k.ilacId,i.ilacAdi,b.bolumId,b.bolumAdi From " +
                "ilac as i inner join kayit as k on i.ilacId=k.ilacId inner join bolum as b on b.bolumId=k.bolumId", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmliste fr = new frmliste();
            fr.Show();
            this.Hide();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            SqlCommand komutekle = new SqlCommand("insert into kayit (ilacId,bolumId)values (@i1,@i2)", bgl.baglanti());
            komutekle.Parameters.AddWithValue("@i1", txtilacid.Text);
            komutekle.Parameters.AddWithValue("@i2", txtbolumid.Text);
            komutekle.ExecuteNonQuery();
            bgl.baglanti();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select k.ilacId,i.ilacAdi,b.bolumId,b.bolumAdi From ilac as i inner join" +
                " kayit as k on i.ilacId=k.ilacId inner join bolum as b on b.bolumId=k.bolumId", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from kayit where ilacId=@p1 and bolumId=@p2 ", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtilacid.Text);
            komut.Parameters.AddWithValue("@p2", txtbolumid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            bgl.baglanti();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select k.ilacId,i.ilacAdi,b.bolumId,b.bolumAdi From ilac as i inner join " +
                "kayit as k on i.ilacId=k.ilacId inner join bolum as b on b.bolumId=k.bolumId", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtilacid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtbolumid.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
           
        }



        private void txtarama_TextChanged(object sender, EventArgs e)
        {
            bgl.baglanti();
            DataTable tablo2 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT k.ilacId,i.ilacAdi,b.bolumId,b.bolumAdi " +
                "FROM ilac as i inner join kayit as k on i.ilacId=k.ilacId inner join bolum as b " +
                "on k.bolumId=b.bolumId where i.ilacAdi like'" + txtarama.Text + "%'", bgl.baglanti());
            da.Fill(tablo2);
            dataGridView1.DataSource = tablo2;
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komutguncelle = new SqlCommand("update kayit set bolumId=@p2 where ilacId=@p1 ", bgl.baglanti());
            komutguncelle.Parameters.AddWithValue("@p1", txtilacid.Text);
            komutguncelle.Parameters.AddWithValue("@p2", txtbolumid.Text);
            komutguncelle.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select k.ilacId,i.ilacAdi,b.bolumId,b.bolumAdi From ilac as i inner join kayit as k" +
                " on i.ilacId=k.ilacId inner join bolum as b on b.bolumId=k.bolumId", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;


        }
    }
}
