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

namespace DB_Final_lab_project.Events
{
    public partial class Add_Event : Form
    {
        public Add_Event()
        {
            InitializeComponent();
            loadSection();
            loadEventValueFromLookup();
        }
        void  loadSection()
        {
            //load section details from database and show in combobox
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select PageSectionId from PageSection", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);


            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "PageSectionId";
            comboBox1.ValueMember = "PageSectionId";

        }
        void loadEventValueFromLookup()
        {
            //load event details from database and show in combobox2
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Value from Lookup where Category = 'EVENT_CATEGORY'", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);


            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "Value";
            comboBox2.ValueMember = "Value";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Event_Menu em = new Event_Menu();
            em.Show();
            this.Close();

        }

        private void Add_Event_Load(object sender, EventArgs e)
        {

        }

        int getSectionID()
        {

            return Convert.ToInt32(comboBox1.Text);
        }   
        int getEventID()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select ID from Lookup where Value=@Value", con);
            cmd.Parameters.AddWithValue("@Value", comboBox2.Text);
            object result = cmd.ExecuteScalar();
            
                int id = Convert.ToInt32(result);
            return id;


        }

        private void button2_Click(object sender, EventArgs e)
        {
           
           try
            { 


                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("stp_AddEvent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PageSectionID", getSectionID());
                TimeSpan eventTime;
                if (TimeSpan.TryParse(maskedTextBox1.Text, out eventTime))
                {
                   
                    string sqlEventTime = eventTime.ToString(@"hh\:mm\:ss");

                   
                    cmd.Parameters.AddWithValue("@EventTime", sqlEventTime);
                }
                else
                {
                    
                    Console.WriteLine("Invalid time format entered.");
                }
                cmd.Parameters.AddWithValue("@EventType", getEventID());
                cmd.Parameters.AddWithValue("@EventDetails", textBox1.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Event Added");

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Row Not deleted due to error: " + ex.Message);
            }
        }

    }
}
