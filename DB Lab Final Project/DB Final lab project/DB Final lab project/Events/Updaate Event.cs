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

namespace DB_Final_lab_project.Events
{
    public partial class Updaate_Event : Form
    {
        public Updaate_Event()
        {
            InitializeComponent();
            loadData();

            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
        }
        void loadData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select EventID,PageSectionID,EventTime,EventDetails from  Events", con);
                
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;


            DataGridViewColumn col = dataGridView1.Columns["PageSectionId"];
            col.ReadOnly = true;

            DataGridViewColumn col1 = dataGridView1.Columns["EventID"];
            col1.ReadOnly = true;


            DataGridViewColumn col2 = dataGridView1.Columns["EventType"];
            col2.DisplayIndex = 3;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Event_Menu event_Menu = new Event_Menu();
            event_Menu.Show();
            this.Close();

        }

        private void Updaate_Event_Load(object sender, EventArgs e)
        {

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

        int getEventType()
        {
            return 0;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "EventTime")
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("stpUpdateEventTime", con);

                    // Assuming you have a function ConvertToDatabaseTime as described in the previous message
                    string timeString = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    string formattedTime = ConvertToDatabaseTime(timeString);

                    cmd.Parameters.AddWithValue("@EventTime", formattedTime);
                    cmd.Parameters.AddWithValue("@EventID", int.Parse(dataGridView1.Rows[e.RowIndex].Cells["EventID"].Value.ToString()));
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("EventTime Edited");
                }

                else if (dataGridView1.Columns[e.ColumnIndex].Name == "EventDetails")
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("stpUpdateEventDetails", con);
                    cmd.Parameters.AddWithValue("@EventDetails", dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    cmd.Parameters.AddWithValue("@EventID", int.Parse(dataGridView1.Rows[e.RowIndex].Cells["EventID"].Value.ToString()));
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Event Details Edited");
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "EventType")
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("SELECT Id FROM lookUp WHERE Value = @EventType", con);
                    cmd.Parameters.AddWithValue("@EventType", dataGridView1.Rows[e.RowIndex].Cells["EventType"].Value.ToString()); // Replace yourEventTypeValueHere with the actual value you want to use
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        int eventTypeID = Convert.ToInt32(result);
                        SqlCommand updateCmd = new SqlCommand("stpUpdateEventType", con);
                        updateCmd.Parameters.AddWithValue("@EventType", eventTypeID);
                        updateCmd.Parameters.AddWithValue("@EventID", int.Parse(dataGridView1.Rows[e.RowIndex].Cells["EventID"].Value.ToString()));
                        updateCmd.CommandType = CommandType.StoredProcedure;
                        updateCmd.ExecuteNonQuery();
                        MessageBox.Show("Event Type Edited");
                    }
                    else
                    {
                        MessageBox.Show("Event Type not found in the lookup table.");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }

    }
}
