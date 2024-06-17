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
    public partial class AttendanceOfStudent : Form
    {
        public AttendanceOfStudent()
        {
            InitializeComponent();
            AttendanceOfStudent_Load();
            LoadAttendanceStatus();
        }

        // load all student in combobox2
        private void AttendanceOfStudent_Load()
        {
            // i want to upload all student name in combobox2
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select RegistrationNumber from Student where status=5", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "RegistrationNumber";
            comboBox2.ValueMember = "RegistrationNumber";

        }  
        // load function that load all attendence status from database lookup table
        private void LoadAttendanceStatus()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Name from Lookup where Category='ATTENDANCE_STATUS'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Name";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentMenu studentMenu = new StudentMenu();
            studentMenu.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string date = dateTimePicker2.Value.ToString("yyyy-MM-dd");
         

            var con = Configuration.getInstance().getConnection();
            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("INSERT INTO ClassAttendance ( AttendanceDate) VALUES ( @AttendanceDate)", con);
            cmd.Parameters.AddWithValue("@AttendanceDate", date);
            cmd.ExecuteNonQuery();
            loadStudent();
            MessageBox.Show("Attendance has been marked");

        }
        // function loadStudent which take attendance status from combobox1 and student id from combobox2 and attendanceid from database and insert into studentattendance table
        private void loadStudent()
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                // Query to get AttendanceId
                SqlCommand cmd = new SqlCommand("SELECT Id FROM ClassAttendance WHERE AttendanceDate = @AttendanceDate", con);
                cmd.Parameters.AddWithValue("@AttendanceDate", dateTimePicker2.Value.ToString("yyyy-MM-dd"));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    int attendanceId = Convert.ToInt32(dt.Rows[0]["Id"]);

                    // Query to get StatusId
                    SqlCommand cmd1 = new SqlCommand("SELECT LookupId FROM Lookup WHERE Name = @Name", con);
                    cmd1.Parameters.AddWithValue("@Name", comboBox1.SelectedValue);
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);

                    if (dt1.Rows.Count > 0)
                    {
                        int statusId = Convert.ToInt32(dt1.Rows[0]["LookupId"]);

                        // Query to get StudentId
                        SqlCommand cmd2 = new SqlCommand("SELECT Id FROM Student WHERE RegistrationNumber = @RegistrationNumber", con);
                        cmd2.Parameters.AddWithValue("@RegistrationNumber", comboBox2.SelectedValue);
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                        DataTable dt2 = new DataTable();
                        da2.Fill(dt2);

                        if (dt2.Rows.Count > 0)
                        {
                            int studentId = Convert.ToInt32(dt2.Rows[0]["Id"]);

                            // Insert into StudentAttendance table
                            SqlCommand cmd3 = new SqlCommand("INSERT INTO StudentAttendance (AttendanceId, StudentId, AttendanceStatus) VALUES (@AttendanceId, @StudentId, @AttendanceStatus)", con);
                            cmd3.Parameters.AddWithValue("@AttendanceId", attendanceId);
                            cmd3.Parameters.AddWithValue("@StudentId", studentId);
                            cmd3.Parameters.AddWithValue("@AttendanceStatus", statusId);
                            cmd3.ExecuteNonQuery();
                        }
                        else
                        {
                            MessageBox.Show("Student not found.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Status not found.");
                    }
                }
                else
                {
                    MessageBox.Show("Attendance record not found.");
                }

                con.Close(); // Close the connection
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AttendanceOfStudent_Load(object sender, EventArgs e)
        {

        }
    }
}
