using CRUD_Operations;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MID_Project
{
    public partial class Rubric_Level_Report : Form
    {
        public Rubric_Level_Report()
        {
            InitializeComponent();
            load();
        }
        void load()
        {
            // load from database
            var con = Configuration.getInstance().getConnection();
            
            string query = "SELECT l.Details,l.MeasurementLevel,r.Details,c.Name from RubricLevel as l join Rubric as r on l.RubricId=r.Id join Clo as c on c.Id=r.cloId  ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reports reports = new Reports();
            reports.Show();
            this.Hide();

        }

        private void Rubric_Level_Report_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            string query = "SELECT l.Details,l.MeasurementLevel,r.Details,c.Name from RubricLevel as l join Rubric as r on l.RubricId=r.Id join Clo as c on c.Id=r.cloId  ";


            {

                

                // Create a SqlCommand object
                SqlCommand command = new SqlCommand(query, con);

                // Create a DataTable to hold the results
                DataTable dataTable = new DataTable();

                // Create a SqlDataAdapter to fill the DataTable
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                // Fill the DataTable
                adapter.Fill(dataTable);

                // Check if the DataTable contains data
                if (dataTable.Rows.Count > 0)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "PDF (*.pdf)|*.pdf";
                    saveFileDialog.FileName = "CLOs.pdf";
                    bool fileError = false;
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        if (File.Exists(saveFileDialog.FileName))
                        {
                            try
                            {
                                File.Delete(saveFileDialog.FileName);
                            }
                            catch (IOException ex)
                            {
                                fileError = true;
                                MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                            }
                        }
                        if (!fileError)
                        {
                            try
                            {
                                // Create a Document instance
                                iTextSharp.text.Document document = new iTextSharp.text.Document();
                                // Create a PdfWriter instance
                                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create));
                                // Open the document
                                document.Open();

                                // Add a heading to the document
                                // heading with bif font
                                document.Add(new Paragraph("Rubric Level Report"));
                                document.Add(Chunk.NEWLINE); // Add some space after the heading

                                document.Add(new Paragraph("This is Rubric Level With its Rubric Details and Clos Name"));
                                document.Add(Chunk.NEWLINE); // Add some space after the heading

                                // Create a PdfPTable instance
                                PdfPTable pdfTable = new PdfPTable(dataTable.Columns.Count);
                                pdfTable.DefaultCell.Padding = 3;
                                pdfTable.WidthPercentage = 80;
                                pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                                pdfTable.DefaultCell.BorderWidth = 1;

                                // Add column names
                                foreach (DataColumn column in dataTable.Columns)
                                {
                                    PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName));
                                    pdfTable.AddCell(cell);
                                }

                                // Add data rows
                                foreach (DataRow row in dataTable.Rows)
                                {
                                    foreach (DataColumn column in dataTable.Columns)
                                    {
                                        PdfPCell cell = new PdfPCell(new Phrase(row[column].ToString()));
                                        pdfTable.AddCell(cell);
                                    }
                                }

                                // Add the PdfPTable to the document
                                document.Add(pdfTable);

                                // Close the document
                                document.Close();
                                writer.Close();

                                MessageBox.Show("Data Exported Successfully !!!");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error :" + ex.Message);
                            }

                        }
                    }
                }
                else
                {
                    MessageBox.Show("No Data Found");
                }
            }
        }
    }
}
