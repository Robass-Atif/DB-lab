using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DB_Final_lab_project.User
{
    public partial class DeleteUser : Form
    {
        public DeleteUser()
        {
            InitializeComponent();
            ShowUserData();
            



        }

        private void ShowUserData()
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM UserDetailDeleteView;", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DelUserGrid.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }



        private void DelUserGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            User.MenuUser form = new User.MenuUser();
            form.Show();
            this.Hide();
        }

        private void DelUserGrid_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {


            if (e.ColumnIndex == 0)
            {
                try
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("stpDeleteUser", con);
                    cmd.Parameters.AddWithValue("@UserID", DelUserGrid.CurrentRow.Cells["UserID"].Value.ToString());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Deleted Successfully");
                    ShowUserData();
                }

                catch (SqlException ex)
                {
                    MessageBox.Show("Row Not deleted due to error: " + ex.Message);
                }
            }
        }

    


    }
}
