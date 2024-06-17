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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DB_Final_lab_project.Website
{
    public partial class EditWebsite : Form
    {
        public EditWebsite()
        {
            
            InitializeComponent();
            GetData();
            WebsiteDGV.CellValueChanged += WebsiteDGV_CellValueChanged;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void WebsiteDGV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                if (WebsiteDGV.Columns[e.ColumnIndex].Name == "WebsiteName")
                {
                

                    var con = Configuration.getInstance().getConnection();

                    SqlCommand cmd = new SqlCommand("stpUpdateWebsiteName", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@WebsiteName", WebsiteDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    cmd.Parameters.AddWithValue("@WebsiteID", int.Parse(WebsiteDGV.Rows[e.RowIndex].Cells["WebsiteID"].Value.ToString()));
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Edited");
                }

                else if (WebsiteDGV.Columns[e.ColumnIndex].Name == "WebsiteURL")
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("stpUpdateWebsiteURL", con);
                    cmd.Parameters.AddWithValue("@URL", WebsiteDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    cmd.Parameters.AddWithValue("@WebsiteID", int.Parse(WebsiteDGV.Rows[e.RowIndex].Cells["WebsiteID"].Value.ToString()));
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Edited");
                }


                else if (WebsiteDGV.Columns[e.ColumnIndex].Name == "WebsiteIndustry")
                {
                    var con = Configuration.getInstance().getConnection();

                    
                    string selectedIndustry = WebsiteDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                    
                    SqlCommand lookupCmd = new SqlCommand("stpGetLookupIDForWebsite", con);
                    lookupCmd.Parameters.AddWithValue("@Value", selectedIndustry);
                    lookupCmd.CommandType = CommandType.StoredProcedure;
                    int industryID = Convert.ToInt32(lookupCmd.ExecuteScalar());

                    
                    SqlCommand cmd = new SqlCommand("stpUpdateWebsiteIndustry", con);
                    cmd.Parameters.AddWithValue("@WebsiteIndustry", industryID);
                    cmd.Parameters.AddWithValue("@WebsiteID", int.Parse(WebsiteDGV.Rows[e.RowIndex].Cells["WebsiteID"].Value.ToString()));
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Edited");
                }


                else if (WebsiteDGV.Columns[e.ColumnIndex].Name == "Description")
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("stpUpdateWebsiteDescription", con);
                    cmd.Parameters.AddWithValue("@Description", WebsiteDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    cmd.Parameters.AddWithValue("@WebsiteID", int.Parse(WebsiteDGV.Rows[e.RowIndex].Cells["WebsiteID"].Value.ToString()));
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
            SqlCommand cmd = new SqlCommand("Select WebsiteID , WebsiteName , WebsiteURL ,  Description from EditWebsiteView", con);
            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            
            da.Fill(dt);
            WebsiteDGV.DataSource = dt;


            DataGridViewColumn webId = WebsiteDGV.Columns["WebsiteID"];
            webId.ReadOnly = true;


            DataGridViewComboBoxColumn industryColumn = new DataGridViewComboBoxColumn();
            industryColumn.HeaderText = "WebsiteIndustry";
            industryColumn.Name = "WebsiteIndustry";

            SqlCommand cmd2 = new SqlCommand("stpGetWebsiteIndustryFromLookup", con);
            cmd2.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();

            da2.Fill(dt2);


            industryColumn.DataSource = dt2;
            industryColumn.DisplayMember = "Value";
            industryColumn.ValueMember = "Value";




            if (WebsiteDGV.Columns.Contains("WebsiteIndustry"))
            {
                
                DataGridViewColumn existingColumn = WebsiteDGV.Columns["WebsiteIndustry"];

                
                int existingColumnIndex = existingColumn.Index;

                
                WebsiteDGV.Columns.Remove(existingColumn);

               
                WebsiteDGV.Columns.Insert(existingColumnIndex, industryColumn);
            }
            else
            {
                
                WebsiteDGV.Columns.Add(industryColumn);
            }






        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new WebsiteMenu();
            f.Show();
            this.Hide();
        }
    }
}
