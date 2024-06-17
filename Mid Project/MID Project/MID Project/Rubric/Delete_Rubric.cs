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

namespace MID_Project.Rubric
{
    public partial class Delete_Rubric : Form
    {
        public Delete_Rubric()
        {
            InitializeComponent();
            loadData();
        }
        private void loadData()
        {
            // load rubric details from rubric table from database in combobox2
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Details from Rubric", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "Details";
            comboBox2.ValueMember = "Details";



        }

        private void button1_Click(object sender, EventArgs e)
        {
            RubricMenu rm = new RubricMenu();
            rm.Show();
            this.Hide();

        }

        private void Delete_Rubric_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // first delete from student result table
            var con4 = Configuration.getInstance().getConnection();
            if (con4.State == ConnectionState.Closed)
            {
                con4.Open();
            }
            string details4 = comboBox2.Text;
            string query4 = "DELETE FROM StudentResult WHERE AssessmentComponentId IN (SELECT Id FROM AssessmentComponent WHERE RubricId IN (SELECT Id FROM Rubric WHERE Details = '" + details4 + "'))";
            SqlCommand cmd4 = new SqlCommand(query4, con4);
            cmd4.ExecuteNonQuery();
            if (con4.State == ConnectionState.Open)
            {
                con4.Close();
            }

            // first delete from rbric level

            var con1 = Configuration.getInstance().getConnection();
            if (con1.State == ConnectionState.Closed)
            {
                con1.Open();
            }
            string details1 = comboBox2.Text;
            string query1 = "DELETE FROM RubricLevel WHERE RubricId = (SELECT Id FROM Rubric WHERE Details = '" + details1 + "')";
            SqlCommand cmd1 = new SqlCommand(query1, con1);
            cmd1.ExecuteNonQuery();
            if (con1.State == ConnectionState.Open)
            {
                con1.Close();
            }
            // delete assessment component from student result

            var con3 = Configuration.getInstance().getConnection();
            con3.Open();
            string details3 = comboBox2.Text;
            string query3 = "DELETE FROM StudentResult WHERE AssessmentComponentId = (SELECT MAX(Id) FROM AssessmentComponent WHERE RubricId = (SELECT MAX(Id) FROM Rubric WHERE Details = @Details))";
            SqlCommand cmd3 = new SqlCommand(query3, con3);
            cmd3.Parameters.AddWithValue("@Details", details3);
            cmd3.ExecuteNonQuery();
            con3.Close();


            // delete  rubric from assessment component 
            var con2 = Configuration.getInstance().getConnection();
            con2.Open();
            string details2 = comboBox2.Text;
            string query2 = "DELETE FROM AssessmentComponent WHERE RubricId = (SELECT Id FROM Rubric WHERE Details = '" + details2 + "')";
            SqlCommand cmd2 = new SqlCommand(query2, con2);
            cmd2.ExecuteNonQuery();
            con2.Close();


            // delete rubric from rubric table
            var con = Configuration.getInstance().getConnection();
            con.Open();
            string details = comboBox2.Text;
            string query = "DELETE FROM Rubric WHERE Details = '" + details + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Rubric Deleted Successfully");
            con.Close();

        }
    }
}
