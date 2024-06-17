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
    public partial class delete_Assessment : Form
    {
        public delete_Assessment()
        {
            InitializeComponent();
            load();
        }
        private void load()
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

        private void delete_Assessment_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Assesmant_Menu menu = new Assesmant_Menu();
            menu.Show();
            this.Hide();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // delete from assesment table 
            var con = Configuration.getInstance().getConnection();
            
            string title = comboBox1.Text;
            string query = "DELETE FROM Assessment WHERE Title = '" + title + "'";
          
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            // message
            MessageBox.Show("Assessment Deleted Successfully");
            load();
            


        }
    }
}
