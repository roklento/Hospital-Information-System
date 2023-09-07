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
    public partial class FrmSekreterDetay : Form
    {
        public FrmSekreterDetay()
        {
            InitializeComponent();
        }

        public string tc;
        SqlBaglantisi sql = new SqlBaglantisi();
        private void FrmSekreterDetay_Load(object sender, EventArgs e)
        {
            LblTc.Text = tc;

            // ad soyad ekleme
            SqlCommand cmd = new SqlCommand("Select SekreterAdSoyad from Tbl_Sekreter where SekreterTC = @p1", sql.Connection());
            cmd.Parameters.AddWithValue("@p1", LblTc.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                LblAdSoyad.Text = dr[0].ToString();
            }
            
            sql.Connection().Close();

            // branşları datagride aktarma
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Branslar", sql.Connection());
            da.Fill(dt);
            dataGridView2.DataSource = dt;

            // doktorları datagride aktarma
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select (DoktorAd + ' ' + DoktorSoyad) as 'Doktorlar', DoktorBrans from Tbl_Doktorlar", sql.Connection());
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;

            //Branşı comboboxa aktarma
            SqlCommand cmd2 = new SqlCommand("Select BransAd from Tbl_Branslar", sql.Connection());
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while(dr2.Read())
            {
                CmbBrans.Items.Add(dr2[0]);
            }
            sql.Connection().Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Tbl_Randevular (RandevuTarih, RandevuSaat, RandevuBrans, RandevuDoktor) values (@p1, @p2, @p3, @p4)", sql.Connection());
            cmd.Parameters.AddWithValue("@p1", MskRandevuTarih.Text);
            cmd.Parameters.AddWithValue("@p2", MskRandevuSaat.Text);
            cmd.Parameters.AddWithValue("@p3", CmbBrans.Text);
            cmd.Parameters.AddWithValue("@p4", CmbDoktor.Text);
            cmd.ExecuteNonQuery();
            sql.Connection().Close();
            MessageBox.Show("Randevu Oluşturuldu.");
        }

        private void CmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbDoktor.Items.Clear();

            SqlCommand cmd = new SqlCommand("Select DoktorAd, DoktorSoyad from Tbl_Doktorlar where DoktorBrans = @p1", sql.Connection());
            cmd.Parameters.AddWithValue("@p1", CmbBrans.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                CmbDoktor.Items.Add(dr[0] + " " + dr[1]);
            }
            sql.Connection().Close();
        }

        private void BtnDuyuruOlustur_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Tbl_Duyurular (Duyuru) values (@p1)", sql.Connection());
            cmd.Parameters.AddWithValue("@p1", RchDuyuru.Text);
            cmd.ExecuteNonQuery();
            sql.Connection().Close();
            MessageBox.Show("Duyuru oluşturuldu.");
        }

        private void BtnDoktorPanel_Click(object sender, EventArgs e)
        {
            FrmDoktorPaneli fr = new FrmDoktorPaneli();
            fr.Show();
        }

        private void BtnBransPanel_Click(object sender, EventArgs e)
        {
            FrmBrans fr = new FrmBrans();
            fr.Show();
        }

        private void BtnRandevuListe_Click(object sender, EventArgs e)
        {
            FrmRandevuListe fr = new FrmRandevuListe();
            fr.Show();
        }

        private void BtnDuyurular_Click(object sender, EventArgs e)
        {
            FrmDuyurular fr = new FrmDuyurular();
            fr.Show();
        }
    }
}
