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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using DB_Final_lab_project;


namespace DB_Final_lab_project.Users
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
            LoadGender();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _AddUser();
        }

        // Email validation method
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void LoadGender()
        {
            // Clear existing items
            comboBox1.Items.Clear();

            // Add gender options
            comboBox1.Items.Add("Male");
            comboBox1.Items.Add("Female");

            // Set default value
            comboBox1.SelectedItem = "Male"; // You might want to set the default to "Male" or "Female"
        }

        private void _AddUser()
        {
            // Check if text boxes are empty
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all the fields.");
                return;
            }

            // Validate email format
            if (!IsValidEmail(textBox3.Text))
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }

          
                // Establish database connection
                var con = Configuration.getInstance().getConnection();

                // Call stored procedure to add user
                SqlCommand cmd = new SqlCommand("stpAddUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                // Add parameters for User table
                cmd.Parameters.AddWithValue("@FirstName", textBox1.Text);
                cmd.Parameters.AddWithValue("@LastName", textBox2.Text);
                cmd.Parameters.AddWithValue("@Email", textBox3.Text);
                cmd.Parameters.AddWithValue("@RegistrationDate", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@LastLoginDate", DateTime.Now);

                 cmd.ExecuteNonQuery();

                // Check if user was successfully added
               
                
                    // Proceed with adding the user demographics
                    SqlCommand cmd1 = new SqlCommand("stpInsertUserDemographics", con);
                    cmd1.CommandType = CommandType.StoredProcedure;

                    // Get UserID for the added user
                    int userID = GetUserIdByEMail(textBox3.Text);

                    // Add parameters for UserDemographics table
                    cmd1.Parameters.AddWithValue("@UserID", userID);
                    cmd1.Parameters.AddWithValue("@City", textBox4.Text);
                    cmd1.Parameters.AddWithValue("@Country", textBox5.Text);
                    cmd1.Parameters.AddWithValue("@Age", Convert.ToInt32(textBox6.Text));
                    cmd1.Parameters.AddWithValue("@Gender", comboBox1.SelectedItem.ToString());

                    // Execute the query to insert user demographics
                    cmd1.ExecuteNonQuery();

                    // Show a message box indicating that the user has been added
                    MessageBox.Show("User Added");
                
           
        }


        private int GetUserIdByEMail(string email)
        {
            int userID = 0;
           
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("stpGetUserIDByEmail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", email);

                

                // Execute the command and get the result
                object result = cmd.ExecuteScalar();

                // Check if the result is not null and is convertible to int
                if (result != null && int.TryParse(result.ToString(), out userID))
                {
                    return userID;
                }
           
            return userID; // Return 0 if any error occurs or if the result is null
        }




        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddUser_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            User.MenuUser form = new User.MenuUser();
            form.Show();
            this.Hide();

        }
    }
}
