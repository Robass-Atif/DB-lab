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
    public partial class SessionEdit : Form
    {
        public SessionEdit()
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
            SqlCommand cmd = new SqlCommand("SELECT SessionID, UserID, StartTime, EndTime, IPAddress, Device, Browser FROM SessionEditView;", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvSession.DataSource = dt;


            DataGridViewColumn sessionId = dgvSession.Columns["SessionID"];
            sessionId.ReadOnly = true;

            DataGridViewColumn pgId = dgvSession.Columns["UserID"];
            pgId.ReadOnly = true;
        }

        private void dgvPage_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvSession.Columns[e.ColumnIndex].Name == "StartTime")
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("stpUpdateStartTime", con);
                    cmd.Parameters.AddWithValue("@StartTime", dgvSession.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    cmd.Parameters.AddWithValue("@Id", int.Parse(dgvSession.Rows[e.RowIndex].Cells["SessionID"].Value.ToString()));
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Edited");
                }

                else if (dgvSession.Columns[e.ColumnIndex].Name == "EndTime")
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("stpUpdateEndTime", con);
                    cmd.Parameters.AddWithValue("@EndTime", dgvSession.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    cmd.Parameters.AddWithValue("@Id", int.Parse(dgvSession.Rows[e.RowIndex].Cells["SessionID"].Value.ToString()));
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Edited");
                }

                else if (dgvSession.Columns[e.ColumnIndex].Name == "IPAddress")
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("stpUpdateIPAddress", con);
                    cmd.Parameters.AddWithValue("@IpAddres", dgvSession.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    cmd.Parameters.AddWithValue("@Id", int.Parse(dgvSession.Rows[e.RowIndex].Cells["SessionID"].Value.ToString()));
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Edited");
                }

                else if (dgvSession.Columns[e.ColumnIndex].Name == "Device")
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("stpUpdateDevice", con);
                    cmd.Parameters.AddWithValue("@Device", dgvSession.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    cmd.Parameters.AddWithValue("@Id", int.Parse(dgvSession.Rows[e.RowIndex].Cells["SessionID"].Value.ToString()));
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Edited");
                }

                else if (dgvSession.Columns[e.ColumnIndex].Name == "Browser")
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("stpUpdateBrowser", con);
                    cmd.Parameters.AddWithValue("@Browser", dgvSession.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    cmd.Parameters.AddWithValue("@Id", int.Parse(dgvSession.Rows[e.RowIndex].Cells["SessionID"].Value.ToString()));
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
    }
}
