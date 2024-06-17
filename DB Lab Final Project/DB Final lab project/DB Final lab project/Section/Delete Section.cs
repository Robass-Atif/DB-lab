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
    public partial class Delete_Section : Form
    {
        public Delete_Section()
        {
            InitializeComponent();
            loadData();
        }
        void loadData()
        {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT W.WebsiteID, WebsiteURL, P.PageID, PageName, PS.PageSectionId, (SELECT Value FROM Lookup WHERE id = SectionCategory) AS [Category]  FROM PageSection PS JOIN Pages P ON P.PageID = Ps.PageId JOIN Website W ON P.WebsiteID = W.WebsiteID", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

  

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SectionMenu sectionMenu = new SectionMenu();
            sectionMenu.Show();
            this.Close();

        }

        private void Delete_Section_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
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
                    SqlCommand cmd = new SqlCommand("stpDeletePageSection", con);
                    cmd.Parameters.AddWithValue("@PageSectionId", dataGridView1.CurrentRow.Cells["PageSectionId"].Value.ToString());
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
