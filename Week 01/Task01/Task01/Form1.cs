using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Task01
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
            dataLoad();


        }
        public void dataLoad()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Student", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;


        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into Student values (@RegistrationNUmber, @Name, @Department,@session,@Address)", con);
            cmd.Parameters.AddWithValue("@RegistrationNUmber", (textBox1.Text));
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Department", textBox3.Text);
            cmd.Parameters.AddWithValue("@session", textBox4.Text);
            cmd.Parameters.AddWithValue("@Address", textBox6.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully saved");
            dataLoad();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = Configuration.getInstance().getConnection();
            // Assuming dataGridView1 is the DataGridView instance
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow) // Skip the new row at the end of DataGridView
                {
                    string registrationNumber = row.Cells["RegistrationNUmber"].Value.ToString();
                    string name = row.Cells["Name"].Value.ToString();
                    string department = row.Cells["Department"].Value.ToString();
                    string session = row.Cells["session"].Value.ToString();
                    string address = row.Cells["Address"].Value.ToString();

                    SqlCommand cmd = new SqlCommand("UPDATE Student SET Name = @Name, Department = @Department, session = @session, Address = @Address WHERE RegistrationNUmber = @RegistrationNUmber", con);
                    cmd.Parameters.AddWithValue("@RegistrationNUmber", registrationNumber);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Department", department);
                    cmd.Parameters.AddWithValue("@session", session);
                    cmd.Parameters.AddWithValue("@Address", address);

                    cmd.ExecuteNonQuery();
                }
            }

            // Commit changes to the database
            // con is assumed to be the SqlConnection instance
            SqlTransaction transaction = con.BeginTransaction();
            try
            {
                // Execute any other commands or operations here if needed

                transaction.Commit();
                MessageBox.Show("All rows updated successfully.");
            }
            catch (Exception ex)
            {
                // Handle exceptions or rollback transaction if needed
                transaction.Rollback();
                MessageBox.Show("Error occurred: " + ex.Message);
            }
            finally
            {
                con.Close(); // Close the connection
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Delete x = new Delete();
            x.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Search f = new Search();
            f.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Course c = new Course();
            c.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Register_Student s = new Register_Student();
            s.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Attendance a = new Attendance();
            a.Show();
            this.Hide();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
