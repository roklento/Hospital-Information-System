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
    public partial class FrmDoktorBilgiDüzenle : Form
    {
        public FrmDoktorBilgiDüzenle()
        {
            InitializeComponent();
        }
        public string tc;
        SqlBaglantisi sql = new SqlBaglantisi();
        private void FrmDoktorBilgiDüzenle_Load(object sender, EventArgs e)
        {
            MskTckimlikno.Text = tc;
            SqlCommand cmd = new SqlCommand("Select * from Tbl_Doktorlar where DoktorTC = @p1", sql.Connection());
            cmd.Parameters.AddWithValue("@p1", MskTckimlikno.Text);
            SqlDataReader rd = cmd.ExecuteReader();
            while(rd.Read())
            {
                TxtdoktorAd.Text = rd[1].ToString();
                TxtdoktorSoyad.Text = rd[2].ToString();
                CmbBrans.Text = rd[3].ToString();
                TxtSifre.Text = rd[5].ToString();
            }
            sql.Connection().Close();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update Tbl_Doktorlar set DoktorAd = @p1, DoktorSoyad = @p2, DoktorBrans = @p3, DoktorSifre = @p4 where DoktorTc = @p5", sql.Connection());
            cmd.Parameters.AddWithValue("@p1", TxtdoktorAd.Text);
            cmd.Parameters.AddWithValue("@p2", TxtdoktorSoyad.Text);
            cmd.Parameters.AddWithValue("@p3", CmbBrans.Text);
            cmd.Parameters.AddWithValue("@p4", TxtSifre.Text);
            cmd.Parameters.AddWithValue("@p5", MskTckimlikno.Text);
            cmd.ExecuteNonQuery();
            sql.Connection().Close();
            MessageBox.Show("Bilgiler Güncellendi");
        }
    }
}
