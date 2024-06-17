using MID_Project.CLOS;
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
    public partial class CLo_Menu : Form
    {
        public CLo_Menu()
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
            CloAdd cloAdd = new CloAdd();
            cloAdd.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Update_Clo c=new Update_Clo();
            c.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Delete_Clo d=new Delete_Clo();
            d.Show();
            this.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Show_Clos s=new Show_Clos();
            s.Show();
            this.Close();

        }
    }
}
