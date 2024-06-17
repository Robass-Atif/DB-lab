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
    public partial class CLO_Report : Form
    {
        public CLO_Report()
        {
            InitializeComponent();
            load();
        }
        void load()
        {
            // load data from database
            var con = Configuration.getInstance().getConnection();
            
            string query = "Select (select FirstName from Student where StudentId=Id) as Name,(select RegistrationNumber from Student where StudentId=Id) as RegNo,(select (select (select Name from Clo where Id=CloId) from Rubric where RubricId=Id)  from AssessmentComponent where AssessmentComponentId=Id ) as Clo, (select TotalMarks from AssessmentComponent where AssessmentComponentId=Id) as COmponentMarks,(select (select Details from Rubric where RubricId=Id)  from AssessmentComponent where AssessmentComponentId=Id ) As Rubric ,(select (select TotalMarks from Assessment Where AssessmentId=Id) from AssessmentComponent where AssessmentComponentId=Id) as StudentLevel,Round(((SELECT (select TotalMarks from Assessment where Id=AssessmentId  ) FROM AssessmentComponent WHERE Id = AssessmentComponentId)* (SELECT TotalMarks FROM AssessmentComponent WHERE AssessmentComponentId = Id)/ (SELECT CAST(MeasurementLevel AS FLOAT) FROM RubricLevel WHERE RubricMeasurementId = Id) ),2) AS ObtainedMarks   from StudentResult";  
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            


        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reports report = new Reports();
            this.Close();
            report.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            string query = "Select (select FirstName from Student where StudentId=Id) as Name,(select RegistrationNumber from Student where StudentId=Id) as RegNo,(select (select (select Name from Clo where Id=CloId) from Rubric where RubricId=Id)  from AssessmentComponent where AssessmentComponentId=Id ) as Clo, (select TotalMarks from AssessmentComponent where AssessmentComponentId=Id) as COmponentMarks,(select (select Details from Rubric where RubricId=Id)  from AssessmentComponent where AssessmentComponentId=Id ) As Rubric ,(select (select TotalMarks from Assessment Where AssessmentId=Id) from AssessmentComponent where AssessmentComponentId=Id) as StudentLevel,Round(((SELECT (select TotalMarks from Assessment where Id=AssessmentId  ) FROM AssessmentComponent WHERE Id = AssessmentComponentId)* (SELECT TotalMarks FROM AssessmentComponent WHERE AssessmentComponentId = Id)/ (SELECT CAST(MeasurementLevel AS FLOAT) FROM RubricLevel WHERE RubricMeasurementId = Id) ),2) AS ObtainedMarks   from StudentResult";


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
                    saveFileDialog.FileName = "CLo.pdf";
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
                                document.Add(new Paragraph("Assessment Report"));
                                document.Add(Chunk.NEWLINE); // Add some space after the heading

                                document.Add(new Paragraph("Assessment of Student"));
                                document.Add(Chunk.NEWLINE); // Add some space after the heading

                                // Create a PdfPTable instance
                                PdfPTable pdfTable = new PdfPTable(dataTable.Columns.Count);
                                pdfTable.DefaultCell.Padding = 3;
                                pdfTable.WidthPercentage = 70;
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

        private void CLO_Report_Load(object sender, EventArgs e)
        {

        }
    }
}
