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

namespace MID_Project
{
    public partial class CloAdd : Form
    {
        public CloAdd()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CLo_Menu m = new CLo_Menu();
            m.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string dateCreate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string dateUpdate = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into CLo values (@Name, @DateCreated, @DateUpdated)", con);
            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@DateCreated", dateCreate);
            cmd.Parameters.AddWithValue("@DateUpdated", dateUpdate);



            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully saved");

        }
    }
}
