using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MID_Project.Assesment
{
    public partial class Assesmant_Menu : Form
    {
        public Assesmant_Menu()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_Assesment a = new Add_Assesment();
            a.Show();
            this.Close();
        }

        private void Assesmant_Menu_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Assessment_Component a= new Assessment_Component();
            a.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Show_Assesment a = new Show_Assesment();
            a.Show();
            this.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Show_Assessment_Component show_Assessment_Component = new Show_Assessment_Component();
            show_Assessment_Component.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Update_Assessment update_Assessment = new Update_Assessment();
            update_Assessment.Show();
            this.Close();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            delete_Assessment m = new delete_Assessment();
            m.Show();
            this.Close();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            delete_Assessment_Component m= new delete_Assessment_Component();
            m.Show();
            this.Close();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Update_Assessment_Component m = new Update_Assessment_Component();
            m.Show();
            this.Close();

        }
    }
}
