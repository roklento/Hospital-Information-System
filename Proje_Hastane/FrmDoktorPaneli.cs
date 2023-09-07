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
    public partial class FrmDoktorPaneli : Form
    {
        public FrmDoktorPaneli()
        {
            InitializeComponent();
        }
        
        SqlBaglantisi sql = new SqlBaglantisi();
        private void FrmDoktorPaneli_Load(object sender, EventArgs e)
        {
            // doktorları datagride aktarma
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select *  from Tbl_Doktorlar", sql.Connection());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            // branşları cmboxa aktarma
            SqlCommand cmd = new SqlCommand("select BransAd From Tbl_Branslar", sql.Connection());
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                CmbBrans.Items.Add(dr[0]);
            }
            sql.Connection().Close();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Tbl_Doktorlar (DoktorAd, DoktorSoyad, DoktorBrans, DoktorTC, DoktorSifre) values (@p1, @p2, @p3, @p4, @p5)", sql.Connection());
            cmd.Parameters.AddWithValue("@p1", TxtAd.Text);
            cmd.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            cmd.Parameters.AddWithValue("@p3", CmbBrans.Text);
            cmd.Parameters.AddWithValue("@p4", MskTc.Text);
            cmd.Parameters.AddWithValue("@p5", TxtSifre.Text);
            cmd.ExecuteNonQuery();
            sql.Connection().Close();
            MessageBox.Show("Doktor Eklendi");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TxtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            CmbBrans.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            MskTc.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            TxtSifre.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete From Tbl_Doktorlar where DoktorTC = @p1", sql.Connection());
            cmd.Parameters.AddWithValue("@p1", MskTc.Text);
            cmd.ExecuteNonQuery();
            sql.Connection().Close();
            MessageBox.Show("Kayıtlı Doktor Silindi");
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update Tbl_Doktorlar set DoktorAd = @p1, DoktorSoyad = @p2, DoktorBrans = @p3, DoktorSifre = @p5 where DoktorTC = @p4", sql.Connection());
            cmd.Parameters.AddWithValue("@p1", TxtAd.Text);
            cmd.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            cmd.Parameters.AddWithValue("@p3", CmbBrans.Text);
            cmd.Parameters.AddWithValue("@p4", MskTc.Text);
            cmd.Parameters.AddWithValue("@p5", TxtSifre.Text);
            cmd.ExecuteNonQuery();
            sql.Connection().Close();
            MessageBox.Show("Doktor Güncellendi");
        }
    }
}
