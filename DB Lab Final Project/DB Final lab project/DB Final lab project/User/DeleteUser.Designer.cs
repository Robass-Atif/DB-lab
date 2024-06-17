namespace DB_Final_lab_project.User
{
    partial class DeleteUser
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button2 = new System.Windows.Forms.Button();
            this.DelUserGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.DeleteUsers = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DelUserGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(68, 34);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 21;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // DelUserGrid
            // 
            this.DelUserGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DelUserGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DeleteUsers});
            this.DelUserGrid.Location = new System.Drawing.Point(82, 90);
            this.DelUserGrid.Name = "DelUserGrid";
            this.DelUserGrid.Size = new System.Drawing.Size(811, 408);
            this.DelUserGrid.TabIndex = 22;
            this.DelUserGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DelUserGrid_CellContentClick_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(397, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 46);
            this.label1.TabIndex = 23;
            this.label1.Text = "Delete User";
            // 
            // DeleteUsers
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Red;
            this.DeleteUsers.DefaultCellStyle = dataGridViewCellStyle1;
            this.DeleteUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteUsers.HeaderText = "DeleteUsers";
            this.DeleteUsers.Name = "DeleteUsers";
            this.DeleteUsers.Text = "DELETE";
            // 
            // DeleteUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 523);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DelUserGrid);
            this.Controls.Add(this.button2);
            this.Name = "DeleteUser";
            this.Text = "DeleteUser";
            ((System.ComponentModel.ISupportInitialize)(this.DelUserGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView DelUserGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteUsers;
    }
}