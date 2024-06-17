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
    public partial class Delete_Event : Form
    {
        public Delete_Event()
        {
            InitializeComponent();
            loadData();
        }

        void  loadData()
        {
            // get  all event details and dispaly in combobox
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT W.WebsiteID, PageName, PS.PageSectionId,EventID, (SELECT Value FROM Lookup WHERE id = Events.EventType) AS [Event Type],Events.EventTime,Events.EventDetails  FROM PageSection PS JOIN Pages P ON P.PageID = Ps.PageId JOIN Website W ON P.WebsiteID = W.WebsiteID join Events on PS.PageSectionId=Events.PageSectionID", con);

            // throught another approach

            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }   

        private void button1_Click(object sender, EventArgs e)
        {
            Event_Menu event_Menu = new Event_Menu();
            event_Menu.Show();
            this.Close();

        }

        private void Delete_Event_Load(object sender, EventArgs e)
        {

        }

        

        private void button2_Click(object sender, EventArgs e)
        {
        
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                try
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("stpDeleteEvent", con);
                    cmd.Parameters.AddWithValue("@EventID", dataGridView1.CurrentRow.Cells["EventID"].Value.ToString());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Row Deleted");
                    loadData();
                }

                catch (SqlException ex)
                {
                    MessageBox.Show("Row Not deleted due to error: " + ex.Message);
                }
            }
        }
    }
}
