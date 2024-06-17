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
    public partial class Create_Section : Form
    {
        public Create_Section()
        {
            InitializeComponent();
            loadPageName();
            loadLookup();
        }
        void loadPageName()
        {

            //load page name from database and show in combobox
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select PageName from Pages", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "PageName";
            comboBox1.ValueMember = "PageName";

        }
        void loadLookup()
        {
            //load lookup value from database and show in combobox
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Value from Lookup where Category = 'SECTION_CATEGORY'", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "Value";
            comboBox2.ValueMember = "Value";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SectionMenu sectionMenu = new SectionMenu();
            sectionMenu.Show();
            this.Close();

        }

        private void Create_Section_Load(object sender, EventArgs e)
        {

        }

        int getPageID()
        {
            //get page id from database
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select PageID from Pages where PageName = @PageName", con);
            cmd.Parameters.AddWithValue("@PageName", comboBox1.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return Convert.ToInt32(dt.Rows[0]["PageID"]);
        }
        int getSectionID()
        {
            // get lookup id from database
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select ID from Lookup where Value = @Value", con);
            cmd.Parameters.AddWithValue("@Value", comboBox2.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return Convert.ToInt32(dt.Rows[0]["ID"]);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                var con = Configuration.getInstance().getConnection();
                //using stored procedure to insert data into database
                SqlCommand cmd = new SqlCommand("stp_AddPageSection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PageId", getPageID());
                cmd.Parameters.AddWithValue("@TimeSpan", maskedTextBox1.Text);
                cmd.Parameters.AddWithValue("@SectionCategory", getSectionID());

                cmd.ExecuteNonQuery();

                MessageBox.Show("Section Created Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
