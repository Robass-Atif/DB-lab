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
    public partial class ShowStudent : Form
    {
        public ShowStudent()
        {
            InitializeComponent();
            load();
        }
        private void load()
        {

            var con = Configuration.getInstance().getConnection();

            // Selecting data from the database
            SqlCommand cmd = new SqlCommand("SELECT FirstName,LastName,Contact,Email,RegistrationNumber,(Select Name from Lookup where status=LookupId) as Status FROM Student where status=5", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            // Updating the status column to "active" if it equals 5
            

            // Updating the changes back to the database
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(da);
            da.Update(dt);

            // Displaying the updated data in the DataGridView
            dataGridView1.DataSource = dt;

            con.Close();

     

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // show all student which is in database
        

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentMenu studentMenu = new StudentMenu();
            studentMenu.Show();
            this.Hide();

        }

        private void ShowStudent_Load(object sender, EventArgs e)
        {

        }
    }
}
