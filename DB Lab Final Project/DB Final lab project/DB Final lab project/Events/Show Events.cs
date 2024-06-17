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

namespace DB_Final_lab_project.Events
{
    public partial class Show_Events : Form
    {
        public Show_Events()
        {
            InitializeComponent();
            loadData();
        }

        void loadData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from ShowEventView", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
             da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Event_Menu event_Menu = new Event_Menu();
            event_Menu.Show();
            this.Close();

        }

        private void Show_Events_Load(object sender, EventArgs e)
        {

        }
    }
}
