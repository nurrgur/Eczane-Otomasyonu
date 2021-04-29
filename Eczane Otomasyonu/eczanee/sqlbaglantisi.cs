using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace eczanee
{
    class sqlbaglantisi
    {
        

        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=eczane;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
