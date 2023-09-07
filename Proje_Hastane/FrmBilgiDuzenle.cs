using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje_Hastane
{
    public partial class FrmBilgiDuzenle : Form
    {
        public FrmBilgiDuzenle()
        {
            InitializeComponent();
        }

        public string tc;

        SqlBaglantisi sql = new SqlBaglantisi();
        private void FrmBilgiDuzenle_Load(object sender, EventArgs e)
        {
            MskTckimlikno.Text = tc;
            SqlCommand cmd = new SqlCommand("Select * from Tbl_Hastalar where HastaTC = @p1", sql.Connection());
            cmd.Parameters.AddWithValue("@p1", MskTckimlikno.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                TxtHastaAd.Text = dr[1].ToString();
                TxtHastaSoyad.Text = dr[2].ToString();
                MskTelefon.Text = dr[4].ToString();
                TxtSifre.Text = dr[5].ToString();
                CmbCinsiyet.Text = dr[6].ToString();
            }
            sql.Connection().Close();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update Tbl_Hastalar set HastaAd = @p1, HastaSoyad = @p2, HastaTelefon = @p3, HastaSifre = @p4, HastaCinsiyet = @p5 where HastaTC = @p6", sql.Connection());
            cmd.Parameters.AddWithValue("@p1", TxtHastaAd.Text);
            cmd.Parameters.AddWithValue("@p2", TxtHastaSoyad.Text);
            cmd.Parameters.AddWithValue("@p3", MskTelefon.Text);
            cmd.Parameters.AddWithValue("@p4", TxtSifre.Text);
            cmd.Parameters.AddWithValue("@p5", CmbCinsiyet.Text);
            cmd.Parameters.AddWithValue("@p6", MskTckimlikno.Text);
            cmd.ExecuteNonQuery();
            sql.Connection().Close();
            MessageBox.Show("Bilgileriniz Güncellendi" , "Bilgi", MessageBoxButtons.OK,  MessageBoxIcon.Warning);
        }
    }
}
