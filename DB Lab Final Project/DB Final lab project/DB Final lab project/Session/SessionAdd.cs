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
    public partial class SessionAdd : Form
    {
        public SessionAdd()
        {
            InitializeComponent();
            showDataInWebsiteComboBox();
            addColumnsInDGV();
            showDataInUserComboBox();
            dateTimePickerStart.Format = DateTimePickerFormat.Time;
            dateTimePickerStart.ShowUpDown = true;
            dateTimePickerStart.CustomFormat = "HH:mm:ss";
            dateTimePickerEndTime.Format = DateTimePickerFormat.Time;
            dateTimePickerEndTime.ShowUpDown = true;
            dateTimePickerEndTime.CustomFormat = "HH:mm:ss";
        }

        private void addColumnsInDGV()
        {
            dgvPagesOfSession.Columns.Add("PageID", "PageID");
            dgvPagesOfSession.Columns.Add("WebsiteID", "WebsiteID");
            dgvPagesOfSession.Columns.Add("PageName", "PageName");
            dgvPagesOfSession.Columns.Add("PageType", "PageType");
            dgvPagesOfSession.Columns.Add("PageViews", "PageViews");
            dgvPagesOfSession.Columns.Add("TimeSpent", "TimeSpent");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            SessionMenu form = new SessionMenu();
            form.Show();
            this.Hide();
        }

        private void showDataInWebsiteComboBox()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT WebsiteId FROM PageInsertForWebsiteView", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBoxWebsites.DataSource = dt;
            comboBoxWebsites.DisplayMember = "WebsiteId";
            comboBoxWebsites.ValueMember = "WebsiteId";
        }

        private void showDataInUserComboBox()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT UserID FROM UserIDsForSessionAddView", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBoxUser.DataSource = dt;
            comboBoxUser.DisplayMember = "UserID";
            comboBoxUser.ValueMember = "UserID";
        }

        private void comboBoxWebsites_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxWebsites.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                int idx = int.Parse(comboBoxWebsites.SelectedValue.ToString());
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECT WebsiteURL FROM PageInsertForWebsiteView WHERE WebsiteID = @WebsiteID", con);
                cmd.Parameters.AddWithValue("@WebsiteId", idx);
                object name = cmd.ExecuteScalar();
                txtURL.Text = name.ToString();
                showPages();
            }
        }

        private void showPages()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("stpGetPagesOfGivenWebsite", con);
            cmd.Parameters.AddWithValue("@WebsiteID", int.Parse(comboBoxWebsites.SelectedValue.ToString()));
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBoxPages.DataSource = dt;
            comboBoxPages.DisplayMember = "PageID";
            comboBoxPages.ValueMember = "PageID";
        }


        private void comboBoxPages_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxPages.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("stpGetPageNameFromGivenPageID", con);
                cmd.Parameters.AddWithValue("@PageID", int.Parse(comboBoxPages.SelectedValue.ToString()));
                cmd.CommandType = CommandType.StoredProcedure;
                object obj = cmd.ExecuteScalar();
                txtPage.Text = obj.ToString();
            }
        }

        private void btnAddPage_Click(object sender, EventArgs e)
        {
            if (comboBoxPages.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("stpGetPageRowForGivenPageID", con);
                cmd.Parameters.AddWithValue("@PageID", int.Parse(comboBoxPages.SelectedValue.ToString()));
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                DataRow row = dt.Rows[0];
                DataGridViewRow dgvr = new DataGridViewRow();
                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                    cell.Value = row[i];

                    dgvr.Cells.Add(cell);
                }
                dgvPagesOfSession.Rows.Add(dgvr);
            }
        }

        private void btnAddSession_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxUser.SelectedValue != null && comboBoxWebsites.SelectedValue != null && dgvPagesOfSession.Rows.Count > 0 && txtIP.Text != "")
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("stpInsertSession", con);
                    cmd.Parameters.AddWithValue("@UserID", int.Parse(comboBoxUser.SelectedValue.ToString()));
                    cmd.Parameters.AddWithValue("@StartTime", dateTimePickerStart.Value);
                    cmd.Parameters.AddWithValue("@EndTime", dateTimePickerEndTime.Value);
                    cmd.Parameters.AddWithValue("@IPAddress", txtIP.Text);
                    cmd.Parameters.AddWithValue("@Device", txtDevice.Text);
                    cmd.Parameters.AddWithValue("@Browser", txtBrowser.Text);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("SELECT SessionID FROM GetSessionIDView", con);
                    int sessionId = (Int32)cmd.ExecuteScalar();

                    cmd = new SqlCommand("stpUpdateWebsiteVisitAfterSession", con);
                    cmd.Parameters.AddWithValue("@PageID", dgvPagesOfSession.Rows[0].Cells["PageID"].Value);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    for (int i = 0; i < dgvPagesOfSession.Rows.Count; i++)
                    {
                        cmd = new SqlCommand("stpInsertSessionPage", con);
                        cmd.Parameters.AddWithValue("@SessionID", sessionId);
                        cmd.Parameters.AddWithValue("@PageID", int.Parse(dgvPagesOfSession.Rows[i].Cells["PageID"].Value.ToString()));
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Session Added");
                }
            }

            catch 
            {
                MessageBox.Show("Error");
            }
        }

        private void comboBoxUser_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxUser.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("stpGetUserByID", con);
                cmd.Parameters.AddWithValue("@UserID", int.Parse(comboBoxUser.SelectedValue.ToString()));
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvUserData.DataSource = dt;
            }
        }

        private void SessionAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
