using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MID_Project.Rubric_Level
{
    public partial class RubricLevel_Menu : Form
    {
        public RubricLevel_Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RubricLevel r = new RubricLevel();
            r.Show();
                this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

        private void RubricLevel_Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
