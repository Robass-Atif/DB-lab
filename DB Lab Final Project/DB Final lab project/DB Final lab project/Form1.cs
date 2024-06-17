using DB_Final_lab_project.Events;
using DB_Final_lab_project.Referrer;
using DB_Final_lab_project.Section;
using DB_Final_lab_project.Website;
using DB_Final_lab_project.User;
using DB_Final_lab_project.Session;
using DB_Final_lab_project.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DB_Final_lab_project.Reports;

namespace DB_Final_lab_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SectionMenu sectionMenu = new SectionMenu();
            sectionMenu.Show();
            this.Hide();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Event_Menu event_Menu = new Event_Menu();
            event_Menu.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new WebsiteMenu();
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f = new ReferrerMenu();
            f.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SectionMenu s=new SectionMenu();
            s.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Event_Menu event_Menu=new Event_Menu();
            event_Menu.Show();
            this.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            PageMenu form = new PageMenu();
            form.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MenuUser form = new MenuUser();
            form.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SessionMenu form = new SessionMenu();
            form.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form f = new ReportMenu();
            f.Show();
            this.Hide();
        }
    }
}
