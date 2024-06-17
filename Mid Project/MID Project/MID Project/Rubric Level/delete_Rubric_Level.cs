using CRUD_Operations;
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

namespace MID_Project.Rubric_Level
{
    public partial class delete_Rubric_Level : Form
    {
        public delete_Rubric_Level()
        {
            InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            // load rubric level from database and show in combobox
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Details from RubricLevel", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Details";
            comboBox1.ValueMember = "Details";
            con.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            RubricLevel_Menu m = new RubricLevel_Menu();
            m.Show();
            this.Hide();

        }

        private void delete_Rubric_Level_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // delete from student result
            var con1 = Configuration.getInstance().getConnection();
            if (con1.State == ConnectionState.Closed)
            {
                con1.Open();
            }
            string details1 = comboBox1.Text;
            string query1 = "DELETE FROM StudentResult WHERE RubricMeasurementId = (SELECT Id FROM RubricLevel WHERE Details = '" + details1 + "')";
            SqlCommand cmd1 = new SqlCommand(query1, con1);
            cmd1.ExecuteNonQuery();
            con1.Close();

            // delete from assessment component
            var con2 = Configuration.getInstance().getConnection();
            if (con2.State == ConnectionState.Closed)
            {
                con2.Open();
            }
            string details2 = comboBox1.Text;
            string query2 = "DELETE FROM AssessmentComponent WHERE RubricId = (SELECT Id FROM Rubric WHERE Details = '" + details2 + "')";
            SqlCommand cmd2 = new SqlCommand(query2, con2);
            cmd2.ExecuteNonQuery();
            con2.Close();



            // delete rubric level from database
            var con = Configuration.getInstance().getConnection();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string details = comboBox1.Text;
            string query = "DELETE FROM RubricLevel WHERE Details = '" + details + "'";
                SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Rubric Level Deleted Successfully");

        }
    }
}
