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
    public partial class PageMenu : Form
    {
        public PageMenu()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PageAdd form = new PageAdd();
            form.Show();
            this.Hide();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            PageEdit form = new PageEdit();
            form.Show();
            this.Hide();
        }

        private void btnViewAllPages_Click(object sender, EventArgs e)
        {
            PageView form = new PageView();
            form.Show();
            this.Hide();
        }

        private void btnDeletePage_Click(object sender, EventArgs e)
        {
            PageDelete form = new PageDelete();
            form.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("stpRefreshTimeSpentOnPages", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Time Spent Updated");
        }
    }
}
