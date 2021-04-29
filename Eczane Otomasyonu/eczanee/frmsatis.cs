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
    public partial class frmsatis : Form
    {
        public frmsatis()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        private void frmsatis_Load(object sender, EventArgs e)
        {
            bgl.baglanti();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select s.satisNo,s.ilacId,i.ilacAdi,s.bolumId,b.bolumAdi,s.personeltc,p.personelAdi,s.adet,s.fiyat,s.tarih " +
                "from ilac as i inner join kayit as k on i.ilacId=k.ilacId inner join bolum as b on b.bolumId = k.bolumId" +
                " inner join satis as s on i.ilacId = s.ilacId inner join personel as p on p.personelTc = s.personelTc where s.durum=1", bgl.baglanti());
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
            txtsatisno.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtbolumid.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtpersoneltc.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtilacid.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtadet.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            txtfiyat.Text = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
            dateTimePicker1.Text= dataGridView1.Rows[secilen].Cells[9].Value.ToString();
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            bgl.baglanti();
            SqlDataAdapter komut = new SqlDataAdapter("select s.satisNo,s.ilacId,i.ilacAdi,s.bolumId,b.bolumAdi,s.personeltc,p.personelAdi,s.adet,s.fiyat,s.tarih " +
                "from ilac as i inner join kayit as k on i.ilacId=k.ilacId inner join bolum as b on b.bolumId = k.bolumId inner join" +
                " satis as s on i.ilacId = s.ilacId inner join personel as p on p.personelTc = s.personelTc where s.tarih between @t1 and @t2 and s.durum=1 ", bgl.baglanti());
            komut.SelectCommand.Parameters.AddWithValue("@t1", dateTimePicker2.Value);
            komut.SelectCommand.Parameters.AddWithValue("@t2", dateTimePicker3.Value);
            DataTable dt = new DataTable();
            komut.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            SqlCommand komutekle = new SqlCommand("insert into satis (bolumId,personelTc,ilacId,adet,fiyat,tarih,durum)values (@s2,@s3,@s4,@s5,@s6,@s7,@s8)", bgl.baglanti());
            //komutekle.Parameters.AddWithValue("@s1", txtsatisno.Text);
            komutekle.Parameters.AddWithValue("@s2", txtbolumid.Text);
            komutekle.Parameters.AddWithValue("@s3", txtpersoneltc.Text);
            komutekle.Parameters.AddWithValue("@s4", txtilacid.Text);
            komutekle.Parameters.AddWithValue("@s5", txtadet.Text);
            komutekle.Parameters.AddWithValue("@s6", txtfiyat.Text);
            komutekle.Parameters.AddWithValue("@s7", dateTimePicker1.Value);
            komutekle.Parameters.AddWithValue("@s8", 1);
            komutekle.ExecuteNonQuery();
            bgl.baglanti().Close();
            bgl.baglanti();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select s.satisNo,s.ilacId,i.ilacAdi,s.bolumId,b.bolumAdi,s.personeltc,p.personelAdi,s.adet,s.fiyat,s.tarih" +
                " from ilac as i inner join kayit as k on i.ilacId=k.ilacId inner join bolum as b on b.bolumId = k.bolumId " +
                "inner join satis as s on i.ilacId = s.ilacId inner join personel as p on p.personelTc = s.personelTc where s.durum=1", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update satis set durum=0 where satisNo=@p1 ", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtsatisno.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            bgl.baglanti();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select s.satisNo,s.ilacId,i.ilacAdi,s.bolumId,b.bolumAdi,s.personeltc,p.personelAdi,s.adet,s.fiyat,s.tarih" +
                " from ilac as i inner join kayit as k on i.ilacId=k.ilacId inner join bolum as b on b.bolumId = k.bolumId " +
                "inner join satis as s on i.ilacId = s.ilacId inner join personel as p on p.personelTc = s.personelTc where s.durum=1", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komutguncelle = new SqlCommand("update satis set bolumId=@p2,ilacId=@p4,adet=@p5,fiyat=@p6,tarih=@p7,durum=1 where satisNo=@p1 and personelTc=@p3", bgl.baglanti());

            komutguncelle.Parameters.AddWithValue("@p1", txtsatisno.Text);
            komutguncelle.Parameters.AddWithValue("@p2", txtbolumid.Text);
            komutguncelle.Parameters.AddWithValue("@p3", txtpersoneltc.Text);
            komutguncelle.Parameters.AddWithValue("@p4", txtilacid.Text);
            komutguncelle.Parameters.AddWithValue("@p5", txtadet.Text);
            komutguncelle.Parameters.AddWithValue("@p6", txtfiyat.Text);
            komutguncelle.Parameters.AddWithValue("@p7", dateTimePicker1.Value);
            komutguncelle.ExecuteNonQuery();
            bgl.baglanti().Close();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select s.satisNo,s.ilacId,i.ilacAdi,s.bolumId,b.bolumAdi,s.personeltc,p.personelAdi,s.adet,s.fiyat,s.tarih " +
                "from ilac as i inner join kayit as k on i.ilacId=k.ilacId inner join bolum as b on b.bolumId = k.bolumId" +
                " inner join satis as s on i.ilacId = s.ilacId inner join personel as p on p.personelTc = s.personelTc where s.durum=1", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void txtarama_TextChanged(object sender, EventArgs e)
        {
            bgl.baglanti();
            DataTable tablo2 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select s.satisNo, s.ilacId, i.ilacAdi, s.bolumId, b.bolumAdi, s.personeltc, p.personelAdi, s.adet, s.fiyat, s.tarih " +
                "from ilac as i inner join kayit as k on i.ilacId = k.ilacId inner join bolum as b on b.bolumId = k.bolumId " +
                "inner join satis as s on i.ilacId = s.ilacId inner join personel as p on p.personelTc = s.personelTc" +
                " where s.ilacId like'" + txtarama.Text + "%' and s.durum=1", bgl.baglanti());
            da.Fill(tablo2);
            dataGridView1.DataSource = tablo2;
        }
    }
}
