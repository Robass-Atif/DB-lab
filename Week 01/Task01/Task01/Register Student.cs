using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task01
{
    public partial class Register_Student : Form
    {
        public Register_Student()
        {
            InitializeComponent();
            loadData();
        }
        private void loadData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Enrollments", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve connection string from Configuration
                string connectionString = Configuration.getInstance().getConnection().ConnectionString;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Check if student with provided RegistrationNumber exists
                    SqlCommand checkStudentCmd = new SqlCommand("SELECT COUNT(*) FROM Student WHERE RegistrationNumber = @RegistrationNumber", con);
                    checkStudentCmd.Parameters.AddWithValue("@RegistrationNumber", (textBox5.Text));

                    int studentCount = (int)checkStudentCmd.ExecuteScalar();

                    if (studentCount == 0)
                    {
                        MessageBox.Show("Student with the provided RegistrationNumber does not exist.");
                        return; // Exit the method without proceeding further
                    }

                    // Check if course exists in Courses table
                    SqlCommand checkCourseCmd = new SqlCommand("SELECT COUNT(*) FROM Courses WHERE Name = @Name", con);
                    checkCourseCmd.Parameters.AddWithValue("@Name", textBox4.Text);

                    int courseCount = (int)checkCourseCmd.ExecuteScalar();

                    if (courseCount == 0)
                    {
                        MessageBox.Show("Course with the provided name does not exist.");
                        return; // Exit the method without proceeding further
                    }

                    // Insert into Enrollments table
                    SqlCommand cmd = new SqlCommand("INSERT INTO Enrollments (StudentRegNo, CourseName) VALUES (@StudentRegNo, @Name)", con);
                    cmd.Parameters.AddWithValue("@StudentRegNo", (textBox5.Text));
                    cmd.Parameters.AddWithValue("@Name", textBox4.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Enrollment saved successfully.");
                }

                loadData(); // Reload data after successful enrollment
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
                // Retrieve connection string from Configuration
                string connectionString = Configuration.getInstance().getConnection().ConnectionString;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Delete the student from the Enrollments table based on RegistrationNumber and Name
                    SqlCommand cmd = new SqlCommand("DELETE FROM Enrollments WHERE StudentRegNo = @StudentRegNo AND CourseName = @CourseName", con);
                    cmd.Parameters.AddWithValue("@StudentRegNo", (textBox5.Text));
                    cmd.Parameters.AddWithValue("@CourseName", textBox4.Text); // Assuming textBox3 contains the student's name

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Student deleted from Enrollments successfully.");
                    }
                    else
                    {
                        MessageBox.Show("No matching records found in Enrollments to delete.");
                    }
                }
            loadData();
            




        }
    }
}
