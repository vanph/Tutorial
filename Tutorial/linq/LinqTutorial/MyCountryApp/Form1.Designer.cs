﻿namespace MyCountryApp
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearchCity = new System.Windows.Forms.Button();
            this.txtCityFilter = new System.Windows.Forms.TextBox();
            this.grdCity = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSearchDistrict = new System.Windows.Forms.Button();
            this.grdDistrict = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grdSummary = new System.Windows.Forms.DataGridView();
            this.btnSearchSumary = new System.Windows.Forms.Button();
            this.txtSummaryFilter = new System.Windows.Forms.TextBox();
            this.btnClickMe = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCity)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDistrict)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSummary)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearchCity);
            this.groupBox1.Controls.Add(this.txtCityFilter);
            this.groupBox1.Controls.Add(this.grdCity);
            this.groupBox1.Location = new System.Drawing.Point(37, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 519);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "City";
            // 
            // btnSearchCity
            // 
            this.btnSearchCity.Location = new System.Drawing.Point(277, 47);
            this.btnSearchCity.Name = "btnSearchCity";
            this.btnSearchCity.Size = new System.Drawing.Size(75, 23);
            this.btnSearchCity.TabIndex = 2;
            this.btnSearchCity.Text = "Search";
            this.btnSearchCity.UseVisualStyleBackColor = true;
            this.btnSearchCity.Click += new System.EventHandler(this.btnSearchCity_Click);
            // 
            // txtCityFilter
            // 
            this.txtCityFilter.Location = new System.Drawing.Point(26, 47);
            this.txtCityFilter.Name = "txtCityFilter";
            this.txtCityFilter.Size = new System.Drawing.Size(243, 20);
            this.txtCityFilter.TabIndex = 1;
            // 
            // grdCity
            // 
            this.grdCity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCity.Location = new System.Drawing.Point(26, 98);
            this.grdCity.Name = "grdCity";
            this.grdCity.Size = new System.Drawing.Size(314, 386);
            this.grdCity.TabIndex = 0;
            this.grdCity.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCity_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSearchDistrict);
            this.groupBox2.Controls.Add(this.grdDistrict);
            this.groupBox2.Location = new System.Drawing.Point(453, 57);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(328, 519);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "District";
            // 
            // btnSearchDistrict
            // 
            this.btnSearchDistrict.Location = new System.Drawing.Point(232, 50);
            this.btnSearchDistrict.Name = "btnSearchDistrict";
            this.btnSearchDistrict.Size = new System.Drawing.Size(75, 23);
            this.btnSearchDistrict.TabIndex = 2;
            this.btnSearchDistrict.Text = "Search";
            this.btnSearchDistrict.UseVisualStyleBackColor = true;
            this.btnSearchDistrict.Click += new System.EventHandler(this.btnSearchDistrict_Click);
            // 
            // grdDistrict
            // 
            this.grdDistrict.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDistrict.Location = new System.Drawing.Point(39, 98);
            this.grdDistrict.Name = "grdDistrict";
            this.grdDistrict.Size = new System.Drawing.Size(268, 386);
            this.grdDistrict.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(278, 479);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Show City Max";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.grdSummary);
            this.groupBox3.Controls.Add(this.btnSearchSumary);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.txtSummaryFilter);
            this.groupBox3.Location = new System.Drawing.Point(835, 57);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(432, 519);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Summary";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 479);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "City Max:";
            // 
            // grdSummary
            // 
            this.grdSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSummary.Location = new System.Drawing.Point(27, 98);
            this.grdSummary.Name = "grdSummary";
            this.grdSummary.Size = new System.Drawing.Size(367, 327);
            this.grdSummary.TabIndex = 3;
            // 
            // btnSearchSumary
            // 
            this.btnSearchSumary.Location = new System.Drawing.Point(278, 50);
            this.btnSearchSumary.Name = "btnSearchSumary";
            this.btnSearchSumary.Size = new System.Drawing.Size(75, 23);
            this.btnSearchSumary.TabIndex = 2;
            this.btnSearchSumary.Text = "Search";
            this.btnSearchSumary.UseVisualStyleBackColor = true;
            this.btnSearchSumary.Click += new System.EventHandler(this.OnButtonSearchSumaryClicked);
            // 
            // txtSummaryFilter
            // 
            this.txtSummaryFilter.Location = new System.Drawing.Point(27, 50);
            this.txtSummaryFilter.Name = "txtSummaryFilter";
            this.txtSummaryFilter.Size = new System.Drawing.Size(243, 20);
            this.txtSummaryFilter.TabIndex = 1;
            // 
            // btnClickMe
            // 
            this.btnClickMe.Location = new System.Drawing.Point(183, 13);
            this.btnClickMe.Name = "btnClickMe";
            this.btnClickMe.Size = new System.Drawing.Size(176, 23);
            this.btnClickMe.TabIndex = 4;
            this.btnClickMe.Text = "click me!";
            this.btnClickMe.UseVisualStyleBackColor = true;
            this.btnClickMe.Click += new System.EventHandler(this.OnClickMe_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(410, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(162, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.OnClickMe_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(622, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.Click += new System.EventHandler(this.OnClickMe_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 668);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnClickMe);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCity)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDistrict)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSummary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearchCity;
        private System.Windows.Forms.TextBox txtCityFilter;
        private System.Windows.Forms.DataGridView grdCity;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView grdSummary;
        private System.Windows.Forms.Button btnSearchSumary;
        private System.Windows.Forms.TextBox txtSummaryFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearchDistrict;
        private System.Windows.Forms.DataGridView grdDistrict;
        private System.Windows.Forms.Button btnClickMe;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
    }
}

