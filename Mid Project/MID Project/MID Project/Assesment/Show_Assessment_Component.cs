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

namespace MID_Project.Assesment
{
    public partial class Show_Assessment_Component : Form
    {
        public Show_Assessment_Component()
        {
            InitializeComponent();
            load();
        }

        private void load()
        {

            var con = Configuration.getInstance().getConnection();

            // Selecting data from the database
            SqlCommand cmd = new SqlCommand("SELECT Name,(select Details from Rubric where Id=RubricId),TotalMarks,DateCreated,DateUpdated,(select Title from Assessment where AssessmentId=Id) from AssessmentComponent ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            // Updating the status column to "active" if it equals 5


            // Updating the changes back to the database
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(da);
            da.Update(dt);

            // Displaying the updated data in the DataGridView
            dataGridView1.DataSource = dt;

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Assesmant_Menu assesmant_Menu = new Assesmant_Menu();
            assesmant_Menu.Show();
            this.Close();
        }

        private void Show_Assessment_Component_Load(object sender, EventArgs e)
        {

        }
    }
}
