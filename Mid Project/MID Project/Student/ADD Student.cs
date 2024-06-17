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

namespace MID_Project
{
    public partial class ADD_Student : Form
    {
        public ADD_Student()
        {
            InitializeComponent();
            comboBox1.DisplayMember = "Active";
            comboBox1.ValueMember = "Active";
            comboBox1.Items.Add("Active");
            comboBox1.Items.Add("InActive");

            
        }
        
        

        private void DataGridView3_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        bool validations()
        {
            // if name is empty and have number
            if (textBox1.Text == "" || textBox1.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Please enter valid First Name");
                return false;
            }
            // if lastname have number or empty
            if (textBox2.Text == "" || textBox2.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Please enter valid Last Name");
                return false;
            }
            // if contact is empty or have string
            if (textBox3.Text == "" || textBox3.Text.Any(char.IsLetter))
            {
                MessageBox.Show("Please enter valid Contact");
                return false;
            }
            // if email is empty or have number
            if (textBox4.Text == "" || textBox4.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Please enter valid Email");
                return false;
            }
            // if registration number is empty
            if (textBox5.Text == "")
            {
                MessageBox.Show("Please enter valid Registration Number");
                return false;
            }
            // status is empty
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Please enter valid Status");
                return false;
            }
            return true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
           bool flag=validations();
            if (flag == false)
            {
                return;
            }
            var con = Configuration.getInstance().getConnection();
            
            SqlCommand cmd = new SqlCommand("Insert into Student values (@FirstName, @LastName, @Contact,@Email,@RegistrationNumber,@Status)", con);
            cmd.Parameters.AddWithValue("@FirstName", textBox1.Text);
            cmd.Parameters.AddWithValue("@LastName", textBox2.Text);
            cmd.Parameters.AddWithValue("@Contact", textBox3.Text);
            cmd.Parameters.AddWithValue("@Email", textBox4.Text);
            cmd.Parameters.AddWithValue("@RegistrationNumber", textBox5.Text);
            // if combobox is active then store 5 otherwisw 6
            
          
            if(comboBox1.Text == "Active")
            {
                // how to parse int int
                cmd.Parameters.AddWithValue("@Status", 5);

                
            }
            else
            {
                cmd.Parameters.AddWithValue("@Status", 6);
            }       
            
            cmd.ExecuteNonQuery();
            
            MessageBox.Show("Successfully saved");
           

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // student menu form open
            StudentMenu studentMenu = new StudentMenu();
            studentMenu.Show();
            //delete current form
            this.Hide();
        }

        private void ADD_Student_Load(object sender, EventArgs e)
        {

        }
    }
}
