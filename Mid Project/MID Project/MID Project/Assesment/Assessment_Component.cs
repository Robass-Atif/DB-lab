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
    public partial class Assessment_Component : Form
    {
        public Assessment_Component()
        {
            InitializeComponent();
            load();
        }
        
        private void load()
        {
            var con = Configuration.getInstance().getConnection();
            if (con.State != ConnectionState.Open) // Check if the connection is closed
                con.Open(); // Open the connection if it's closed

         
            SqlCommand cmd = new SqlCommand("Select Details  from Rubric", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Details";
            comboBox1.ValueMember = "Details";
            con.Close();

            var con1 = Configuration.getInstance().getConnection();
            if (con1.State != ConnectionState.Open) // Check if the connection is closed
                con1.Open(); // Open the connection if it's closed

            SqlCommand cmd1 = new SqlCommand("Select Title  from Assessment", con1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            comboBox2.DataSource = dt1;
            comboBox2.DisplayMember = "Title";
              comboBox2.ValueMember = "Title";
            con1.Close();



        }

        private void load1()
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Assesmant_Menu menu = new Assesmant_Menu();
            this.Close();
            menu.Show();
        }

        private void Assessment_Component_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id;
            var con1 = Configuration.getInstance().getConnection();
            if (con1.State != ConnectionState.Open) // Check if the connection is closed
                con1.Open(); // Open the connection if it's closed

            SqlCommand cmd1 = new SqlCommand("SELECT Id FROM Rubric WHERE Details=@Detail", con1);
            cmd1.Parameters.AddWithValue("@Detail", comboBox1.Text);
            id = (int)cmd1.ExecuteScalar();
            con1.Close();
            int id1;
            var con2 = Configuration.getInstance().getConnection();
            con2.Open();
            SqlCommand cmd2 = new SqlCommand("SELECT Id FROM Assessment WHERE Title=@Title", con2);
            cmd2.Parameters.AddWithValue("@Title", comboBox2.Text);
            id1 = (int)cmd2.ExecuteScalar();
            con2.Close();


            var con = Configuration.getInstance().getConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into AssessmentComponent values (@Name, @RubricId, @TotalMarks,@DateCreated,@DateUpdated,@AssessmentId)", con);
            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            
            cmd.Parameters.AddWithValue("@RubricId",id );
            cmd.Parameters.AddWithValue("@TotalMarks", numericUpDown1.Value);
            string date1 = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            cmd.Parameters.AddWithValue("@DateCreated",date1 );
            string date2 = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            cmd.Parameters.AddWithValue("@DateUpdated",date2 );
            cmd.Parameters.AddWithValue("@AssessmentId",id1 );

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Assesment Added Successfully");

        }
    }
}
