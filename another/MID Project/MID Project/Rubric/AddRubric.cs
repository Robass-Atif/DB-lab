using CRUD_Operations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MID_Project
{
    public partial class AddRubric : Form
    {
        public AddRubric()
        {
            InitializeComponent();
            loadData();
        }
        private void loadData()
        {
            // load clo id from clo table from database

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Name from Clo", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Name";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private int GenerateUniqueId()
        {
            // Get the current connection
            var con = Configuration.getInstance().getConnection();

            // Create a SqlCommand to count the number of rows in the Rubric table
            SqlCommand countCmd = new SqlCommand("SELECT COUNT(*) FROM Rubric", con);

            // Execute the SqlCommand to get the count
            int rowCount = (int)countCmd.ExecuteScalar();

            // Add 1 to the row count to generate a new unique identifier
            int uniqueId = rowCount +999;

            // Return the unique identifier
            return uniqueId;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = Configuration.getInstance().getConnection();
                

                // Check if the connection is already open
                if (con.State == ConnectionState.Open)
                {
                    // Connection is already open, use the existing connection
                    // Get CloId based on selected name from comboBox1
                    SqlCommand cmd1 = new SqlCommand("SELECT Id FROM clo WHERE Name = @Name", con);
                    cmd1.Parameters.AddWithValue("@Name", comboBox1.Text);
                    int cloid = (int?)cmd1.ExecuteScalar() ?? 0; // Assign 0 if no value returned

                    if (cloid != 0)
                    {
                        // Generate a unique Id manually
                        int generatedId = GenerateUniqueId(); // You need to implement this method

                        // Insert into Rubric table
                        SqlCommand cmd = new SqlCommand("INSERT INTO Rubric (Id, [Details], [CloId]) VALUES (@Id, @Details, @CloId)", con);
                        cmd.Parameters.AddWithValue("@Id", generatedId);
                        cmd.Parameters.AddWithValue("@Details", textBox1.Text);
                        cmd.Parameters.AddWithValue("@CloId", cloid);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Successfully saved");
                    }
                    else
                    {
                        MessageBox.Show("CloId not found for the selected name.");
                    }
                }
                else
                {
                    MessageBox.Show("Connection is not open.");
                }

                // Close the connection if it was opened in this block
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }



        }

        private void AddRubric_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RubricMenu r = new RubricMenu();
            r.Show();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
