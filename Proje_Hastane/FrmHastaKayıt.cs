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
    public partial class FrmHastaKayıt : Form
    {
        public FrmHastaKayıt()
        {
            InitializeComponent();
        }
        
        SqlBaglantisi sql = new SqlBaglantisi();
        private void BtnKayıtYap_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Tbl_Hastalar (HastaAd, HastaSoyad, HastaTC, HastaTelefon, HastaSifre, HastaCinsiyet) values (@p1, @p2, @p3, @p4, @p5, @p6)", sql.Connection());
            cmd.Parameters.AddWithValue("@p1", TxtHastaAd.Text);
            cmd.Parameters.AddWithValue("@p2", TxtHastaSoyad.Text);
            cmd.Parameters.AddWithValue("@p3", MskTckimlikno.Text);
            cmd.Parameters.AddWithValue("@p4", MskTelefon.Text);
            cmd.Parameters.AddWithValue("@p5", TxtSifre.Text);
            cmd.Parameters.AddWithValue("@p6", CmbCinsiyet.Text);
            cmd.ExecuteNonQuery();
            sql.Connection().Close();
            MessageBox.Show("Kaydınız Gerçekleşmiştir Şifreniz: " + TxtSifre.Text, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
