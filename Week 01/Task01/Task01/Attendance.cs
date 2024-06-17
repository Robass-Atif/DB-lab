using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task01
{
    public partial class Attendance : Form
    {
        public Attendance()
        {
            InitializeComponent();
            

        }
        // 
        

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
          

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Skip the last row if it's the new row for adding new data
                if (row.IsNewRow)
                    continue;

                string studentRegNo = row.Cells[0].Value.ToString(); // Assuming StudentRegNo is in the first column
                string courseName = textBox1.Text;
                DateTime timeStamp = DateTime.Now;
                bool status=false;
                if(!Convert.ToBoolean(row.Cells[1].Value))
                {
                     status = true;

                }
               

                SqlCommand cmd = new SqlCommand("INSERT INTO Attendance (StudentRegNo, CourseName, TimeStamp, Status) VALUES (@StudentRegNo, @CourseName, @TimeStamp, @Status)", con);
                cmd.Parameters.AddWithValue("@StudentRegNo", studentRegNo);
                cmd.Parameters.AddWithValue("@CourseName", courseName);
                cmd.Parameters.AddWithValue("@TimeStamp", timeStamp);
                cmd.Parameters.AddWithValue("@Status", status);

                cmd.ExecuteNonQuery(); // Execute the SQL command
            }

            MessageBox.Show("Successfully saved");

            // Call ListStudent() function to update the DataGridView or perform any other necessary actions
            showData();

           

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showData();
        }
        private void showData()
        {

            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECT StudentRegNo FROM Enrollments WHERE CourseName = @CourseName", con);
                cmd.Parameters.AddWithValue("@CourseName", textBox1.Text);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Add a new column named "Status" with Boolean data type
                dt.Columns.Add("Status", typeof(bool));

                // Set the default value for the "Status" column to false (unchecked)
                foreach (DataRow row in dt.Rows)
                {
                    row["Status"] = false;
                }

                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message);
            }





        }
    }
}
