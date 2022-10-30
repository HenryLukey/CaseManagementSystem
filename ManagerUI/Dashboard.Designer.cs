namespace ManagerUI
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.listBoxCases = new System.Windows.Forms.ListBox();
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelCaseManager = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.comboBoxCaseManager = new System.Windows.Forms.ComboBox();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.labelOrderBy = new System.Windows.Forms.Label();
            this.comboBoxOrderBy = new System.Windows.Forms.ComboBox();
            this.labelSearch = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonNewCase = new System.Windows.Forms.Button();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.panelSideMenu.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.panelSideMenu.Controls.Add(this.listBoxCases);
            this.panelSideMenu.Controls.Add(this.panelTop);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(280, 592);
            this.panelSideMenu.TabIndex = 0;
            // 
            // listBoxCases
            // 
            this.listBoxCases.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.listBoxCases.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxCases.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBoxCases.ForeColor = System.Drawing.Color.White;
            this.listBoxCases.FormattingEnabled = true;
            this.listBoxCases.ItemHeight = 16;
            this.listBoxCases.Location = new System.Drawing.Point(0, 182);
            this.listBoxCases.Name = "listBoxCases";
            this.listBoxCases.Size = new System.Drawing.Size(280, 400);
            this.listBoxCases.TabIndex = 1;
            this.listBoxCases.SelectedIndexChanged += new System.EventHandler(this.listBoxCases_SelectedIndexChanged);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panelTop.Controls.Add(this.labelCaseManager);
            this.panelTop.Controls.Add(this.labelStatus);
            this.panelTop.Controls.Add(this.comboBoxCaseManager);
            this.panelTop.Controls.Add(this.comboBoxStatus);
            this.panelTop.Controls.Add(this.labelOrderBy);
            this.panelTop.Controls.Add(this.comboBoxOrderBy);
            this.panelTop.Controls.Add(this.labelSearch);
            this.panelTop.Controls.Add(this.buttonSearch);
            this.panelTop.Controls.Add(this.textBoxSearch);
            this.panelTop.Controls.Add(this.buttonNewCase);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(280, 182);
            this.panelTop.TabIndex = 0;
            // 
            // labelCaseManager
            // 
            this.labelCaseManager.AutoSize = true;
            this.labelCaseManager.ForeColor = System.Drawing.Color.White;
            this.labelCaseManager.Location = new System.Drawing.Point(0, 95);
            this.labelCaseManager.Name = "labelCaseManager";
            this.labelCaseManager.Size = new System.Drawing.Size(104, 17);
            this.labelCaseManager.TabIndex = 13;
            this.labelCaseManager.Text = "Case manager:";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.ForeColor = System.Drawing.Color.White;
            this.labelStatus.Location = new System.Drawing.Point(52, 125);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(52, 17);
            this.labelStatus.TabIndex = 12;
            this.labelStatus.Text = "Status:";
            // 
            // comboBoxCaseManager
            // 
            this.comboBoxCaseManager.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCaseManager.FormattingEnabled = true;
            this.comboBoxCaseManager.Items.AddRange(new object[] {
            ""});
            this.comboBoxCaseManager.Location = new System.Drawing.Point(104, 92);
            this.comboBoxCaseManager.Name = "comboBoxCaseManager";
            this.comboBoxCaseManager.Size = new System.Drawing.Size(173, 24);
            this.comboBoxCaseManager.TabIndex = 11;
            this.comboBoxCaseManager.SelectedIndexChanged += new System.EventHandler(this.comboBoxCaseManager_SelectedIndexChanged);
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Items.AddRange(new object[] {
            "All",
            "Caution",
            "No proceedings",
            "Summons",
            "Further action"});
            this.comboBoxStatus.Location = new System.Drawing.Point(104, 122);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(173, 24);
            this.comboBoxStatus.TabIndex = 10;
            this.comboBoxStatus.SelectedIndexChanged += new System.EventHandler(this.comboBoxStatus_SelectedIndexChanged);
            // 
            // labelOrderBy
            // 
            this.labelOrderBy.AutoSize = true;
            this.labelOrderBy.ForeColor = System.Drawing.Color.White;
            this.labelOrderBy.Location = new System.Drawing.Point(36, 155);
            this.labelOrderBy.Name = "labelOrderBy";
            this.labelOrderBy.Size = new System.Drawing.Size(68, 17);
            this.labelOrderBy.TabIndex = 9;
            this.labelOrderBy.Text = "Order by:";
            // 
            // comboBoxOrderBy
            // 
            this.comboBoxOrderBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOrderBy.FormattingEnabled = true;
            this.comboBoxOrderBy.Items.AddRange(new object[] {
            "None",
            "Alphabetical",
            "Review / hearing date",
            "Further action date"});
            this.comboBoxOrderBy.Location = new System.Drawing.Point(104, 152);
            this.comboBoxOrderBy.Name = "comboBoxOrderBy";
            this.comboBoxOrderBy.Size = new System.Drawing.Size(173, 24);
            this.comboBoxOrderBy.TabIndex = 8;
            this.comboBoxOrderBy.SelectedIndexChanged += new System.EventHandler(this.comboBoxOrderBy_SelectedIndexChanged);
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelSearch.ForeColor = System.Drawing.Color.White;
            this.labelSearch.Location = new System.Drawing.Point(0, 30);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(108, 17);
            this.labelSearch.TabIndex = 7;
            this.labelSearch.Text = "Search for case";
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.buttonSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSearch.BackgroundImage")));
            this.buttonSearch.FlatAppearance.BorderSize = 0;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.ForeColor = System.Drawing.Color.White;
            this.buttonSearch.Location = new System.Drawing.Point(254, 50);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(23, 23);
            this.buttonSearch.TabIndex = 6;
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.textBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSearch.ForeColor = System.Drawing.Color.White;
            this.textBoxSearch.Location = new System.Drawing.Point(3, 50);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(249, 23);
            this.textBoxSearch.TabIndex = 5;
            // 
            // buttonNewCase
            // 
            this.buttonNewCase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.buttonNewCase.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonNewCase.FlatAppearance.BorderSize = 0;
            this.buttonNewCase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewCase.ForeColor = System.Drawing.Color.White;
            this.buttonNewCase.Location = new System.Drawing.Point(0, 0);
            this.buttonNewCase.Name = "buttonNewCase";
            this.buttonNewCase.Size = new System.Drawing.Size(280, 30);
            this.buttonNewCase.TabIndex = 1;
            this.buttonNewCase.Text = "New case";
            this.buttonNewCase.UseVisualStyleBackColor = false;
            this.buttonNewCase.Click += new System.EventHandler(this.buttonNewCase_Click);
            // 
            // panelChildForm
            // 
            this.panelChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChildForm.Location = new System.Drawing.Point(280, 0);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(735, 592);
            this.panelChildForm.TabIndex = 1;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(1015, 592);
            this.Controls.Add(this.panelChildForm);
            this.Controls.Add(this.panelSideMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.panelSideMenu.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.ListBox listBoxCases;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button buttonNewCase;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Panel panelChildForm;
        private System.Windows.Forms.Label labelOrderBy;
        private System.Windows.Forms.ComboBox comboBoxOrderBy;
        private System.Windows.Forms.Label labelCaseManager;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ComboBox comboBoxCaseManager;
        private System.Windows.Forms.ComboBox comboBoxStatus;
    }
}