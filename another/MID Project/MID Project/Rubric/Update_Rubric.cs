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

namespace MID_Project.Rubric
{
    public partial class Update_Rubric : Form
    {
        public Update_Rubric()
        {
            InitializeComponent();
           hideComponent();
            loadDetails();
            

        }
        private void loadDetails()
        {
            // load datails from rubric table from database in combobox2
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Details from Rubric", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "Details";
            comboBox2.ValueMember = "Details";
            
        }

        private void hideComponent()
        {
            label1.Hide();
            label2.Hide();
            comboBox1.Hide();
            textBox1.Hide();
            button3.Hide();

        }
        private void showComponent()
        {
            label1.Show();
            label2.Show();
            comboBox1.Show();
            textBox1.Show();
            button3.Show();
        }
        int id;
        void loadData()
        {
            // load clo id from clo table from database

            string selectedRegistrationNumber = comboBox2.Text;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Rubric where Details=@Details", con);
            cmd.Parameters.AddWithValue("@Details", selectedRegistrationNumber);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            

            // fill the data in component for update
            if (dt.Rows.Count > 0)

            {
                id= Convert.ToInt32(dt.Rows[0][0]);
                textBox1.Text = dt.Rows[0][1].ToString();
                // here load clo name from clo table from database
                SqlCommand cmd1 = new SqlCommand("Select Name from Clo", con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                comboBox1.DataSource = dt1;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Name";
                


            }

        }   

        private void Update_Rubric_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            showComponent();
            loadData();
            button2.Hide();
            label3.Hide();
            comboBox2.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int cloId;
            var con1 = Configuration.getInstance().getConnection();
            
            SqlCommand cmd1 = new SqlCommand("SELECT Id FROM clo WHERE Name=@Name", con1);
            cmd1.Parameters.AddWithValue("@Name", comboBox1.Text);
            cloId = (int)cmd1.ExecuteScalar();



            // update data in database
            var con = Configuration.getInstance().getConnection();
            
            SqlCommand cmd = new SqlCommand("Update Rubric set Details=@Details, CloId=@CloId where Id=@Id", con);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Details", textBox1.Text);
            cmd.Parameters.AddWithValue("@CloId",cloId );
            cmd.ExecuteNonQuery();
            
            MessageBox.Show("Rubric Updated Successfully");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RubricMenu rubricMenu = new RubricMenu();
            this.Hide();
            rubricMenu.Show();

        }
    }
}
