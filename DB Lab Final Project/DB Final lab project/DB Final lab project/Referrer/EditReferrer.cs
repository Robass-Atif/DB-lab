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
    public partial class EditReferrer : Form
    {
        public EditReferrer()
        {
            InitializeComponent();
            GetData();
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new ReferrerMenu();
            f.Show();
            this.Hide();
        }


        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (dataGridView1.Columns[e.ColumnIndex].Name == "ReferrerName")
                {


                    var con = Configuration.getInstance().getConnection();

                    SqlCommand cmd = new SqlCommand("stpUpdateReferrerName", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ReferrerName", dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    cmd.Parameters.AddWithValue("@ReferrerID", int.Parse(dataGridView1.Rows[e.RowIndex].Cells["ReferrerID"].Value.ToString()));
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Edited");
                }

                else if (dataGridView1.Columns[e.ColumnIndex].Name == "ReferrerURL")
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("stpUpdateReferrerURL", con);
                    cmd.Parameters.AddWithValue("@URL", dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    cmd.Parameters.AddWithValue("@ReferrerID", int.Parse(dataGridView1.Rows[e.RowIndex].Cells["ReferrerID"].Value.ToString()));
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Edited");
                }


                else if (dataGridView1.Columns[e.ColumnIndex].Name == "WebsiteName")
                {
                    var con = Configuration.getInstance().getConnection();


                    string selectedName = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();


                    SqlCommand lookupCmd = new SqlCommand("stpGetWebsiteID", con);
                    lookupCmd.Parameters.AddWithValue("@WebsiteName", selectedName);
                    lookupCmd.CommandType = CommandType.StoredProcedure;
                    int websiteID = Convert.ToInt32(lookupCmd.ExecuteScalar());


                    SqlCommand cmd = new SqlCommand("stpUpdateReferrerWebsiteName", con);
                    cmd.Parameters.AddWithValue("@WebsiteID", websiteID);
                    cmd.Parameters.AddWithValue("@ReferrerID", int.Parse(dataGridView1.Rows[e.RowIndex].Cells["ReferrerID"].Value.ToString()));
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Edited");
                }


                else if (dataGridView1.Columns[e.ColumnIndex].Name == "ReferrerType")
                {
                    var con = Configuration.getInstance().getConnection();


                    string referrerType = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();


                    SqlCommand lookupCmd = new SqlCommand("stpGetReferrerTypeID", con);
                    lookupCmd.Parameters.AddWithValue("@Value", referrerType);
                    lookupCmd.CommandType = CommandType.StoredProcedure;
                    int referrerTypeID = Convert.ToInt32(lookupCmd.ExecuteScalar());


                    SqlCommand cmd = new SqlCommand("stpUpdateReferrerType", con);
                    cmd.Parameters.AddWithValue("@ReferrerType", referrerTypeID);
                    cmd.Parameters.AddWithValue("@ReferrerID", int.Parse(dataGridView1.Rows[e.RowIndex].Cells["ReferrerID"].Value.ToString()));
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



        private void GetData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select ReferrerID , ReferrerName , ReferrerURL from EditReferrerView", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            dataGridView1.DataSource = dt;


            DataGridViewColumn webId = dataGridView1.Columns["ReferrerID"];
            webId.ReadOnly = true;


            DataGridViewComboBoxColumn industryColumn = new DataGridViewComboBoxColumn();
            industryColumn.HeaderText = "WebsiteName";
            industryColumn.Name = "WebsiteName";

            SqlCommand cmd2 = new SqlCommand("Select WebsiteName from GetWebsiteNameView", con);
           

            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();

            da2.Fill(dt2);


            industryColumn.DataSource = dt2;
            industryColumn.DisplayMember = "WebsiteName";
            industryColumn.ValueMember = "WebsiteName";


            DataGridViewComboBoxColumn referrerTypeColumn = new DataGridViewComboBoxColumn();
            referrerTypeColumn.HeaderText = "ReferrerType";
            referrerTypeColumn.Name = "ReferrerType";

            SqlCommand cmd3 = new SqlCommand("Select Value from GetReferrerType", con);


            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            DataTable dt3 = new DataTable();

            da3.Fill(dt3);


            referrerTypeColumn.DataSource = dt3;
            referrerTypeColumn.DisplayMember = "Value";
            referrerTypeColumn.ValueMember = "Value";




            if (dataGridView1.Columns.Contains("WebsiteName"))
            {

                DataGridViewColumn existingColumn = dataGridView1.Columns["WebsiteName"];


                int existingColumnIndex = existingColumn.Index;


                dataGridView1.Columns.Remove(existingColumn);


                dataGridView1.Columns.Insert(existingColumnIndex, industryColumn);
            }
            else
            {

                dataGridView1.Columns.Add(industryColumn);
            }



            if (dataGridView1.Columns.Contains("ReferrerType"))
            {

                DataGridViewColumn existingColumn = dataGridView1.Columns["ReferrerType"];


                int existingColumnIndex = existingColumn.Index;


                dataGridView1.Columns.Remove(existingColumn);


                dataGridView1.Columns.Insert(existingColumnIndex, referrerTypeColumn);
            }
            else
            {

                dataGridView1.Columns.Add(referrerTypeColumn);
            }






        }
    }
}
