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

namespace DB_Final_lab_project.Pages
{
    public partial class PageEdit : Form
    {
        public PageEdit()
        {
            InitializeComponent();
            showData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            PageMenu form = new PageMenu();
            form.Show();
            this.Hide();
        }

        private void showData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT PageID, WebsiteURL, PageName FROM EditPageView;", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvPage.DataSource = dt;

            DataGridViewColumn col = dgvPage.Columns["PageType"];
            col.DisplayIndex = 3;

            DataGridViewColumn pgId = dgvPage.Columns["PageId"];
            pgId.ReadOnly = true;

            DataGridViewColumn websiteURL = dgvPage.Columns["WebsiteURL"];
            websiteURL.ReadOnly = true;
        }

        private void dgvPage_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvPage.Columns[e.ColumnIndex].Name == "PageName")
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("stpUpdatePageName", con);
                    cmd.Parameters.AddWithValue("@NewPageName", dgvPage.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    cmd.Parameters.AddWithValue("@Id", int.Parse(dgvPage.Rows[e.RowIndex].Cells["PageID"].Value.ToString()));
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Edited");
                }

                else if (dgvPage.Columns[e.ColumnIndex].Name == "PageType")
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("stpUpdatePageType", con);
                    cmd.Parameters.AddWithValue("@NewPageType", dgvPage.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    cmd.Parameters.AddWithValue("@Id", int.Parse(dgvPage.Rows[e.RowIndex].Cells["PageID"].Value.ToString()));
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Edited");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Wrong Input" + ex);
            }
        }

        private void dgvPage_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
