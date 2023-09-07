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
    public partial class FrmHastaDetay : Form
    {
        public FrmHastaDetay()
        {
            InitializeComponent();
        }
        public string tc;

        SqlBaglantisi sql = new SqlBaglantisi();
        private void FrmHastaDetay_Load(object sender, EventArgs e)
        {
            LblTc.Text = tc;

            // Ad Soyad Çekme
            SqlCommand cmd = new SqlCommand("Select HastaAd, HastaSoyad From Tbl_Hastalar where HastaTC = @p1", sql.Connection());
            cmd.Parameters.AddWithValue("@p1", tc);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                LblAdSoyad.Text = reader[0] + " " + reader[1];
            }
            sql.Connection().Close();

            // Randevu geçmişi
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Randevular where HastaTC =" + tc, sql.Connection());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            // Branş Ekleme
            SqlCommand cmd2 = new SqlCommand("Select BransAd From Tbl_Branslar", sql.Connection());
            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                Cmbbrans.Items.Add(reader2[0]);
            }

            sql.Connection().Close();
        }

        private void Cmbbrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbDoktor.Items.Clear();

            SqlCommand cmd = new SqlCommand("Select DoktorAd, DoktorSoyad from Tbl_Doktorlar where DoktorBrans = @p1", sql.Connection());
            cmd.Parameters.AddWithValue("@p1", Cmbbrans.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CmbDoktor.Items.Add(reader[0] + " " + reader[1]);
            }
            sql.Connection().Close();
        }

        private void CmbDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Randevular where RandevuBrans = '" + Cmbbrans.Text + "'" + " and RandevuDoktor = '" + CmbDoktor.Text + "' and RandevuDurum = 0", sql.Connection());
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void LnkBilgiduzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBilgiDuzenle fr = new FrmBilgiDuzenle();
            fr.tc = LblTc.Text;
            fr.Show();

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            TxtId.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
        }

        private void BtnRandevu_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update Tbl_Randevular Set RandevuDurum = 1, HastaTc = @p1, HastaSikayet = @p2 where Randevuid = @p3", sql.Connection());
            cmd.Parameters.AddWithValue("@p1", LblTc.Text);
            cmd.Parameters.AddWithValue("@p2", RchSikayet.Text);
            cmd.Parameters.AddWithValue("@p3", TxtId.Text);
            cmd.ExecuteNonQuery();
            sql.Connection().Close();
            MessageBox.Show("Randevu Alındı");
        }
    }
}
