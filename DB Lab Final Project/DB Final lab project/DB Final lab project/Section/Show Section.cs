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

namespace DB_Final_lab_project.Section
{
    public partial class Show_Section : Form
    {
        public Show_Section()
        {
            InitializeComponent();
            loadData();
        }
        void loadData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select * from PageSectionView ", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            SectionMenu sectionMenu = new SectionMenu();
            sectionMenu.Show();
            this.Close();

        }

        private void Show_Section_Load(object sender, EventArgs e)
        {

        }
    }
}
