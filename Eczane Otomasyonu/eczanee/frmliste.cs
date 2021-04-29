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
    public partial class frmliste : Form
    {
       
        public frmliste()
        {
            InitializeComponent();
        }
      
        private void btnilc_Click_1(object sender, EventArgs e)
        {
            frmilac fr = new frmilac();
            fr.Show();
            this.Hide();
        }

        private void btnsatis_Click_1(object sender, EventArgs e)
        {
            frmsatis fr = new frmsatis();
            fr.Show();
            this.Hide();
        }

        private void btnpersonel_Click(object sender, EventArgs e)
        {
            frmpersonel fr = new frmpersonel();
            fr.Show();
            this.Hide();
        }

        private void btnkayit_Click_1(object sender, EventArgs e)
        {
             frmkayit  fr= new frmkayit();
            fr.Show();
            this.Hide();

        }

        private void btnbolum_Click(object sender, EventArgs e)
        {
            frmbolum fr = new frmbolum();
            fr.Show();
            this.Hide();

        }

        private void btncikis_CheckedChanged(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
