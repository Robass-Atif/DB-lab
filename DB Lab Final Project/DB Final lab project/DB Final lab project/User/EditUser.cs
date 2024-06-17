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

namespace DB_Final_lab_project.User
{
    public partial class EditUser : Form
    {
      
        public EditUser()
        {
            InitializeComponent();
            ShowUserData();
            dataGridView1.DataError += dataGridView1_DataError;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
      



        }





        private void ShowUserData()
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM UserDetailEditView;", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Create a combo box column with distinct gender values
                DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
                comboBoxColumn.Name = "GenderComboBox";
                comboBoxColumn.HeaderText = "Gender";
                comboBoxColumn.DataPropertyName = "Gender";
                comboBoxColumn.DataSource = dt.DefaultView.ToTable(true, "Gender");
                comboBoxColumn.ValueMember = "Gender";
                comboBoxColumn.DisplayMember = "Gender";



                // Bind the DataGridView to the complete user data
                dataGridView1.DataSource = dt;

                // Add the combo box column to the DataGridView
                dataGridView1.Columns.Add(comboBoxColumn);

                // Hide the original 'Gender' text column
                dataGridView1.Columns["Gender"].Visible = false;
                // Set the display index of the combo box column next to where the 'Gender' column was
                comboBoxColumn.DisplayIndex = dataGridView1.Columns["Gender"].DisplayIndex;
                // Make the UserID column read-only
                dataGridView1.Columns["UserID"].ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }




        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
               
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", int.Parse(dataGridView1.Rows[e.RowIndex].Cells["UserID"].Value.ToString()));

                if (dataGridView1.Columns[e.ColumnIndex].Name == "FirstName")
                {
                    cmd.CommandText = "stpUpdateUserFirstName";
                    cmd.Parameters.AddWithValue("@FirstName", dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "LastName")
                {
                    cmd.CommandText = "stpUpdateUserLastName";
                    cmd.Parameters.AddWithValue("@LastName", dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "Email")
                {
                    cmd.CommandText = "stpUpdateUserEmail";
                    cmd.Parameters.AddWithValue("@Email", dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "RegistrationDate")
                {
                    cmd.CommandText = "stpUpdateUserRegistrationDate";
                    cmd.Parameters.AddWithValue("@RegistrationDate", Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "LastLoginDate")
                {
                    cmd.CommandText = "stpUpdateUserLastLoginDate";
                    cmd.Parameters.AddWithValue("@LastLoginDate", Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "City")
                {
                    cmd.CommandText = "stpUpdateUserCity";
                    cmd.Parameters.AddWithValue("@City", dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "Country")
                {
                    cmd.CommandText = "stpUpdateUserCountry";
                    cmd.Parameters.AddWithValue("@Country", dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "Age")
                {
                    cmd.CommandText = "stpUpdateUserAge";
                    cmd.Parameters.AddWithValue("@Age", Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "GenderComboBox") // Check if the edited cell is in the "Gender" combo box column
                {
                    cmd.CommandText = "stpUpdateUserGender";
                    cmd.Parameters.AddWithValue("@Gender", dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                }

                if (!string.IsNullOrEmpty(cmd.CommandText))
                {
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Edited");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
           
        }




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            User.MenuUser form = new User.MenuUser();
            form.Show();
            this.Hide();

        }
    }
}
