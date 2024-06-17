using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Final_lab_project.Section
{
    public partial class SectionMenu : Form
    {
        public SectionMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Create_Section create_Section = new Create_Section();
            create_Section.Show();
            this.Close();

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Update_Section update_Section = new Update_Section();
            update_Section.Show();
            this.Close();

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Delete_Section delete_Section = new Delete_Section();
            delete_Section.Show();
            this.Close();

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Show_Section show_Section = new Show_Section();
            show_Section.Show();
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Create_Section create_Section = new Create_Section();
            create_Section.Show();
            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Update_Section update_Section = new Update_Section();
            update_Section.Show();
            this.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Show_Section show_Section = new Show_Section();
            show_Section.Show();
            this.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Delete_Section delete_Section = new Delete_Section();

            delete_Section.Show();
            this.Close();

        }
    }
}
