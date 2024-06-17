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
    public partial class Update_Assessment : Form
    {
        public Update_Assessment()
        {
            InitializeComponent();
            hideComponent();
            loadTitle();
            
        }
        private void loadTitle()
        {
            // load title in combobox1 from assessment table from database
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Title from Assessment", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Title";
            comboBox1.ValueMember = "Title";
            
        }
        private void hideComponent()
        {
            label1.Hide();
            label2.Hide();
           
            label3.Hide();
            label4.Hide();

            textBox1.Hide();
            dateTimePicker1.Hide();
            numericUpDown1.Hide();
            numericUpDown2.Hide();

            button3.Hide();

        }  
        private void showComponent()
        {
            label1.Show();
            label2.Show();
            label3.Show();
            label4.Show();

            textBox1.Show();
            dateTimePicker1.Show();
            numericUpDown1.Show();
            numericUpDown2.Show();

            button3.Show();
        }


        private void Update_Assessment_Load(object sender, EventArgs e)
        {

        }
        int id;
        private void button1_Click(object sender, EventArgs e)
        {
            showComponent();
            button1.Hide();
            label5.Hide();
            comboBox1.Hide();

            // load data from assessment table in components
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Assessment where Title=@Title", con);
            cmd.Parameters.AddWithValue("@Title", comboBox1.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                id = Convert.ToInt32(dt.Rows[0][0]);
                textBox1.Text = dt.Rows[0][1].ToString();
                dateTimePicker1.Text = dt.Rows[0][2].ToString();
                numericUpDown1.Text = dt.Rows[0][3].ToString();
                numericUpDown2.Text = dt.Rows[0][4].ToString();
            }



        }

        private void button3_Click(object sender, EventArgs e)
        {
            // store data in database
            var con = Configuration.getInstance().getConnection();
            
            SqlCommand cmd = new SqlCommand("Update Assessment set Title=@Title,DateCreated=@DateCreated,TotalMarks=@TotalMarks,TotalWeightage=@TotalWeightage where Id=@Id", con);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Title", textBox1.Text);
            cmd.Parameters.AddWithValue("@DateCreated", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@TotalMarks", numericUpDown1.Value);
            cmd.Parameters.AddWithValue("@TotalWeightage", numericUpDown2.Value);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Updated Successfully");


        }

        private void button4_Click(object sender, EventArgs e)
        {
            Assesmant_Menu m = new Assesmant_Menu();
            m.Show();
            this.Hide();

         }
    }
}
