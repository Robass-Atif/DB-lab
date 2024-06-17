using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task01
{
    public partial class Delete : Form
    {
        public Delete()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();

                SqlCommand cmd = new SqlCommand("DELETE FROM Student WHERE RegistrationNUmber = @RegistrationNumber", con);
                cmd.Parameters.AddWithValue("@RegistrationNumber", textBox1.Text);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Student record deleted successfully");

                }
                else
                {
                    MessageBox.Show("Student record not found");
                }
            
            

            Form1 f = new Form1();
            f.Show();
            this.Close();

        }

        private void Delete_Load(object sender, EventArgs e)
        {

        }
    }
}
