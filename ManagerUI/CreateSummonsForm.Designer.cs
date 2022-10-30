namespace ManagerUI
{
    partial class CreateSummonsForm
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
            this.textBoxFolderURL = new System.Windows.Forms.TextBox();
            this.labelFolderURL = new System.Windows.Forms.Label();
            this.comboBoxOffenders = new System.Windows.Forms.ComboBox();
            this.labelOffender = new System.Windows.Forms.Label();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.labelSuccessful = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxFolderURL
            // 
            this.textBoxFolderURL.Location = new System.Drawing.Point(12, 37);
            this.textBoxFolderURL.Name = "textBoxFolderURL";
            this.textBoxFolderURL.Size = new System.Drawing.Size(335, 20);
            this.textBoxFolderURL.TabIndex = 30;
            // 
            // labelFolderURL
            // 
            this.labelFolderURL.AutoSize = true;
            this.labelFolderURL.ForeColor = System.Drawing.Color.White;
            this.labelFolderURL.Location = new System.Drawing.Point(13, 18);
            this.labelFolderURL.Name = "labelFolderURL";
            this.labelFolderURL.Size = new System.Drawing.Size(61, 13);
            this.labelFolderURL.TabIndex = 31;
            this.labelFolderURL.Text = "Folder URL";
            // 
            // comboBoxOffenders
            // 
            this.comboBoxOffenders.FormattingEnabled = true;
            this.comboBoxOffenders.Location = new System.Drawing.Point(12, 118);
            this.comboBoxOffenders.Name = "comboBoxOffenders";
            this.comboBoxOffenders.Size = new System.Drawing.Size(153, 21);
            this.comboBoxOffenders.TabIndex = 32;
            // 
            // labelOffender
            // 
            this.labelOffender.AutoSize = true;
            this.labelOffender.ForeColor = System.Drawing.Color.White;
            this.labelOffender.Location = new System.Drawing.Point(13, 102);
            this.labelOffender.Name = "labelOffender";
            this.labelOffender.Size = new System.Drawing.Size(48, 13);
            this.labelOffender.TabIndex = 33;
            this.labelOffender.Text = "Offender";
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(211, 102);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(106, 50);
            this.buttonCreate.TabIndex = 34;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // labelSuccessful
            // 
            this.labelSuccessful.AutoSize = true;
            this.labelSuccessful.ForeColor = System.Drawing.Color.LimeGreen;
            this.labelSuccessful.Location = new System.Drawing.Point(120, 79);
            this.labelSuccessful.Name = "labelSuccessful";
            this.labelSuccessful.Size = new System.Drawing.Size(0, 13);
            this.labelSuccessful.TabIndex = 35;
            // 
            // CreateSummonsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(373, 191);
            this.Controls.Add(this.labelSuccessful);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.labelOffender);
            this.Controls.Add(this.comboBoxOffenders);
            this.Controls.Add(this.labelFolderURL);
            this.Controls.Add(this.textBoxFolderURL);
            this.Name = "CreateSummonsForm";
            this.Text = "CreateSummons";
            this.Load += new System.EventHandler(this.CreateSummons_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFolderURL;
        private System.Windows.Forms.Label labelFolderURL;
        private System.Windows.Forms.ComboBox comboBoxOffenders;
        private System.Windows.Forms.Label labelOffender;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Label labelSuccessful;
    }
}