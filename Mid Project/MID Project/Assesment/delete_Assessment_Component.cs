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
    public partial class delete_Assessment_Component : Form
    {
        public delete_Assessment_Component()
        {
            InitializeComponent();
            load();
        }
        private void load()
        {
            // load title in combobox1 from assessment table from database
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Name from AssessmentComponent", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Name";
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Assesmant_Menu menu = new Assesmant_Menu();
            menu.Show();
            this.Hide();

        }

        private void delete_Assessment_Component_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  first delete result
            var con1 = Configuration.getInstance().getConnection();
            
            SqlCommand cmd1 = new SqlCommand("Delete from StudentResult where AssessmentComponentId = (Select Id from AssessmentComponent where Name = @Name)", con1);
            cmd1.Parameters.AddWithValue("@Name", comboBox1.Text);
            cmd1.ExecuteNonQuery();
           


            // delete from database
            var con = Configuration.getInstance().getConnection();
            
            SqlCommand cmd = new SqlCommand("Delete from AssessmentComponent where Name = @Name", con);
            cmd.Parameters.AddWithValue("@Name", comboBox1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Deleted");
            
            load();

        }
    }
}
