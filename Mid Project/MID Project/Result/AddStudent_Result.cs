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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MID_Project.Result
{
    public partial class AddStudent_Result : Form
    {
        public AddStudent_Result()
        {
            InitializeComponent();
            loadStudent();
            loadACName();
            loadMeasure();
        }
        private void loadMeasure()
        {
            // load measurement level from rubric level
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select MeasurementLevel from RubricLevel", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox3.DataSource = dt;
            comboBox3.DisplayMember = "MeasurementLevel";
            comboBox3.ValueMember = "MeasurementLevel";


        }

        private void loadACName()
        {
            // load assessment component name from assessment component table
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Name from AssessmentComponent", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Name";

        }
        private void loadStudent()
        {
            //load student first name from student table
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select FirstName from Student where status=5", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "FirstName";
            comboBox1.ValueMember = "FirstName";


        }

        private void AddStudent_Result_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Result_Menu result_Menu = new Result_Menu();
            result_Menu.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id;
            var con1 = Configuration.getInstance().getConnection();
             // Open the connection if it's closed

            SqlCommand cmd1 = new SqlCommand("SELECT Id FROM Student WHERE FirstName=@FirstName", con1);
            cmd1.Parameters.AddWithValue("@FirstName", comboBox1.Text);
            id = (int)cmd1.ExecuteScalar();

            var con2 = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand("SELECT Id FROM AssessmentComponent WHERE Name=@Name", con2);
            cmd2.Parameters.AddWithValue("@Name", comboBox2.Text);
            int id2 = (int)cmd2.ExecuteScalar();
            // now insert 
            var con3 = Configuration.getInstance().getConnection();
            SqlCommand cmd3 = new SqlCommand("SELECT Id FROM RubricLevel WHERE MeasurementLevel=@MeasurementLevel", con3);
            cmd3.Parameters.AddWithValue("@MeasurementLevel", comboBox3.Text);
            int id3 = (int)cmd3.ExecuteScalar();

            // insert in Assesmant table
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into StudentResult values (@StudentId, @AssessmentComponentId, @RubricMeasurementId,@EvaluationDate)", con);
            cmd.Parameters.AddWithValue("@StudentId", id);
            cmd.Parameters.AddWithValue("@AssessmentComponentId", id2);
            cmd.Parameters.AddWithValue("@RubricMeasurementId", id3);
            string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            cmd.Parameters.AddWithValue("@EvaluationDate", date);
            cmd.ExecuteNonQuery();
           
            MessageBox.Show("Student Result Added Successfully");




        }
    }
}
