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

namespace MID_Project.Student
{
    public partial class Delete_Student : Form
    {
        public Delete_Student()
        {
            InitializeComponent();
            load();
        }
        private void load()
        {
            // show all student which is in database in combo box

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT FirstName FROM Student WHERE Status=5", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "FirstName";
            comboBox1.ValueMember = "FirstName";
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentMenu m=new StudentMenu();
            m.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // change the status of student to 6
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE Student SET Status=6 WHERE FirstName=@FirstName", con);
            cmd.Parameters.AddWithValue("@FirstName", comboBox1.SelectedValue);
           
            cmd.ExecuteNonQuery();
          
            MessageBox.Show("Student Deleted Successfully");
            load();
        }

        private void Delete_Student_Load(object sender, EventArgs e)
        {

        }
    }
}
