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
    public partial class frmpersonel : Form
    {
        public frmpersonel()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();



        private void frmpersonel_Load(object sender, EventArgs e)
        {
            bgl.baglanti();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT personelTc,personelAdi,dogumTarihi,adres FROM personel where durum=1", bgl.baglanti());
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
            txttc.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtisim.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            richtxtadres.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            SqlCommand komutekle = new SqlCommand("insert into personel (personelTc,personelAdi,dogumTarihi,adres,durum)values (@p1,@p2,@p3,@p4,1)", bgl.baglanti());
            komutekle.Parameters.AddWithValue("@p1", txttc.Text);
            komutekle.Parameters.AddWithValue("@p2", txtisim.Text);
            komutekle.Parameters.AddWithValue("@p3", dateTimePicker1.Value);
            komutekle.Parameters.AddWithValue("@p4", richtxtadres.Text);
            komutekle.ExecuteNonQuery();
            bgl.baglanti();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT personelTc,personelAdi,dogumTarihi,adres FROM personel where durum=1", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update personel set durum=0 where personelTc=@p1 ", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txttc.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            bgl.baglanti();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT personelTc,personelAdi,dogumTarihi,adres FROM personel where durum=1", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;



        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komutguncelle = new SqlCommand("update personel set personelAdi=@p2,dogumTarihi=@p3,adres=@p4,durum=@p5 where personelTc=@p1 ", bgl.baglanti());
            komutguncelle.Parameters.AddWithValue("@p1", txttc.Text);
            komutguncelle.Parameters.AddWithValue("@p2", txtisim.Text);
            komutguncelle.Parameters.AddWithValue("@p3", dateTimePicker1.Value);
            komutguncelle.Parameters.AddWithValue("@p4", richtxtadres.Text);
            komutguncelle.Parameters.AddWithValue("@p5", 1);
            komutguncelle.ExecuteNonQuery();
            bgl.baglanti();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT personelTc,personelAdi,dogumTarihi,adres FROM personel where durum=1", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void txtarama_TextChanged(object sender, EventArgs e)
        {
            bgl.baglanti();
            DataTable tablo2 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT personelTc,personelAdi,dogumTarihi,adres  FROM personel where personelTc " +
                "like'" + txtarama.Text + "%'or personelAdi like'" + txtarama.Text + "%'and durum=1", bgl.baglanti());
            da.Fill(tablo2);
            dataGridView1.DataSource = tablo2;
        }
    }
}
