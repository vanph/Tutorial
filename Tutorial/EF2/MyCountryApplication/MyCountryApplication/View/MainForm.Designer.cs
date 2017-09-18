namespace MyCountryApplication.View
{
    partial class MainForm
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
            this.pannelSearch = new System.Windows.Forms.Panel();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cbbCitySearch = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grvDistrict = new System.Windows.Forms.DataGridView();
            this.grvColumnDistrictCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grvColumnDistrictName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grvColumnCityName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTool = new System.Windows.Forms.Panel();
            this.lblTotalPage = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIndexPage = new System.Windows.Forms.TextBox();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.lblDistrictName = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblCityName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDistrictCode = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.panelExport = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNoticeLogin = new System.Windows.Forms.Label();
            this.cMSLogin = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.signOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loginMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cityToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pannelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvDistrict)).BeginInit();
            this.panelTool.SuspendLayout();
            this.panelInfo.SuspendLayout();
            this.panelExport.SuspendLayout();
            this.panel1.SuspendLayout();
            this.cMSLogin.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pannelSearch
            // 
            this.pannelSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pannelSearch.Controls.Add(this.btnClearSearch);
            this.pannelSearch.Controls.Add(this.btnSearch);
            this.pannelSearch.Controls.Add(this.cbbCitySearch);
            this.pannelSearch.Controls.Add(this.txtSearch);
            this.pannelSearch.Controls.Add(this.label3);
            this.pannelSearch.Controls.Add(this.label2);
            this.pannelSearch.Location = new System.Drawing.Point(1, 76);
            this.pannelSearch.Name = "pannelSearch";
            this.pannelSearch.Size = new System.Drawing.Size(884, 64);
            this.pannelSearch.TabIndex = 1;
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.Location = new System.Drawing.Point(641, 25);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(126, 20);
            this.btnClearSearch.TabIndex = 5;
            this.btnClearSearch.Text = "Clear Search";
            this.btnClearSearch.UseVisualStyleBackColor = true;
            this.btnClearSearch.Click += new System.EventHandler(this.BtnClearSearch_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(487, 25);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(126, 20);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // cbbCitySearch
            // 
            this.cbbCitySearch.FormattingEnabled = true;
            this.cbbCitySearch.Location = new System.Drawing.Point(326, 26);
            this.cbbCitySearch.Name = "cbbCitySearch";
            this.cbbCitySearch.Size = new System.Drawing.Size(126, 21);
            this.cbbCitySearch.TabIndex = 3;
            this.cbbCitySearch.Text = "All Cities";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(86, 26);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(126, 20);
            this.txtSearch.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(269, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "City:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Keyword:";
            // 
            // grvDistrict
            // 
            this.grvDistrict.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grvDistrict.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvDistrict.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grvColumnDistrictCode,
            this.grvColumnDistrictName,
            this.grvColumnCityName});
            this.grvDistrict.Location = new System.Drawing.Point(1, 185);
            this.grvDistrict.MultiSelect = false;
            this.grvDistrict.Name = "grvDistrict";
            this.grvDistrict.ReadOnly = true;
            this.grvDistrict.Size = new System.Drawing.Size(883, 254);
            this.grvDistrict.TabIndex = 2;
            this.grvDistrict.SelectionChanged += new System.EventHandler(this.GrvDistrict_SelectionChanged);
            // 
            // grvColumnDistrictCode
            // 
            this.grvColumnDistrictCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.grvColumnDistrictCode.DataPropertyName = "DistrictCode";
            this.grvColumnDistrictCode.HeaderText = "District Code";
            this.grvColumnDistrictCode.MinimumWidth = 100;
            this.grvColumnDistrictCode.Name = "grvColumnDistrictCode";
            this.grvColumnDistrictCode.ReadOnly = true;
            // 
            // grvColumnDistrictName
            // 
            this.grvColumnDistrictName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.grvColumnDistrictName.DataPropertyName = "DistrictName";
            this.grvColumnDistrictName.HeaderText = "District Name";
            this.grvColumnDistrictName.Name = "grvColumnDistrictName";
            this.grvColumnDistrictName.ReadOnly = true;
            // 
            // grvColumnCityName
            // 
            this.grvColumnCityName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.grvColumnCityName.DataPropertyName = "CityName";
            this.grvColumnCityName.HeaderText = "City Name";
            this.grvColumnCityName.MinimumWidth = 100;
            this.grvColumnCityName.Name = "grvColumnCityName";
            this.grvColumnCityName.ReadOnly = true;
            // 
            // panelTool
            // 
            this.panelTool.Controls.Add(this.lblTotalPage);
            this.panelTool.Controls.Add(this.label6);
            this.panelTool.Controls.Add(this.txtIndexPage);
            this.panelTool.Controls.Add(this.btnPrev);
            this.panelTool.Controls.Add(this.btnNext);
            this.panelTool.Controls.Add(this.btnDelete);
            this.panelTool.Controls.Add(this.btnEdit);
            this.panelTool.Controls.Add(this.btnAdd);
            this.panelTool.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTool.Location = new System.Drawing.Point(0, 442);
            this.panelTool.Name = "panelTool";
            this.panelTool.Size = new System.Drawing.Size(884, 69);
            this.panelTool.TabIndex = 4;
            // 
            // lblTotalPage
            // 
            this.lblTotalPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalPage.AutoSize = true;
            this.lblTotalPage.Location = new System.Drawing.Point(733, 32);
            this.lblTotalPage.Name = "lblTotalPage";
            this.lblTotalPage.Size = new System.Drawing.Size(56, 13);
            this.lblTotalPage.TabIndex = 11;
            this.lblTotalPage.Text = "TotalPage";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(722, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "of";
            // 
            // txtIndexPage
            // 
            this.txtIndexPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIndexPage.Location = new System.Drawing.Point(671, 29);
            this.txtIndexPage.Name = "txtIndexPage";
            this.txtIndexPage.Size = new System.Drawing.Size(45, 20);
            this.txtIndexPage.TabIndex = 10;
            this.txtIndexPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIndexPage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtIndexPage_KeyPress);
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrev.Location = new System.Drawing.Point(580, 29);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(75, 20);
            this.btnPrev.TabIndex = 9;
            this.btnPrev.Text = "Prev";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.BtnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(786, 29);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 20);
            this.btnNext.TabIndex = 8;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(230, 28);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(137, 28);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(40, 28);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // panelInfo
            // 
            this.panelInfo.Controls.Add(this.lblDistrictName);
            this.panelInfo.Controls.Add(this.label9);
            this.panelInfo.Controls.Add(this.lblCityName);
            this.panelInfo.Controls.Add(this.label7);
            this.panelInfo.Controls.Add(this.lblDistrictCode);
            this.panelInfo.Controls.Add(this.label4);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelInfo.Location = new System.Drawing.Point(0, 511);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(884, 100);
            this.panelInfo.TabIndex = 5;
            // 
            // lblDistrictName
            // 
            this.lblDistrictName.AutoSize = true;
            this.lblDistrictName.Location = new System.Drawing.Point(111, 42);
            this.lblDistrictName.Name = "lblDistrictName";
            this.lblDistrictName.Size = new System.Drawing.Size(77, 13);
            this.lblDistrictName.TabIndex = 9;
            this.lblDistrictName.Text = "lblDistrictName";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(37, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "District Name:";
            // 
            // lblCityName
            // 
            this.lblCityName.AutoSize = true;
            this.lblCityName.Location = new System.Drawing.Point(111, 69);
            this.lblCityName.Name = "lblCityName";
            this.lblCityName.Size = new System.Drawing.Size(62, 13);
            this.lblCityName.TabIndex = 7;
            this.lblCityName.Text = "lblCityName";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "City Name:";
            // 
            // lblDistrictCode
            // 
            this.lblDistrictCode.AutoSize = true;
            this.lblDistrictCode.Location = new System.Drawing.Point(111, 10);
            this.lblDistrictCode.Name = "lblDistrictCode";
            this.lblDistrictCode.Size = new System.Drawing.Size(74, 13);
            this.lblDistrictCode.TabIndex = 6;
            this.lblDistrictCode.Text = "lblDistrictCode";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "District Code:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "District List:";
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(785, 9);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // panelExport
            // 
            this.panelExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelExport.Controls.Add(this.btnExport);
            this.panelExport.Controls.Add(this.label5);
            this.panelExport.Location = new System.Drawing.Point(1, 140);
            this.panelExport.Name = "panelExport";
            this.panelExport.Size = new System.Drawing.Size(883, 43);
            this.panelExport.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(884, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "My Country Application";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblNoticeLogin);
            this.panel1.Controls.Add(this.menuStrip2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(884, 27);
            this.panel1.TabIndex = 0;
            // 
            // lblNoticeLogin
            // 
            this.lblNoticeLogin.AutoSize = true;
            this.lblNoticeLogin.ContextMenuStrip = this.cMSLogin;
            this.lblNoticeLogin.Location = new System.Drawing.Point(817, 6);
            this.lblNoticeLogin.Name = "lblNoticeLogin";
            this.lblNoticeLogin.Size = new System.Drawing.Size(35, 13);
            this.lblNoticeLogin.TabIndex = 2;
            this.lblNoticeLogin.Text = "label8";
            this.lblNoticeLogin.Visible = false;
            // 
            // cMSLogin
            // 
            this.cMSLogin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.signOutToolStripMenuItem});
            this.cMSLogin.Name = "cMSLogin";
            this.cMSLogin.Size = new System.Drawing.Size(119, 26);
            // 
            // signOutToolStripMenuItem
            // 
            this.signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            this.signOutToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.signOutToolStripMenuItem.Text = "Sign out";
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.cityToolStripMenuItem1,
            this.helpToolStripMenuItem1});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(884, 24);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginMenu,
            this.exitMenu});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem1.Text = "File";
            // 
            // loginMenu
            // 
            this.loginMenu.Name = "loginMenu";
            this.loginMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.L)));
            this.loginMenu.Size = new System.Drawing.Size(140, 22);
            this.loginMenu.Text = "Login";
            this.loginMenu.Click += new System.EventHandler(this.LoginMenu_Click);
            // 
            // exitMenu
            // 
            this.exitMenu.Name = "exitMenu";
            this.exitMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitMenu.Size = new System.Drawing.Size(140, 22);
            this.exitMenu.Text = "Exit";
            this.exitMenu.Click += new System.EventHandler(this.ExitMenu_Click);
            // 
            // cityToolStripMenuItem1
            // 
            this.cityToolStripMenuItem1.Name = "cityToolStripMenuItem1";
            this.cityToolStripMenuItem1.Size = new System.Drawing.Size(40, 20);
            this.cityToolStripMenuItem1.Text = "City";
            this.cityToolStripMenuItem1.Click += new System.EventHandler(this.CityToolStripMenuItem1_Click);
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.AboutToolStripMenuItem1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 611);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelExport);
            this.Controls.Add(this.panelTool);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.pannelSearch);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grvDistrict);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My Country Application";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pannelSearch.ResumeLayout(false);
            this.pannelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvDistrict)).EndInit();
            this.panelTool.ResumeLayout(false);
            this.panelTool.PerformLayout();
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.panelExport.ResumeLayout(false);
            this.panelExport.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.cMSLogin.ResumeLayout(false);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pannelSearch;
        private System.Windows.Forms.DataGridView grvDistrict;
        private System.Windows.Forms.Panel panelTool;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cbbCitySearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDistrictName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblCityName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDistrictCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn grvColumnDistrictCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn grvColumnDistrictName;
        private System.Windows.Forms.DataGridViewTextBoxColumn grvColumnCityName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox txtIndexPage;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Panel panelExport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loginMenu;
        private System.Windows.Forms.ToolStripMenuItem exitMenu;
        private System.Windows.Forms.ToolStripMenuItem cityToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.Label lblTotalPage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblNoticeLogin;
        private System.Windows.Forms.ContextMenuStrip cMSLogin;
        private System.Windows.Forms.ToolStripMenuItem signOutToolStripMenuItem;
    }
}

