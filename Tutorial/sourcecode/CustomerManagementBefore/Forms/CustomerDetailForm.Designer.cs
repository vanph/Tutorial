namespace CustomerManagement.Forms
{
    partial class CustomerDetailForm
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtContactName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCountry = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPostalCode = new System.Windows.Forms.TextBox();
            this.countriesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.countriesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.countriesBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustomID = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.countriesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countriesBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countriesBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdSave);
            this.panel1.Controls.Add(this.cmdCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 242);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(403, 44);
            this.panel1.TabIndex = 14;
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(12, 9);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 0;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.OnSave);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(309, 9);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 1;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Company name";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(112, 24);
            this.txtCompanyName.MaxLength = 140;
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(274, 20);
            this.txtCompanyName.TabIndex = 1;
            this.txtCompanyName.TextChanged += new System.EventHandler(this.txtCompanyName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Contact name";
            // 
            // txtContactName
            // 
            this.txtContactName.Location = new System.Drawing.Point(112, 50);
            this.txtContactName.MaxLength = 30;
            this.txtContactName.Name = "txtContactName";
            this.txtContactName.Size = new System.Drawing.Size(274, 20);
            this.txtContactName.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Country";
            // 
            // cboCountry
            // 
            this.cboCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCountry.FormattingEnabled = true;
            this.cboCountry.Location = new System.Drawing.Point(112, 104);
            this.cboCountry.Name = "cboCountry";
            this.cboCountry.Size = new System.Drawing.Size(274, 21);
            this.cboCountry.TabIndex = 11;
            this.cboCountry.SelectedIndexChanged += new System.EventHandler(this.cboCountry_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 79);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "City";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(112, 76);
            this.txtCity.MaxLength = 15;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(274, 20);
            this.txtCity.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 149);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Postal code";
            // 
            // txtPostalCode
            // 
            this.txtPostalCode.Location = new System.Drawing.Point(112, 142);
            this.txtPostalCode.MaxLength = 10;
            this.txtPostalCode.Name = "txtPostalCode";
            this.txtPostalCode.Size = new System.Drawing.Size(144, 20);
            this.txtPostalCode.TabIndex = 13;
            // 
            // countriesBindingSource
            // 
            
            // 
            // countriesBindingSource1
            // 
           
            // 
            // countriesBindingSource2
            // 
            
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Custom ID";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtCustomID
            // 
            this.txtCustomID.Location = new System.Drawing.Point(112, 180);
            this.txtCustomID.MaxLength = 5;
            this.txtCustomID.Name = "txtCustomID";
            this.txtCustomID.Size = new System.Drawing.Size(272, 20);
            this.txtCustomID.TabIndex = 16;
            this.txtCustomID.TextChanged += new System.EventHandler(this.textCustomID_TextChanged);
            // 
            // CustomerDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 286);
            this.Controls.Add(this.txtCustomID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPostalCode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboCountry);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtContactName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCompanyName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CustomerDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Changes";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.countriesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countriesBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countriesBindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtContactName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboCountry;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPostalCode;
        private System.Windows.Forms.BindingSource countriesBindingSource;
        private System.Windows.Forms.BindingSource countriesBindingSource1;
        private System.Windows.Forms.BindingSource countriesBindingSource2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCustomID;
    }
}