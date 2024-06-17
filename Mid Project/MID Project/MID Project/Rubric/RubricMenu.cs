using MID_Project.Rubric;
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
    public partial class RubricMenu : Form
    {
        public RubricMenu()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddRubric r = new AddRubric();
            r.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Update_Rubric u = new Update_Rubric();
            u.Show();
            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Show_Rubric s = new Show_Rubric();
            s.Show();
            this.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Delete_Rubric delete_Rubric = new Delete_Rubric();
            delete_Rubric.Show();
            this.Close();

        }
    }
}
