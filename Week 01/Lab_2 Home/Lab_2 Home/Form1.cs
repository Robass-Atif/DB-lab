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

namespace Lab_2_Home
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

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into Student values (@RegistrationNUmber, @Name, @Department,@session,@Address)", con);
            cmd.Parameters.AddWithValue("@RegistrationNUmber", (textBox1.Text));
            cmd.Parameters.AddWithValue("@Name", textBox3.Text);
            cmd.Parameters.AddWithValue("@Department", textBox4.Text);
            cmd.Parameters.AddWithValue("@session", textBox5.Text);
            cmd.Parameters.AddWithValue("@Address", textBox6.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully saved");
            dataLoad();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();

            SqlCommand cmd = new SqlCommand("DELETE FROM Student WHERE RegistrationNUmber = @RegistrationNumber", con);
            cmd.Parameters.AddWithValue("@RegistrationNumber", textBox1.Text);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Student record deleted successfully");

            }
            else
            {
                MessageBox.Show("Write registration number again our registration is not correct");
            }

            dataLoad();

           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Student WHERE RegistrationNUmber = @RegistrationNUmber", con);
            cmd.Parameters.AddWithValue("@RegistrationNUmber", textBox1.Text);

            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                // Data found, bind it to DataGridView
                MessageBox.Show("Student Found");

            }
            else
            {
                // No data found
                MessageBox.Show("write registration number again student not found.");
            }

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
    }
}
