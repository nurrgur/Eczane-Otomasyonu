using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace eczanee
{
    public partial class frmgiris : Form
    {
        
        SqlDataReader oku;

        public frmgiris()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();
        private void btngiris_Click_1(object sender, EventArgs e)
        {       
            bgl.baglanti();
            SqlCommand komut= new SqlCommand("SELECT * FROM giris where kullaniciAdi='" + txtkullanici.Text + "' AND sifre='" + txtsifre.Text + "'",bgl.baglanti());
            
            oku = komut.ExecuteReader();
            if (oku.Read())
            {
                frmliste fr = new frmliste();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adını ve şifrenizi kontrol ediniz.");
            }

            bgl.baglanti().Close();
        }

    }
    }

