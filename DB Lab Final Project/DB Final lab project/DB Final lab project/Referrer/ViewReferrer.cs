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

namespace DB_Final_lab_project.Referrer
{
    public partial class ViewReferrer : Form
    {
        public ViewReferrer()
        {
            InitializeComponent();
        }

        private void ViewReferrer_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        private void ShowData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM ShowReferrerView", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new ReferrerMenu();
            f.Show();
            this.Close();
        }
    }
}
