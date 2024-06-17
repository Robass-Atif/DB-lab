using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Final_lab_project.Reports
{
    public partial class ReportMenu : Form
    {
        public ReportMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = "WebsiteReport.rpt";
            Form f = new Report(path);
            f.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = "WebsiteDeviceDistributionReport.rpt";
            Form f = new Report(path);
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string path = "ReferrerReport.rpt";
            Form f = new Report(path);
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string path = "SessionReport.rpt";
            Form f = new Report(path);
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string path = "WebsitePageEvents.rpt";
            Form f = new Report(path);
            f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string path = "WebsitePageSection.rpt";
            Form f = new Report(path);
            f.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string path = "WebsitePagesReport.rpt";
            Form f = new Report(path);
            f.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string path = "WebsiteUserCount.rpt";
            Form f = new Report(path);
            f.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form f = new Form1();
            f.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string path = "WebsiteUsersCountryDistribution.rpt";
            Form f = new Report(path);
            f.Show();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            string path = "WebsiteUsersCountryDistribution.rpt";
            Form f = new Report(path);
            f.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string path = "WebsiteUSerAgeCategory.rpt";
            Form f = new Report(path);
            f.Show();
        }
    }
}
