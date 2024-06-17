namespace DB_Final_lab_project.Session
{
    partial class SessionAdd
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
            this.btnAddPage = new System.Windows.Forms.Button();
            this.btnAddSession = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.comboBoxWebsites = new System.Windows.Forms.ComboBox();
            this.comboBoxPages = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPage = new System.Windows.Forms.TextBox();
            this.dgvPagesOfSession = new System.Windows.Forms.DataGridView();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEndTime = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDevice = new System.Windows.Forms.TextBox();
            this.txtBrowser = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxUser = new System.Windows.Forms.ComboBox();
            this.dgvUserData = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagesOfSession)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserData)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Perpetua", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(305, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 42);
            this.label1.TabIndex = 8;
            this.label1.Text = "Session Add";
            // 
            // btnAddPage
            // 
            this.btnAddPage.Location = new System.Drawing.Point(624, 121);
            this.btnAddPage.Name = "btnAddPage";
            this.btnAddPage.Size = new System.Drawing.Size(164, 61);
            this.btnAddPage.TabIndex = 12;
            this.btnAddPage.Text = "Add Page";
            this.btnAddPage.UseVisualStyleBackColor = true;
            this.btnAddPage.Click += new System.EventHandler(this.btnAddPage_Click);
            // 
            // btnAddSession
            // 
            this.btnAddSession.Location = new System.Drawing.Point(177, 388);
            this.btnAddSession.Name = "btnAddSession";
            this.btnAddSession.Size = new System.Drawing.Size(164, 50);
            this.btnAddSession.TabIndex = 13;
            this.btnAddSession.Text = "Add Session";
            this.btnAddSession.UseVisualStyleBackColor = true;
            this.btnAddSession.Click += new System.EventHandler(this.btnAddSession_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(467, 388);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(164, 50);
            this.btnExit.TabIndex = 14;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // comboBoxWebsites
            // 
            this.comboBoxWebsites.FormattingEnabled = true;
            this.comboBoxWebsites.Location = new System.Drawing.Point(155, 121);
            this.comboBoxWebsites.Name = "comboBoxWebsites";
            this.comboBoxWebsites.Size = new System.Drawing.Size(147, 21);
            this.comboBoxWebsites.TabIndex = 15;
            this.comboBoxWebsites.SelectedValueChanged += new System.EventHandler(this.comboBoxWebsites_SelectedValueChanged);
            // 
            // comboBoxPages
            // 
            this.comboBoxPages.FormattingEnabled = true;
            this.comboBoxPages.Location = new System.Drawing.Point(437, 121);
            this.comboBoxPages.Name = "comboBoxPages";
            this.comboBoxPages.Size = new System.Drawing.Size(147, 21);
            this.comboBoxPages.TabIndex = 16;
            this.comboBoxPages.SelectedValueChanged += new System.EventHandler(this.comboBoxPages_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Perpetua", 15.75F);
            this.label2.Location = new System.Drawing.Point(34, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 24);
            this.label2.TabIndex = 17;
            this.label2.Text = "Website ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Perpetua", 15.75F);
            this.label3.Location = new System.Drawing.Point(360, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 24);
            this.label3.TabIndex = 18;
            this.label3.Text = "Page ID";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(155, 162);
            this.txtURL.Name = "txtURL";
            this.txtURL.ReadOnly = true;
            this.txtURL.Size = new System.Drawing.Size(147, 20);
            this.txtURL.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Perpetua", 15.75F);
            this.label4.Location = new System.Drawing.Point(16, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 24);
            this.label4.TabIndex = 20;
            this.label4.Text = "Website URL";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Perpetua", 15.75F);
            this.label5.Location = new System.Drawing.Point(333, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 24);
            this.label5.TabIndex = 21;
            this.label5.Text = "Page Name";
            // 
            // txtPage
            // 
            this.txtPage.Location = new System.Drawing.Point(437, 162);
            this.txtPage.Name = "txtPage";
            this.txtPage.ReadOnly = true;
            this.txtPage.Size = new System.Drawing.Size(147, 20);
            this.txtPage.TabIndex = 22;
            // 
            // dgvPagesOfSession
            // 
            this.dgvPagesOfSession.AllowUserToAddRows = false;
            this.dgvPagesOfSession.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPagesOfSession.Location = new System.Drawing.Point(322, 206);
            this.dgvPagesOfSession.Name = "dgvPagesOfSession";
            this.dgvPagesOfSession.ReadOnly = true;
            this.dgvPagesOfSession.Size = new System.Drawing.Size(454, 150);
            this.dgvPagesOfSession.TabIndex = 23;
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(161, 206);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(82, 20);
            this.dateTimePickerStart.TabIndex = 24;
            // 
            // dateTimePickerEndTime
            // 
            this.dateTimePickerEndTime.Location = new System.Drawing.Point(161, 242);
            this.dateTimePickerEndTime.Name = "dateTimePickerEndTime";
            this.dateTimePickerEndTime.Size = new System.Drawing.Size(82, 20);
            this.dateTimePickerEndTime.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Perpetua", 15.75F);
            this.label6.Location = new System.Drawing.Point(40, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 24);
            this.label6.TabIndex = 26;
            this.label6.Text = "Start Time";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Perpetua", 15.75F);
            this.label7.Location = new System.Drawing.Point(45, 242);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 24);
            this.label7.TabIndex = 27;
            this.label7.Text = "End Time";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Perpetua", 15.75F);
            this.label8.Location = new System.Drawing.Point(62, 308);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 24);
            this.label8.TabIndex = 28;
            this.label8.Text = "Device";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Perpetua", 15.75F);
            this.label9.Location = new System.Drawing.Point(51, 342);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 24);
            this.label9.TabIndex = 29;
            this.label9.Text = "Browser";
            // 
            // txtDevice
            // 
            this.txtDevice.Location = new System.Drawing.Point(155, 312);
            this.txtDevice.Name = "txtDevice";
            this.txtDevice.Size = new System.Drawing.Size(100, 20);
            this.txtDevice.TabIndex = 30;
            // 
            // txtBrowser
            // 
            this.txtBrowser.Location = new System.Drawing.Point(155, 346);
            this.txtBrowser.Name = "txtBrowser";
            this.txtBrowser.Size = new System.Drawing.Size(100, 20);
            this.txtBrowser.TabIndex = 31;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Perpetua", 15.75F);
            this.label10.Location = new System.Drawing.Point(45, 274);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 24);
            this.label10.TabIndex = 32;
            this.label10.Text = "IP Address";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(155, 277);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(100, 20);
            this.txtIP.TabIndex = 33;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Perpetua", 15.75F);
            this.label11.Location = new System.Drawing.Point(62, 77);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 24);
            this.label11.TabIndex = 34;
            this.label11.Text = "User ID";
            // 
            // comboBoxUser
            // 
            this.comboBoxUser.FormattingEnabled = true;
            this.comboBoxUser.Location = new System.Drawing.Point(155, 77);
            this.comboBoxUser.Name = "comboBoxUser";
            this.comboBoxUser.Size = new System.Drawing.Size(147, 21);
            this.comboBoxUser.TabIndex = 35;
            this.comboBoxUser.SelectedValueChanged += new System.EventHandler(this.comboBoxUser_SelectedValueChanged);
            // 
            // dgvUserData
            // 
            this.dgvUserData.AllowUserToAddRows = false;
            this.dgvUserData.AllowUserToDeleteRows = false;
            this.dgvUserData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserData.Location = new System.Drawing.Point(322, 63);
            this.dgvUserData.Name = "dgvUserData";
            this.dgvUserData.ReadOnly = true;
            this.dgvUserData.Size = new System.Drawing.Size(454, 52);
            this.dgvUserData.TabIndex = 36;
            // 
            // SessionAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvUserData);
            this.Controls.Add(this.comboBoxUser);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtBrowser);
            this.Controls.Add(this.txtDevice);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePickerEndTime);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.dgvPagesOfSession);
            this.Controls.Add(this.txtPage);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxPages);
            this.Controls.Add(this.comboBoxWebsites);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAddSession);
            this.Controls.Add(this.btnAddPage);
            this.Controls.Add(this.label1);
            this.Name = "SessionAdd";
            this.Text = "SessionAdd";
            this.Load += new System.EventHandler(this.SessionAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagesOfSession)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddPage;
        private System.Windows.Forms.Button btnAddSession;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox comboBoxWebsites;
        private System.Windows.Forms.ComboBox comboBoxPages;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPage;
        private System.Windows.Forms.DataGridView dgvPagesOfSession;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDevice;
        private System.Windows.Forms.TextBox txtBrowser;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBoxUser;
        private System.Windows.Forms.DataGridView dgvUserData;
    }
}