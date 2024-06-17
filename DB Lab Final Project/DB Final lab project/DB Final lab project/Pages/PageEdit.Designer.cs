namespace DB_Final_lab_project.Pages
{
    partial class PageEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPage = new System.Windows.Forms.DataGridView();
            this.PageType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Perpetua", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(317, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 42);
            this.label1.TabIndex = 2;
            this.label1.Text = "Edit Page";
            // 
            // dgvPage
            // 
            this.dgvPage.AllowUserToAddRows = false;
            this.dgvPage.AllowUserToDeleteRows = false;
            this.dgvPage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PageType});
            this.dgvPage.Location = new System.Drawing.Point(164, 83);
            this.dgvPage.Name = "dgvPage";
            this.dgvPage.RowHeadersWidth = 51;
            this.dgvPage.Size = new System.Drawing.Size(500, 299);
            this.dgvPage.TabIndex = 3;
            this.dgvPage.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPage_CellContentClick);
            this.dgvPage.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPage_CellValueChanged);
            // 
            // PageType
            // 
            this.PageType.HeaderText = "PageType";
            this.PageType.Items.AddRange(new object[] {
            "Home",
            "About",
            "Contact",
            "Services",
            "Blogs",
            "Landing",
            "Others"});
            this.PageType.MinimumWidth = 6;
            this.PageType.Name = "PageType";
            this.PageType.Width = 125;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(324, 393);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(158, 45);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // PageEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dgvPage);
            this.Controls.Add(this.label1);
            this.Name = "PageEdit";
            this.Text = "PageEdit";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPage;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridViewComboBoxColumn PageType;
    }
}