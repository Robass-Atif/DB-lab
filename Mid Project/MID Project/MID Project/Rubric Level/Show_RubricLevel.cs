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

namespace MID_Project.Rubric_Level
{
    public partial class Show_RubricLevel : Form
    {
        public Show_RubricLevel()
        {
            InitializeComponent();
            load();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RubricLevel_Menu menu = new RubricLevel_Menu();
            menu.Show();
                this.Close();
        }
        private void load()
        {
            // load data from database
            var con = Configuration.getInstance().getConnection();
            // Selecting data from the database
            SqlCommand cmd = new SqlCommand("SELECT l.Details,l.MeasurementLevel,r.Details,c.Name from RubricLevel as l join Rubric as r on l.RubricId=r.Id join Clo as c on c.Id=r.cloId  ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }

        private void Show_RubricLevel_Load(object sender, EventArgs e)
        {

        }
    }
}
