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
    public partial class FrmDoktorDetay : Form
    {
        public FrmDoktorDetay()
        {
            InitializeComponent();
        }
        SqlBaglantisi sql = new SqlBaglantisi();
        public string tc;

        private void FrmDoktorDetay_Load(object sender, EventArgs e)
        {
            LblTc.Text = tc;

            // doktor ad soyad
            SqlCommand cmd = new SqlCommand("Select DoktorAd, DoktorSoyad From Tbl_Doktorlar where DoktorTc = @p1", sql.Connection());
            cmd.Parameters.AddWithValue("@p1", tc);
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                LblAdSoyad.Text = dr[0] + " " + dr[1];  
            }
            sql.Connection().Close();

            // randevular
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Randevular where RandevuDoktor = '" + LblAdSoyad.Text + "'", sql.Connection());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            FrmDoktorBilgiDüzenle fr = new FrmDoktorBilgiDüzenle();
            fr.tc = LblTc.Text;
            fr.Show();
        }

        private void BtnDuyurular_Click(object sender, EventArgs e)
        {
            FrmDuyurular fr = new FrmDuyurular();
            fr.Show();
        }

        private void BtnCıkıs_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            RchSikayet.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
        }
    }
}
