using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task01
{
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Student WHERE RegistrationNUmber = @RegistrationNUmber", con);
            cmd.Parameters.AddWithValue("@RegistrationNUmber", textBox1.Text);

            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                // Data found, bind it to DataGridView
                dataGridView1.DataSource = dataTable;
            }
            else
            {
                // No data found
                MessageBox.Show("Student not found.");
            }

        }
    }
}
