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
    public partial class Show_Attendance : Form
    {
        public Show_Attendance()
        {
            InitializeComponent();
            load();
        }
        private void load()
        {
            var con = Configuration.getInstance().getConnection();

            // Selecting data from the database
            SqlCommand cmd = new SqlCommand("select (select FirstName from Student where Id=StudentId),(select Name from Lookup where LookupId=AttendanceStatus),(select AttendanceDate from ClassAttendance where Id=AttendanceId) from StudentAttendance", con);
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

            


        }

        private void Show_Attendance_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentMenu studentMenu = new StudentMenu();
            studentMenu.Show();
            this.Hide();

        }
    }
}
