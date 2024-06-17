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
            dataLoad();
        }
        
        void dataLoad()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Student", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            // Add event handler for formatting the Status column
            dataGridView3.CellFormatting += DataGridView3_CellFormatting;

            dataGridView3.DataSource = dt;
        }

        private void DataGridView3_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dataGridView3.Columns["Status"].Index && e.Value != null)
            {
                int statusValue = Convert.ToInt32(e.Value);
                e.Value = (statusValue == 5) ? "Active" : (statusValue == 6) ? "Inactive" : e.Value;
                e.FormattingApplied = true;
            }
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

        private void button3_Click(object sender, EventArgs e)
        {
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
            dataLoad();

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
