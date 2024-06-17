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

namespace DB_Final_lab_project.Referrer
{
    public partial class DeleteReferrer : Form
    {
        public DeleteReferrer()
        {
            InitializeComponent();
            GetData();
        }

        private void DeleteReferrer_Load(object sender, EventArgs e)
        {

        }


        private void GetData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM DeleteReferrerView", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                try
                {

                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("stpDeleteReferrer", con);
                    cmd.Parameters.AddWithValue("@ReferrerID", dataGridView1.CurrentRow.Cells["ReferrerID"].Value.ToString());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Row Deleted");
                    GetData();
                }

                catch (SqlException ex)
                {
                    MessageBox.Show("Row Not deleted due to error: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new ReferrerMenu();
            f.Show();
            this.Hide();
        }
    }
}
