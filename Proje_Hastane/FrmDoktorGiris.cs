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

namespace Proje_Hastane
{
    public partial class FrmDoktorGiris : Form
    {
        public FrmDoktorGiris()
        {
            InitializeComponent();
        }
        SqlBaglantisi sql = new SqlBaglantisi();

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * From Tbl_Doktorlar where DoktorTC = @p1 and DoktorSifre = @p2", sql.Connection());
            cmd.Parameters.AddWithValue("@p1", MskTckimlikno.Text);
            cmd.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                FrmDoktorDetay fr = new FrmDoktorDetay();
                fr.tc = MskTckimlikno.Text;
                fr.Show();
                this.Hide();
            }
            else 
            {
                MessageBox.Show("Hatalı TC ya da Şifre");
            }
            sql.Connection().Close();
        }
    }
}
