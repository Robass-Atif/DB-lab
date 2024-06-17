using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MID_Project
{
    public partial class StudentMenu : Form
    {
        public StudentMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // add student form open
            ADD_Student add_Student = new ADD_Student();
            add_Student.Show();
            this.Hide();
        }

        private void StudentMenu_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AttendanceOfStudent attendanceOfStudent = new AttendanceOfStudent();
            attendanceOfStudent.Show();
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //form1 open
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Update_Student d1 = new Update_Student();
            d1.Show();
            this.Hide();

        }
    }
}
