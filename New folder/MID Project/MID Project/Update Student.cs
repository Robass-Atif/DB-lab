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
    public partial class Update_Student : Form
    {
        public Update_Student()
        {
            InitializeComponent();
            AttendanceOfStudent_Load();
            hiding();
        }
        private void AttendanceOfStudent_Load()
        {
            // i want to upload all student name in combobox2
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select RegistrationNumber from Student", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "RegistrationNumber";
            comboBox2.ValueMember = "RegistrationNumber";

        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        // hide all text box and label and button
        private void hiding()
        {
            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            textBox1.Hide(); textBox2.Hide(); textBox3.Hide();
            textBox4.Hide(); textBox5.Hide();
            button3.Hide();
            comboBox1.Hide();
        }
        // show all text box and label and button
        private void showing()
        {
            label1.Show();
            label2.Show();
            label3.Show();
            label4.Show();
            label5.Show();
            label6.Show();
            textBox1.Show(); textBox2.Show(); textBox3.Show();
            textBox4.Show(); textBox5.Show();
            button3.Show();
            comboBox1.Show();
        }   

        private void button1_Click(object sender, EventArgs e)
        {
            StudentMenu studentMenu = new StudentMenu();
            studentMenu.Show(this);
            this.Close();   

        }
        int IdOfSTudent;
        private void button2_Click(object sender, EventArgs e)
        {
            showing();
            button2.Hide();
            label7.Hide();
            comboBox2.Hide();
            loadData();
        }
        private void loadData()
        {
            // load data from database Student by help of Registration number in combobox2
            string selectedRegistrationNumber = comboBox2.Text.ToString();

            // Retrieve data from the database using the selected registration number
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Student WHERE RegistrationNumber = @RegNumber", con);
            cmd.Parameters.AddWithValue("@RegNumber", selectedRegistrationNumber);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                IdOfSTudent = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
                textBox1.Text = dt.Rows[0]["FirstName"].ToString();
                textBox2.Text = dt.Rows[0]["LastName"].ToString();
                textBox3.Text = dt.Rows[0]["Contact"].ToString();
                textBox4.Text = dt.Rows[0]["Email"].ToString();
                textBox5.Text = dt.Rows[0]["RegistrationNumber"].ToString();
                comboBox1.Text = dt.Rows[0]["Status"].ToString();
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            // save date with the help of id of student

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE Student SET FirstName = @FirstName, LastName = @LastName, Contact = @Contact, Email = @Email, RegistrationNumber = @RegistrationNumber, Status = @Status WHERE Id = @Id", con);
            cmd.Parameters.AddWithValue("@FirstName", textBox1.Text);
            cmd.Parameters.AddWithValue("@LastName", textBox2.Text);
            cmd.Parameters.AddWithValue("@Contact", textBox3.Text);
            cmd.Parameters.AddWithValue("@Email", textBox4.Text);
            cmd.Parameters.AddWithValue("@RegistrationNumber", textBox5.Text);
            cmd.Parameters.AddWithValue("@Status", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Id", IdOfSTudent);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data has been updated");
        }
    }
}
