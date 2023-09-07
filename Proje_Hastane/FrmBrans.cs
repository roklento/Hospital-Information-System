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
    public partial class FrmBrans : Form
    {
        public FrmBrans()
        {
            InitializeComponent();
        }

        SqlBaglantisi sql = new SqlBaglantisi();

        private void FrmBrans_Load(object sender, EventArgs e)
        {
            // datagride branları aktarma
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Branslar", sql.Connection());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Tbl_Branslar(BransAd) values (@p1)", sql.Connection());
            cmd.Parameters.AddWithValue("@p1", TxtAd.Text);
            cmd.ExecuteNonQuery();
            sql.Connection().Close();
            MessageBox.Show("Branş Eklendi");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TxtId.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete from Tbl_Branslar where Bransid = @p1", sql.Connection());
            cmd.Parameters.AddWithValue("@p1", TxtId.Text);
            cmd.ExecuteNonQuery();
            sql.Connection().Close();
            MessageBox.Show("Branş Silindi");
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update Tbl_Branslar set BransAd = @p1 where Bransid = @p2", sql.Connection());
            cmd.Parameters.AddWithValue("@p1", TxtAd.Text);
            cmd.Parameters.AddWithValue("@p2", TxtId.Text);
            cmd.ExecuteNonQuery();
            sql.Connection().Close();
            MessageBox.Show("Branş Güncellendi");
        }
    }
}
