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

namespace DB_Final_lab_project.Website
{
    public partial class AddWebsite : Form
    {
        public AddWebsite()
        {
            InitializeComponent();
            WebsiteIndustry();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("stpAddWebsite", con);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@WebsiteName", textBox1.Text);
                cmd.Parameters.AddWithValue("@WebsiteURL", textBox2.Text);
                cmd.Parameters.AddWithValue("@WebsiteIndustry", GetLookupID());
                cmd.Parameters.AddWithValue("@Description", textBox3.Text);
               

                cmd.ExecuteNonQuery();
                MessageBox.Show("Website Added");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }


        private void WebsiteIndustry()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Value from WebsiteIndustryView", con);
            


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);


            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Value";

        }



        private int GetLookupID()
        {
            int LookupID = 0;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Id from WebsiteIndustryView where Value=@Value", con);
            

            cmd.Parameters.AddWithValue("@Value", comboBox1.Text);

            object result = cmd.ExecuteScalar();
            if (result != null)
            {
                LookupID = Convert.ToInt32(result);
            }

            return LookupID;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f = new WebsiteMenu();
            f.Show();
            this.Hide();
        }

        private void AddWebsite_Load(object sender, EventArgs e)
        {

        }
    }
}
