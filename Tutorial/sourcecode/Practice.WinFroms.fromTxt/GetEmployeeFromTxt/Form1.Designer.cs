namespace Practice.WinFroms.fromTxt
{
    partial class Form1
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
            this.dataGridViewEmployee = new System.Windows.Forms.DataGridView();
            this.ColumnFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAddressEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnShowEmployee = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployee)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewEmployee
            // 
            this.dataGridViewEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmployee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnFirstName,
            this.ColumnLastName,
            this.ColumnAddressEmail});
            this.dataGridViewEmployee.Location = new System.Drawing.Point(22, 86);
            this.dataGridViewEmployee.Name = "dataGridViewEmployee";
            this.dataGridViewEmployee.Size = new System.Drawing.Size(240, 150);
            this.dataGridViewEmployee.TabIndex = 0;
            this.dataGridViewEmployee.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEmployee_CellContentClick);
            // 
            // ColumnFirstName
            // 
            this.ColumnFirstName.HeaderText = "First Name";
            this.ColumnFirstName.Name = "ColumnFirstName";
            // 
            // ColumnLastName
            // 
            this.ColumnLastName.HeaderText = "Last Name";
            this.ColumnLastName.Name = "ColumnLastName";
            // 
            // ColumnAddressEmail
            // 
            this.ColumnAddressEmail.HeaderText = "Address Email";
            this.ColumnAddressEmail.Name = "ColumnAddressEmail";
            // 
            // btnShowEmployee
            // 
            this.btnShowEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowEmployee.Location = new System.Drawing.Point(187, 42);
            this.btnShowEmployee.Name = "btnShowEmployee";
            this.btnShowEmployee.Size = new System.Drawing.Size(75, 23);
            this.btnShowEmployee.TabIndex = 1;
            this.btnShowEmployee.Text = "Show";
            this.btnShowEmployee.UseVisualStyleBackColor = true;
            this.btnShowEmployee.Click += new System.EventHandler(this.btnShowEmployee_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnShowEmployee);
            this.Controls.Add(this.dataGridViewEmployee);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployee)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewEmployee;
        private System.Windows.Forms.Button btnShowEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAddressEmail;
    }
}