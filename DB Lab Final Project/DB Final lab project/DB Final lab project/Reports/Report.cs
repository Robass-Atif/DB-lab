using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Final_lab_project.Reports
{
    public partial class Report : Form
    {
        string fileName;
        public Report(string fileName)
        {
            InitializeComponent();
            this.fileName = fileName;
           
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {



            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = $"..\\..\\Reports\\{fileName}";
            string fullPath = Path.GetFullPath(Path.Combine(basePath, relativePath));

         

            ReportDocument r = new ReportDocument();
            r.Load(fullPath);
            crystalReportViewer1.ReportSource = r;

        }

        private void Report_Load(object sender, EventArgs e)
        {

        }
    }
}
