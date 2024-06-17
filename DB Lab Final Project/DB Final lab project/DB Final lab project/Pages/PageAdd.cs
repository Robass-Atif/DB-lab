using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Final_lab_project.Pages
{
    public partial class PageAdd : Form
    {
        public PageAdd()
        {
            InitializeComponent();
            showDataInWebsiteComboBox();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (comboBoxPageType.SelectedValue != null && comboBoxWebsiteID.SelectedValue != null && txtPageName.Text != null)
            {
                try
                {
                    var con = Configuration.getInstance().getConnection();

                    SqlCommand cmd = new SqlCommand("stpInsertPageOfWebsite", con);
                    cmd.Parameters.AddWithValue("@WebsiteID", int.Parse(comboBoxWebsiteID.SelectedValue.ToString()));
                    cmd.Parameters.AddWithValue("@PageType", getId(comboBoxPageType.SelectedValue.ToString()));
                    cmd.Parameters.AddWithValue("@PageName", txtPageName.Text);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Added");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void showDataInWebsiteComboBox()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT WebsiteId FROM WebsiteDataForInsertPage", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBoxWebsiteID.DataSource = dt;
            comboBoxWebsiteID.DisplayMember = "WebsiteId";
            comboBoxWebsiteID.ValueMember = "WebsiteId";
        }

        private void comboBoxWebsiteID_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxWebsiteID.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                int idx = int.Parse(comboBoxWebsiteID.SelectedValue.ToString());
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECT WebsiteName FROM PageInsertForWebsiteView WHERE WebsiteID = @WebsiteID", con);
                cmd.Parameters.AddWithValue("@WebsiteId", idx);
                object name = cmd.ExecuteScalar();
                txtWebsiteName.Text = name.ToString();

                cmd = new SqlCommand("SELECT WebsiteURL FROM PageInsertForWebsiteView WHERE WebsiteID = @WebsiteID", con);
                cmd.Parameters.AddWithValue("@WebsiteId", idx);
                name = cmd.ExecuteScalar();
                txtWebsiteURL.Text = name.ToString();
                showLookupPageTypes();
            }
        }

        private void showLookupPageTypes()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT Value FROM LookupPageTypesView", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBoxPageType.DataSource = dt;
            comboBoxPageType.DisplayMember = "Value";
            comboBoxPageType.ValueMember = "Value";
        }

        private int getId(string value)
        {
            SqlConnection con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT Id FROM LookupPageTypesView WHERE Value = @Value", con);
            cmd.Parameters.AddWithValue("@Value", value);
            return (Int32)cmd.ExecuteScalar();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            PageMenu form = new PageMenu();
            form.Show();
            this.Hide();
        }
    }
}
