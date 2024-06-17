using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MID_Project
{
    public partial class Update_Clo : Form
    {
        public Update_Clo()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
             CLo_Menu m=new CLo_Menu();
            m.Show();
            this.Close();
        }

        private void Update_Clo_Load(object sender, EventArgs e)
        {

        }
    }
}
