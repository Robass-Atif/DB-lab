using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Final_lab_project.Events
{
    public partial class Event_Menu : Form
    {
        public Event_Menu()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Add_Event add_Event = new Add_Event();
            add_Event.Show();
            this.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Updaate_Event updaate_Event = new Updaate_Event();
            updaate_Event.Show();
            this.Close();

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Delete_Event delete_Event = new Delete_Event();
            delete_Event.Show();
            this.Close();

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Show_Events show_Events = new Show_Events();
            show_Events.Show();
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Add_Event add_Event = new Add_Event();
            add_Event.Show();
            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Updaate_Event updaate_Event = new Updaate_Event();
            updaate_Event.Show();
            this.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Show_Events show_Events = new Show_Events();
            show_Events.Show();
            this.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Delete_Event delete_Event= new Delete_Event();
            delete_Event.Show();
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();

        }
    }
}
