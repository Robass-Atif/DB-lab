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

namespace DB_Final_lab_project.Session
{
    public partial class SessionMenu : Form
    {
        public SessionMenu()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SessionAdd form = new SessionAdd();
            form.Show();
            this.Hide();
        }

        private void btnViewAllPages_Click(object sender, EventArgs e)
        {
            SessionView form = new SessionView();
            form.Show();
            this.Hide();
        }
        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            SessionEdit form = new SessionEdit();
            form.Show();
            this.Hide();
        }

        private void btnDeletePage_Click(object sender, EventArgs e)
        {
            SessionDelete form = new SessionDelete();
            form.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
