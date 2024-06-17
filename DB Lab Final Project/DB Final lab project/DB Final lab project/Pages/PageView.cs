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
    public partial class PageView : Form
    {
        public PageView()
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
            SqlCommand cmd = new SqlCommand("SELECT PageID, WebsiteID, WebsiteURL, PageName, PageType, PageViews, TimeSpent FROM ShowPagesView;", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvPage.DataSource = dt;
        }

        private void dgvPage_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
