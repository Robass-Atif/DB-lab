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
    public partial class SessionDelete : Form
    {
        public SessionDelete()
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

        private void dgvSession_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                try
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("stpDeleteSession", con);
                    cmd.Parameters.AddWithValue("@PageSectionId", dgvSession.CurrentRow.Cells["SessionID"].Value.ToString());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Row Deleted");
                    showData();
                }

                catch (SqlException ex)
                {
                    MessageBox.Show("Row Not deleted due to error: " + ex.Message);
                }
            }
        }

        private void showData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT SessionID, UserID, StartTime, EndTime, IPAddress, Device, Browser FROM SessionEditView;", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvSession.DataSource = dt;
        }
    }
}
