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

namespace DB_Final_lab_project.Section
{
    public partial class Update_Section : Form
    {
       

        public Update_Section()
        {
            InitializeComponent();
            loadData();
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
        }
        void loadData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select PageSectionId,PageID,TimeSpan from  PageSection", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            DataGridViewColumn col = dataGridView1.Columns["PageSectionId"];
            col.ReadOnly = true;

            DataGridViewColumn col1 = dataGridView1.Columns["PageId"];
            col1.ReadOnly = true;

            DataGridViewColumn col2 = dataGridView1.Columns["SectionCategory"];
            col2.DisplayIndex = 3;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SectionMenu sectionMenu = new SectionMenu();
            sectionMenu.Show();
            this.Close();

        }
        
        public static string ConvertToDatabaseTime(string timeString)
        {
            // Parse the string into a TimeSpan
            if (TimeSpan.TryParse(timeString, out TimeSpan timeSpanValue))
            {
                // Convert the TimeSpan into a formatted time string for the database (HH:mm:ss)
                string databaseTimeFormat = timeSpanValue.ToString(@"hh\:mm\:ss");
                return databaseTimeFormat;
            }
            else
            {
                // Handle parsing failure, e.g., the input string doesn't represent a valid time
                return "Invalid Time Format";
            }
        }



        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "TimeSpan")
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("stpUpdatePageSectionTimeSpan", con);

                    // Assuming you have a function ConvertToDatabaseTime as described in the previous message
                    string timeString = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    string formattedTime = ConvertToDatabaseTime(timeString);

                    cmd.Parameters.AddWithValue("@TimeSpan", formattedTime);
                    cmd.Parameters.AddWithValue("@PageSectionId", int.Parse(dataGridView1.Rows[e.RowIndex].Cells["PageSectionId"].Value.ToString()));
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("TimeSpan Edited");
                }

                else if (dataGridView1.Columns[e.ColumnIndex].Name == "SectionCategory")
                {
                    try
                    {
                        var con = Configuration.getInstance().getConnection();
                        SqlCommand selectCmd = new SqlCommand("SELECT ID FROM Lookup WHERE Value = @SectionCategory", con);
                        selectCmd.Parameters.AddWithValue("@SectionCategory", dataGridView1.Rows[e.RowIndex].Cells["SectionCategory"].Value.ToString() ); // Replace yourSectionCategoryValueHere with the actual value you want to use
                        object result = selectCmd.ExecuteScalar();

                        if (result != null)
                        {
                            int sectionCategoryID = Convert.ToInt32(result);
                            SqlCommand updateCmd = new SqlCommand("stpUpdatePageSectionCategory", con);
                            updateCmd.Parameters.AddWithValue("@SectionCategory", sectionCategoryID);
                            updateCmd.Parameters.AddWithValue("@PageSectionId", int.Parse(dataGridView1.Rows[e.RowIndex].Cells["PageSectionId"].Value.ToString()));
                            updateCmd.CommandType = CommandType.StoredProcedure;
                            updateCmd.ExecuteNonQuery();
                            MessageBox.Show("Section Category Edited");
                        }
                        else
                        {
                            MessageBox.Show("Section Category not found in the lookup table.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Wrong Input" + ex);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Update_Section_Load(object sender, EventArgs e)
        {

        }
    }
}
