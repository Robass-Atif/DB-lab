namespace DB_Final_lab_project.Pages
{
    partial class PageAdd
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
            this.comboBoxWebsiteID = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWebsiteName = new System.Windows.Forms.TextBox();
            this.txtWebsiteURL = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.comboBoxPageType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPageName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Perpetua", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(285, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add Page of Website";
            // 
            // comboBoxWebsiteID
            // 
            this.comboBoxWebsiteID.FormattingEnabled = true;
            this.comboBoxWebsiteID.Location = new System.Drawing.Point(143, 139);
            this.comboBoxWebsiteID.Name = "comboBoxWebsiteID";
            this.comboBoxWebsiteID.Size = new System.Drawing.Size(93, 21);
            this.comboBoxWebsiteID.TabIndex = 1;
            this.comboBoxWebsiteID.SelectedValueChanged += new System.EventHandler(this.comboBoxWebsiteID_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Perpetua", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Website ID";
            // 
            // txtWebsiteName
            // 
            this.txtWebsiteName.Location = new System.Drawing.Point(397, 140);
            this.txtWebsiteName.Name = "txtWebsiteName";
            this.txtWebsiteName.ReadOnly = true;
            this.txtWebsiteName.Size = new System.Drawing.Size(132, 20);
            this.txtWebsiteName.TabIndex = 3;
            // 
            // txtWebsiteURL
            // 
            this.txtWebsiteURL.Location = new System.Drawing.Point(684, 137);
            this.txtWebsiteURL.Name = "txtWebsiteURL";
            this.txtWebsiteURL.ReadOnly = true;
            this.txtWebsiteURL.Size = new System.Drawing.Size(172, 20);
            this.txtWebsiteURL.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Perpetua", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(559, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Website URL";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Perpetua", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(266, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "Website Name";
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(258, 374);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(137, 42);
            this.btnInsert.TabIndex = 7;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(469, 374);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(137, 42);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // comboBoxPageType
            // 
            this.comboBoxPageType.FormattingEnabled = true;
            this.comboBoxPageType.Location = new System.Drawing.Point(240, 243);
            this.comboBoxPageType.Name = "comboBoxPageType";
            this.comboBoxPageType.Size = new System.Drawing.Size(93, 21);
            this.comboBoxPageType.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Perpetua", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(139, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 24);
            this.label5.TabIndex = 10;
            this.label5.Text = "Page Type";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Perpetua", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(439, 243);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 24);
            this.label6.TabIndex = 12;
            this.label6.Text = "Page Name";
            // 
            // txtPageName
            // 
            this.txtPageName.Location = new System.Drawing.Point(543, 243);
            this.txtPageName.Name = "txtPageName";
            this.txtPageName.Size = new System.Drawing.Size(132, 20);
            this.txtPageName.TabIndex = 13;
            // 
            // PageAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(888, 450);
            this.Controls.Add(this.txtPageName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxPageType);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtWebsiteURL);
            this.Controls.Add(this.txtWebsiteName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxWebsiteID);
            this.Controls.Add(this.label1);
            this.Name = "PageAdd";
            this.Text = "AddPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxWebsiteID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWebsiteName;
        private System.Windows.Forms.TextBox txtWebsiteURL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox comboBoxPageType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPageName;
    }
}