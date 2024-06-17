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

namespace MID_Project.Assesment
{
    public partial class Add_Assesment : Form
    {
        public Add_Assesment()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // insert in Assesmant table
            var con = Configuration.getInstance().getConnection();
            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("Insert into Assessment values (@Title, @DateCreated, @TotalMarks,@TotalWeightage)", con);
            cmd.Parameters.AddWithValue("@Title", textBox1.Text);
            string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            cmd.Parameters.AddWithValue("@DateCreated", date);
            cmd.Parameters.AddWithValue("@TotalMarks", numericUpDown1.Value);
            cmd.Parameters.AddWithValue("@TotalWeightage", numericUpDown2.Value);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Assesment Added Successfully");


 

        }

        private void Add_Assesment_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Assesmant_Menu assesmant_Menu= new Assesmant_Menu();
            assesmant_Menu.Show();
            this.Close();

        }
    }
}
