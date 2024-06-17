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

namespace MID_Project.Result
{
    public partial class Show_Result : Form
    {
        public Show_Result()
        {
            InitializeComponent();
            load();
        }
        private void load()
        {
            // load all clos in datagridview not id


            var con = Configuration.getInstance().getConnection();

            // Selecting data from the database
            SqlCommand cmd = new SqlCommand("SELECT (select FirstName from Student where StudentId=Id) as StudentName,(select Name from AssessmentComponent where AssessmentComponentId=Id) as AssessmentComponent,(select MeasurementLevel from RubricLevel where RubricMeasurementId=Id) as MeasurementLevel,EvaluationDate FROM StudentResult ", con);
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

         

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Result_Menu result_Menu = new Result_Menu();
            result_Menu.Show();
            this.Close();

        }

        private void Show_Result_Load(object sender, EventArgs e)
        {

        }
    }
}
