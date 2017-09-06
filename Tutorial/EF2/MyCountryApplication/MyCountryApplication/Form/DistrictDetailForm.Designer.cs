namespace MyCountryApplication
{
    partial class DistrictDetailForm
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
            this.txtDistrictCode = new System.Windows.Forms.TextBox();
            this.txtCityCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCityName = new System.Windows.Forms.TextBox();
            this.sx = new System.Windows.Forms.Label();
            this.txtDistrictName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.txtDistrictType = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCityType = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblNoticeDistrictCode = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "District Code:";
            // 
            // txtDistrictCode
            // 
            this.txtDistrictCode.Location = new System.Drawing.Point(164, 43);
            this.txtDistrictCode.Name = "txtDistrictCode";
            this.txtDistrictCode.Size = new System.Drawing.Size(342, 20);
            this.txtDistrictCode.TabIndex = 1;
            this.txtDistrictCode.Visible = false;
            // 
            // txtCityCode
            // 
            this.txtCityCode.Location = new System.Drawing.Point(164, 218);
            this.txtCityCode.Name = "txtCityCode";
            this.txtCityCode.Size = new System.Drawing.Size(342, 20);
            this.txtCityCode.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "City Code:";
            // 
            // txtCityName
            // 
            this.txtCityName.Location = new System.Drawing.Point(164, 148);
            this.txtCityName.Name = "txtCityName";
            this.txtCityName.Size = new System.Drawing.Size(342, 20);
            this.txtCityName.TabIndex = 5;
            // 
            // sx
            // 
            this.sx.AutoSize = true;
            this.sx.Location = new System.Drawing.Point(94, 151);
            this.sx.Name = "sx";
            this.sx.Size = new System.Drawing.Size(58, 13);
            this.sx.TabIndex = 4;
            this.sx.Text = "City Name:";
            // 
            // txtDistrictName
            // 
            this.txtDistrictName.Location = new System.Drawing.Point(164, 75);
            this.txtDistrictName.Name = "txtDistrictName";
            this.txtDistrictName.Size = new System.Drawing.Size(342, 20);
            this.txtDistrictName.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(94, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Distrct Name:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(164, 274);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(431, 274);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 9;
            this.btnCancle.Text = "Cancle";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // txtDistrictType
            // 
            this.txtDistrictType.Location = new System.Drawing.Point(164, 113);
            this.txtDistrictType.Name = "txtDistrictType";
            this.txtDistrictType.Size = new System.Drawing.Size(342, 20);
            this.txtDistrictType.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(94, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Distrct Type:";
            // 
            // txtCityType
            // 
            this.txtCityType.Location = new System.Drawing.Point(163, 182);
            this.txtCityType.Name = "txtCityType";
            this.txtCityType.Size = new System.Drawing.Size(342, 20);
            this.txtCityType.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(93, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "City Type:";
            // 
            // lblNoticeDistrictCode
            // 
            this.lblNoticeDistrictCode.AutoSize = true;
            this.lblNoticeDistrictCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoticeDistrictCode.ForeColor = System.Drawing.Color.Red;
            this.lblNoticeDistrictCode.Location = new System.Drawing.Point(511, 46);
            this.lblNoticeDistrictCode.Name = "lblNoticeDistrictCode";
            this.lblNoticeDistrictCode.Size = new System.Drawing.Size(126, 13);
            this.lblNoticeDistrictCode.TabIndex = 14;
            this.lblNoticeDistrictCode.Text = "District Code has existed!";
            // 
            // DistrictDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 354);
            this.Controls.Add(this.lblNoticeDistrictCode);
            this.Controls.Add(this.txtCityType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDistrictType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDistrictName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCityName);
            this.Controls.Add(this.sx);
            this.Controls.Add(this.txtCityCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDistrictCode);
            this.Controls.Add(this.label1);
            this.Name = "DistrictDetailForm";
            this.Text = "DistrictDetailForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DistrictDetailForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDistrictCode;
        private System.Windows.Forms.TextBox txtCityCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCityName;
        private System.Windows.Forms.Label sx;
        private System.Windows.Forms.TextBox txtDistrictName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.TextBox txtDistrictType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCityType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblNoticeDistrictCode;
    }
}