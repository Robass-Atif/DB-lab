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

namespace DB_Final_lab_project.Session
{
    public partial class SessionView : Form
    {
        public SessionView()
        {
            InitializeComponent();
            showData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            SessionMenu form = new SessionMenu();
            form.Show();
            this.Hide();
        }

        private void showData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM ShowSessionDataView;", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvSession.DataSource = dt;
        }
    }
}
