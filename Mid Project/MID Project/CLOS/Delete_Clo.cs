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

namespace MID_Project
{
    public partial class Delete_Clo : Form
    {
        public Delete_Clo()
        {
            InitializeComponent();
            load();
        }
        private void load()
        {
            // load clos from databasse
            var con = Configuration.getInstance().getConnection();

            // Selecting data from the database
            SqlCommand cmd = new SqlCommand("SELECT Name FROM CLO ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            // in combobox
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Name";
            




        }

        private void button4_Click(object sender, EventArgs e)
        {
            CLo_Menu cLo_Menu = new CLo_Menu();
            cLo_Menu.Show();
            this.Close();

        }

        private void Delete_Clo_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            

            // Delete corresponding rows from RubricLevel table first
            SqlCommand cmd1 = new SqlCommand("DELETE FROM RubricLevel WHERE RubricId IN (SELECT Id FROM Rubric WHERE cloId = (SELECT Id FROM Clo WHERE Name = @Name))", con);
            cmd1.Parameters.AddWithValue("@Name", comboBox1.SelectedValue);
            cmd1.ExecuteNonQuery();

            // Delete corresponding rows from Rubric table
            SqlCommand cmd2 = new SqlCommand("DELETE FROM Rubric WHERE cloId = (SELECT Id FROM Clo WHERE Name = @Name)", con);
            cmd2.Parameters.AddWithValue("@Name", comboBox1.SelectedValue);
            cmd2.ExecuteNonQuery();

            // Delete from Clo table after deleting associated rows from RubricLevel and Rubric tables
            SqlCommand cmd3 = new SqlCommand("DELETE FROM Clo WHERE Name = @Name", con);
            cmd3.Parameters.AddWithValue("@Name", comboBox1.SelectedValue);
            cmd3.ExecuteNonQuery();

            

          

            MessageBox.Show("CLO Deleted Successfully");
            load();

        }
    }
}
