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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MID_Project.Rubric_Level
{
    public partial class RubricLevel : Form
    {
        public RubricLevel()
        {
            InitializeComponent();
            loadData();
        }
        private void loadData()
        {
            // load clo id from clo table from database

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Details from Rubric", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Details";
            comboBox1.ValueMember = "Details";
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void RubricLevel_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            RubricMenu m = new RubricMenu();
            m.Show();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // first close all connenction
            var con = Configuration.getInstance().getConnection();
            


            // insert value in RubricLevel Table in database
            int id;
            var con1 = Configuration.getInstance().getConnection();
              
            SqlCommand cmd1 = new SqlCommand("SELECT Id FROM Rubric WHERE Details=@Detail", con1);
            cmd1.Parameters.AddWithValue("@Detail", comboBox1.Text);
            id = (int)cmd1.ExecuteScalar();


            var con45 = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("INSERT INTO RubricLevel (RubricId,Details,MeasurementLevel) VALUES (@RubricId, @Details, @MeasurementLevel)", con45);
            // id from Rubric Table where details are selected in combobox

            
            cmd.Parameters.AddWithValue("@RubricId",id );
            
            cmd.Parameters.AddWithValue("@Details", maskedTextBox1.Text);
            cmd.Parameters.AddWithValue("@MeasurementLevel", numericUpDown1.Value);


           
           

            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully saved");
            



        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
