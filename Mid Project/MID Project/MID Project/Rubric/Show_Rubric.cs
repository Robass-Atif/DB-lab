using CRUD_Operations;
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

namespace MID_Project.Rubric
{
    public partial class Show_Rubric : Form
    {
        public Show_Rubric()
        {
            InitializeComponent();
            load();
        }
        private void load()
        {
            // load data from database
            var con = Configuration.getInstance().getConnection();
            // Selecting data from the database
            SqlCommand cmd = new SqlCommand("SELECT Details,(Select Name  from Clo where CloId=Id) as CloName FROM Rubric ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            

        }   

        private void button1_Click(object sender, EventArgs e)
        {
            RubricMenu menu = new RubricMenu();
            menu.Show();
            this.Hide();

        }

        private void Show_Rubric_Load(object sender, EventArgs e)
        {

        }
    }
}
