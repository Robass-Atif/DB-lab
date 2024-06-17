using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MID_Project.Result
{
    public partial class Result_Menu : Form
    {
        public Result_Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Show_Result show_Result = new Show_Result();
            show_Result.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddStudent_Result addStudent_Result = new AddStudent_Result();
            addStudent_Result.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }
    }
}
