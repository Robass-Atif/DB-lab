using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Final_lab_project.Website
{
    public partial class WebsiteMenu : Form
    {
        public WebsiteMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Form f = new Form1();
            f.Show();
            this.Hide();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Form f = new AddWebsite();
            f.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form f = new ShowWebsites();
            f.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form f = new EditWebsite();
            f.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form f = new DeleteWebsite();
            f.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("stpUpdatePagePerVisit", con);
            SqlCommand cmd2 = new SqlCommand("stpUpdateAvgTimeDuration", con);
            SqlCommand cmd3 = new SqlCommand("stpUpdateBounceRate", con);
            SqlCommand cmd4 = new SqlCommand("stpUpdateGlobalRank", con);
            SqlCommand cmd5 = new SqlCommand("stpUpdateCategoryRank", con);


            cmd.CommandType = CommandType.StoredProcedure;
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd3.CommandType = CommandType.StoredProcedure;
            cmd4.CommandType = CommandType.StoredProcedure;
            cmd5.CommandType = CommandType.StoredProcedure;

            MessageBox.Show("Data Updated");

        }
    }
}
