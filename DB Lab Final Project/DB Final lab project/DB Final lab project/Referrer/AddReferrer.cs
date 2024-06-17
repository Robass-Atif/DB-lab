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

namespace DB_Final_lab_project.Referrer
{
    public partial class AddReferrer : Form
    {
        public AddReferrer()
        {
            InitializeComponent();
            GetWebsites();
            GetReferrerType();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("stpAddReferrer", con);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@WebsiteID", GetWebsiteId());
                cmd.Parameters.AddWithValue("@ReferrerName", textBox1.Text);
                cmd.Parameters.AddWithValue("@ReferrerType", GetLookupId());
                cmd.Parameters.AddWithValue("@ReferrerURL", textBox2.Text);


                cmd.ExecuteNonQuery();
                MessageBox.Show("Referrer Added");
            
          
        }

        private int GetLookupId()
        {
            int lookupID = 0;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select ID from ReferrerTypeView where Value=@Value", con);


            cmd.Parameters.AddWithValue("@Value", comboBox2.Text);

            object result = cmd.ExecuteScalar();
            if (result != null)
            {
                lookupID = Convert.ToInt32(result);
            }

            return lookupID;
        }


        private int GetWebsiteId()
        {
            int websiteID = 0;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select WebsiteID from WebsiteForReferrerView where WebsiteName=@WebsiteName", con);


            cmd.Parameters.AddWithValue("@WebsiteName", comboBox1.Text);

            object result = cmd.ExecuteScalar();
            if (result != null)
            {
                websiteID = Convert.ToInt32(result);
            }

            return websiteID;
        }

        private void GetWebsites()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select WebsiteName from WebsiteForReferrerView", con);



            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);


            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "WebsiteName";
            comboBox1.ValueMember = "WebsiteName";
        }

        private void GetReferrerType()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Value from ReferrerTypeView", con);



            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);


            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "Value";
            comboBox2.ValueMember = "Value";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f = new ReferrerMenu();
            f.Show();
            this.Close();
        }
    }
}
