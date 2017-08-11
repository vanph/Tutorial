namespace Practice.WinFroms.GetEmployeeFromDBI
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
            this.gridViewEmployee = new System.Windows.Forms.DataGridView();
            this.btnShowEmployee = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEmployee)).BeginInit();
            this.SuspendLayout();
            // 
            // gridViewEmployee
            // 
            this.gridViewEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridViewEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewEmployee.Location = new System.Drawing.Point(22, 99);
            this.gridViewEmployee.Name = "gridViewEmployee";
            this.gridViewEmployee.Size = new System.Drawing.Size(404, 204);
            this.gridViewEmployee.TabIndex = 0;
            this.gridViewEmployee.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridViewEmployee_CellContentClick);
            // 
            // btnShowEmployee
            // 
            this.btnShowEmployee.Location = new System.Drawing.Point(22, 61);
            this.btnShowEmployee.Name = "btnShowEmployee";
            this.btnShowEmployee.Size = new System.Drawing.Size(75, 23);
            this.btnShowEmployee.TabIndex = 1;
            this.btnShowEmployee.Text = "View";
            this.btnShowEmployee.UseVisualStyleBackColor = true;
            this.btnShowEmployee.Click += new System.EventHandler(this.btnShowEmployee_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 326);
            this.Controls.Add(this.btnShowEmployee);
            this.Controls.Add(this.gridViewEmployee);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEmployee)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridViewEmployee;
        private System.Windows.Forms.Button btnShowEmployee;
    }
}