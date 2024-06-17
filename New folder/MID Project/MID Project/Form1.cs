using MID_Project.Rubric_Level;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // student menu form open
            StudentMenu studentMenu = new StudentMenu();
            studentMenu.Show();
            this.Hide();
          
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CLo_Menu cLo_Menu = new CLo_Menu();
            cLo_Menu.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RubricMenu m = new RubricMenu();
            m.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RubricLevel_Menu r = new RubricLevel_Menu();
            r.Show();
            this.Hide();
        }
    }
}
