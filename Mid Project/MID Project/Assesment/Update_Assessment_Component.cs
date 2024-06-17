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

namespace MID_Project.Assesment
{
    public partial class Update_Assessment_Component : Form
    {
        public Update_Assessment_Component()
        {
            InitializeComponent();
            load();
            hideComponent();
        }
        private void load()
        {
            // load title in combobox1 from assessment table from database
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Name from AssessmentComponent", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Name";
        }
        private void hideComponent()
        {
            textBox1.Hide();
            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
           dateTimePicker1.Hide();
          numericUpDown1.Hide();
            button3.Hide();
            comboBox1.Hide();
           
        }
        private void showComponent()
        {
            textBox1.Show();
            label1.Show();
            label2.Show();
            label3.Show();
            label4.Show();
            dateTimePicker1.Show();
            numericUpDown1.Show();
            button3.Show();
            comboBox1.Show();
        }   

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Update_Assessment_Component_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // load the data of corresponding assessment component name in the component but rubric deatils from rubric deatials table
            var con = Configuration.getInstance().getConnection();
            // Open the connection if it's closed
            string name = comboBox2.Text;
            SqlCommand cmd = new SqlCommand("Select * from AssessmentComponent where Name = @Name", con);
            cmd.Parameters.AddWithValue("@Name", name);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBox1.Text = reader["Name"].ToString();
                dateTimePicker1.Text = reader["DateCreated"].ToString();
                numericUpDown1.Text = reader["TotalMarks"].ToString();
               
            }
            
            // load rubric details in combobox1 from rubric table from database
            var con1 = Configuration.getInstance().getConnection();

            SqlCommand cmd1 = new SqlCommand("Select Details from Rubric", con1);
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Details";
            comboBox1.ValueMember = "Details";
           




            
            showComponent();
            comboBox2.Hide();
            button2.Hide();
            label5.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Assesmant_Menu menu = new Assesmant_Menu();
          
            menu.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int rubricid;
            // load rubric id
            var con1 = Configuration.getInstance().getConnection();
             // Open the connection if it's closed

            SqlCommand cmd1 = new SqlCommand("Select Id from Rubric where Details = @Details", con1);
            cmd1.Parameters.AddWithValue("@Details", comboBox1.Text);
            rubricid = (int)cmd1.ExecuteScalar();
            
            // update the data
                var con = Configuration.getInstance().getConnection();
            
            string name = textBox1.Text;
            DateTime date = dateTimePicker1.Value;
            int marks = Convert.ToInt32(numericUpDown1.Value);
            
            string query = "Update AssessmentComponent set Name = @Name, DateCreated = @DateCreated, TotalMarks = @TotalMarks, RubricId = (Select Id from Rubric where Details = @Details) where Name = @Name";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Details", comboBox1.Text);
            cmd.Parameters.AddWithValue("@DateCreated", date);
            cmd.Parameters.AddWithValue("@TotalMarks", marks);

            
            cmd.ExecuteNonQuery();
            MessageBox.Show("Updated");


        }
    }
}
