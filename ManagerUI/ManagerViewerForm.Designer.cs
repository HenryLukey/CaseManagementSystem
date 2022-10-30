namespace ManagerUI
{
    partial class ManagerViewerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagerViewerForm));
            this.headerLabel = new System.Windows.Forms.Label();
            this.FirstNameBox = new System.Windows.Forms.TextBox();
            this.FirstNameLabel = new System.Windows.Forms.Label();
            this.LastNameLabel = new System.Windows.Forms.Label();
            this.LastNameBox = new System.Windows.Forms.TextBox();
            this.NumberCodeLabel = new System.Windows.Forms.Label();
            this.NumberCodeBox = new System.Windows.Forms.TextBox();
            this.MobileBox = new System.Windows.Forms.TextBox();
            this.MobileLabel = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.FirstNameBoxReadOnly = new System.Windows.Forms.TextBox();
            this.LastNameBoxReadOnly = new System.Windows.Forms.TextBox();
            this.NumberCodeBoxReadOnly = new System.Windows.Forms.TextBox();
            this.MobileBoxReadOnly = new System.Windows.Forms.TextBox();
            this.FirstNameLabel2 = new System.Windows.Forms.Label();
            this.LastNameLabel2 = new System.Windows.Forms.Label();
            this.NumberCodeLabel2 = new System.Windows.Forms.Label();
            this.MobileLabel2 = new System.Windows.Forms.Label();
            this.IDBox = new System.Windows.Forms.TextBox();
            this.IDLabel = new System.Windows.Forms.Label();
            this.GetButton = new System.Windows.Forms.Button();
            this.FirstNameBox2 = new System.Windows.Forms.TextBox();
            this.LastNameBox2 = new System.Windows.Forms.TextBox();
            this.NumberCodeBox2 = new System.Windows.Forms.TextBox();
            this.MobileBox2 = new System.Windows.Forms.TextBox();
            this.IDBox2 = new System.Windows.Forms.TextBox();
            this.IDLabel2 = new System.Windows.Forms.Label();
            this.FirstNameLabel3 = new System.Windows.Forms.Label();
            this.LastNameLabel3 = new System.Windows.Forms.Label();
            this.NumberCodeLabel3 = new System.Windows.Forms.Label();
            this.MobileLabel3 = new System.Windows.Forms.Label();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Segoe UI Light", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.headerLabel.Location = new System.Drawing.Point(12, 9);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(344, 50);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Inspector Object Test";
            // 
            // FirstNameBox
            // 
            this.FirstNameBox.Location = new System.Drawing.Point(21, 113);
            this.FirstNameBox.Name = "FirstNameBox";
            this.FirstNameBox.Size = new System.Drawing.Size(180, 35);
            this.FirstNameBox.TabIndex = 1;
            // 
            // FirstNameLabel
            // 
            this.FirstNameLabel.AutoSize = true;
            this.FirstNameLabel.Location = new System.Drawing.Point(21, 78);
            this.FirstNameLabel.Name = "FirstNameLabel";
            this.FirstNameLabel.Size = new System.Drawing.Size(109, 30);
            this.FirstNameLabel.TabIndex = 2;
            this.FirstNameLabel.Text = "First name";
            // 
            // LastNameLabel
            // 
            this.LastNameLabel.AutoSize = true;
            this.LastNameLabel.Location = new System.Drawing.Point(248, 78);
            this.LastNameLabel.Name = "LastNameLabel";
            this.LastNameLabel.Size = new System.Drawing.Size(108, 30);
            this.LastNameLabel.TabIndex = 3;
            this.LastNameLabel.Text = "Last name";
            // 
            // LastNameBox
            // 
            this.LastNameBox.Location = new System.Drawing.Point(253, 113);
            this.LastNameBox.Name = "LastNameBox";
            this.LastNameBox.Size = new System.Drawing.Size(181, 35);
            this.LastNameBox.TabIndex = 4;
            // 
            // NumberCodeLabel
            // 
            this.NumberCodeLabel.AutoSize = true;
            this.NumberCodeLabel.Location = new System.Drawing.Point(490, 78);
            this.NumberCodeLabel.Name = "NumberCodeLabel";
            this.NumberCodeLabel.Size = new System.Drawing.Size(140, 30);
            this.NumberCodeLabel.TabIndex = 5;
            this.NumberCodeLabel.Text = "Number code";
            // 
            // NumberCodeBox
            // 
            this.NumberCodeBox.Location = new System.Drawing.Point(495, 113);
            this.NumberCodeBox.Name = "NumberCodeBox";
            this.NumberCodeBox.Size = new System.Drawing.Size(198, 35);
            this.NumberCodeBox.TabIndex = 6;
            // 
            // MobileBox
            // 
            this.MobileBox.Location = new System.Drawing.Point(745, 113);
            this.MobileBox.Name = "MobileBox";
            this.MobileBox.Size = new System.Drawing.Size(187, 35);
            this.MobileBox.TabIndex = 7;
            // 
            // MobileLabel
            // 
            this.MobileLabel.AutoSize = true;
            this.MobileLabel.Location = new System.Drawing.Point(740, 78);
            this.MobileLabel.Name = "MobileLabel";
            this.MobileLabel.Size = new System.Drawing.Size(77, 30);
            this.MobileLabel.TabIndex = 8;
            this.MobileLabel.Text = "Mobile";
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(367, 170);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(187, 48);
            this.AddButton.TabIndex = 9;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // FirstNameBoxReadOnly
            // 
            this.FirstNameBoxReadOnly.Location = new System.Drawing.Point(709, 301);
            this.FirstNameBoxReadOnly.Name = "FirstNameBoxReadOnly";
            this.FirstNameBoxReadOnly.ReadOnly = true;
            this.FirstNameBoxReadOnly.Size = new System.Drawing.Size(189, 35);
            this.FirstNameBoxReadOnly.TabIndex = 10;
            // 
            // LastNameBoxReadOnly
            // 
            this.LastNameBoxReadOnly.Location = new System.Drawing.Point(709, 342);
            this.LastNameBoxReadOnly.Name = "LastNameBoxReadOnly";
            this.LastNameBoxReadOnly.ReadOnly = true;
            this.LastNameBoxReadOnly.Size = new System.Drawing.Size(189, 35);
            this.LastNameBoxReadOnly.TabIndex = 11;
            // 
            // NumberCodeBoxReadOnly
            // 
            this.NumberCodeBoxReadOnly.Location = new System.Drawing.Point(709, 383);
            this.NumberCodeBoxReadOnly.Name = "NumberCodeBoxReadOnly";
            this.NumberCodeBoxReadOnly.ReadOnly = true;
            this.NumberCodeBoxReadOnly.Size = new System.Drawing.Size(189, 35);
            this.NumberCodeBoxReadOnly.TabIndex = 12;
            // 
            // MobileBoxReadOnly
            // 
            this.MobileBoxReadOnly.Location = new System.Drawing.Point(709, 424);
            this.MobileBoxReadOnly.Name = "MobileBoxReadOnly";
            this.MobileBoxReadOnly.ReadOnly = true;
            this.MobileBoxReadOnly.Size = new System.Drawing.Size(189, 35);
            this.MobileBoxReadOnly.TabIndex = 13;
            // 
            // FirstNameLabel2
            // 
            this.FirstNameLabel2.AutoSize = true;
            this.FirstNameLabel2.Location = new System.Drawing.Point(589, 301);
            this.FirstNameLabel2.Name = "FirstNameLabel2";
            this.FirstNameLabel2.Size = new System.Drawing.Size(114, 30);
            this.FirstNameLabel2.TabIndex = 14;
            this.FirstNameLabel2.Text = "First name:";
            // 
            // LastNameLabel2
            // 
            this.LastNameLabel2.AutoSize = true;
            this.LastNameLabel2.Location = new System.Drawing.Point(590, 342);
            this.LastNameLabel2.Name = "LastNameLabel2";
            this.LastNameLabel2.Size = new System.Drawing.Size(113, 30);
            this.LastNameLabel2.TabIndex = 15;
            this.LastNameLabel2.Text = "Last name:";
            // 
            // NumberCodeLabel2
            // 
            this.NumberCodeLabel2.AutoSize = true;
            this.NumberCodeLabel2.Location = new System.Drawing.Point(558, 383);
            this.NumberCodeLabel2.Name = "NumberCodeLabel2";
            this.NumberCodeLabel2.Size = new System.Drawing.Size(145, 30);
            this.NumberCodeLabel2.TabIndex = 16;
            this.NumberCodeLabel2.Text = "Number code:";
            // 
            // MobileLabel2
            // 
            this.MobileLabel2.AutoSize = true;
            this.MobileLabel2.Location = new System.Drawing.Point(621, 424);
            this.MobileLabel2.Name = "MobileLabel2";
            this.MobileLabel2.Size = new System.Drawing.Size(82, 30);
            this.MobileLabel2.TabIndex = 17;
            this.MobileLabel2.Text = "Mobile:";
            // 
            // IDBox
            // 
            this.IDBox.Location = new System.Drawing.Point(434, 409);
            this.IDBox.Name = "IDBox";
            this.IDBox.Size = new System.Drawing.Size(118, 35);
            this.IDBox.TabIndex = 18;
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Location = new System.Drawing.Point(518, 376);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(34, 30);
            this.IDLabel.TabIndex = 19;
            this.IDLabel.Text = "ID";
            // 
            // GetButton
            // 
            this.GetButton.Location = new System.Drawing.Point(405, 450);
            this.GetButton.Name = "GetButton";
            this.GetButton.Size = new System.Drawing.Size(149, 46);
            this.GetButton.TabIndex = 20;
            this.GetButton.Text = "Get Inspector";
            this.GetButton.UseVisualStyleBackColor = true;
            this.GetButton.Click += new System.EventHandler(this.GetButton_Click);
            // 
            // FirstNameBox2
            // 
            this.FirstNameBox2.Location = new System.Drawing.Point(21, 274);
            this.FirstNameBox2.Name = "FirstNameBox2";
            this.FirstNameBox2.Size = new System.Drawing.Size(152, 35);
            this.FirstNameBox2.TabIndex = 21;
            // 
            // LastNameBox2
            // 
            this.LastNameBox2.Location = new System.Drawing.Point(21, 315);
            this.LastNameBox2.Name = "LastNameBox2";
            this.LastNameBox2.Size = new System.Drawing.Size(152, 35);
            this.LastNameBox2.TabIndex = 22;
            // 
            // NumberCodeBox2
            // 
            this.NumberCodeBox2.Location = new System.Drawing.Point(21, 356);
            this.NumberCodeBox2.Name = "NumberCodeBox2";
            this.NumberCodeBox2.Size = new System.Drawing.Size(152, 35);
            this.NumberCodeBox2.TabIndex = 23;
            // 
            // MobileBox2
            // 
            this.MobileBox2.Location = new System.Drawing.Point(21, 397);
            this.MobileBox2.Name = "MobileBox2";
            this.MobileBox2.Size = new System.Drawing.Size(152, 35);
            this.MobileBox2.TabIndex = 24;
            // 
            // IDBox2
            // 
            this.IDBox2.Location = new System.Drawing.Point(21, 233);
            this.IDBox2.Name = "IDBox2";
            this.IDBox2.Size = new System.Drawing.Size(152, 35);
            this.IDBox2.TabIndex = 25;
            // 
            // IDLabel2
            // 
            this.IDLabel2.AutoSize = true;
            this.IDLabel2.Location = new System.Drawing.Point(179, 236);
            this.IDLabel2.Name = "IDLabel2";
            this.IDLabel2.Size = new System.Drawing.Size(34, 30);
            this.IDLabel2.TabIndex = 26;
            this.IDLabel2.Text = "ID";
            // 
            // FirstNameLabel3
            // 
            this.FirstNameLabel3.AutoSize = true;
            this.FirstNameLabel3.Location = new System.Drawing.Point(179, 277);
            this.FirstNameLabel3.Name = "FirstNameLabel3";
            this.FirstNameLabel3.Size = new System.Drawing.Size(109, 30);
            this.FirstNameLabel3.TabIndex = 27;
            this.FirstNameLabel3.Text = "First name";
            // 
            // LastNameLabel3
            // 
            this.LastNameLabel3.AutoSize = true;
            this.LastNameLabel3.Location = new System.Drawing.Point(180, 315);
            this.LastNameLabel3.Name = "LastNameLabel3";
            this.LastNameLabel3.Size = new System.Drawing.Size(108, 30);
            this.LastNameLabel3.TabIndex = 28;
            this.LastNameLabel3.Text = "Last name";
            // 
            // NumberCodeLabel3
            // 
            this.NumberCodeLabel3.AutoSize = true;
            this.NumberCodeLabel3.Location = new System.Drawing.Point(180, 359);
            this.NumberCodeLabel3.Name = "NumberCodeLabel3";
            this.NumberCodeLabel3.Size = new System.Drawing.Size(140, 30);
            this.NumberCodeLabel3.TabIndex = 29;
            this.NumberCodeLabel3.Text = "Number code";
            // 
            // MobileLabel3
            // 
            this.MobileLabel3.AutoSize = true;
            this.MobileLabel3.Location = new System.Drawing.Point(180, 400);
            this.MobileLabel3.Name = "MobileLabel3";
            this.MobileLabel3.Size = new System.Drawing.Size(77, 30);
            this.MobileLabel3.TabIndex = 30;
            this.MobileLabel3.Text = "Mobile";
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(21, 450);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(152, 36);
            this.UpdateButton.TabIndex = 31;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // ManagerViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(944, 508);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.MobileLabel3);
            this.Controls.Add(this.NumberCodeLabel3);
            this.Controls.Add(this.LastNameLabel3);
            this.Controls.Add(this.FirstNameLabel3);
            this.Controls.Add(this.IDLabel2);
            this.Controls.Add(this.IDBox2);
            this.Controls.Add(this.MobileBox2);
            this.Controls.Add(this.NumberCodeBox2);
            this.Controls.Add(this.LastNameBox2);
            this.Controls.Add(this.FirstNameBox2);
            this.Controls.Add(this.GetButton);
            this.Controls.Add(this.IDLabel);
            this.Controls.Add(this.IDBox);
            this.Controls.Add(this.MobileLabel2);
            this.Controls.Add(this.NumberCodeLabel2);
            this.Controls.Add(this.LastNameLabel2);
            this.Controls.Add(this.FirstNameLabel2);
            this.Controls.Add(this.MobileBoxReadOnly);
            this.Controls.Add(this.NumberCodeBoxReadOnly);
            this.Controls.Add(this.LastNameBoxReadOnly);
            this.Controls.Add(this.FirstNameBoxReadOnly);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.MobileLabel);
            this.Controls.Add(this.MobileBox);
            this.Controls.Add(this.NumberCodeBox);
            this.Controls.Add(this.NumberCodeLabel);
            this.Controls.Add(this.LastNameBox);
            this.Controls.Add(this.LastNameLabel);
            this.Controls.Add(this.FirstNameLabel);
            this.Controls.Add(this.FirstNameBox);
            this.Controls.Add(this.headerLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "ManagerViewerForm";
            this.Text = "Test UI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.TextBox FirstNameBox;
        private System.Windows.Forms.Label FirstNameLabel;
        private System.Windows.Forms.Label LastNameLabel;
        private System.Windows.Forms.TextBox LastNameBox;
        private System.Windows.Forms.Label NumberCodeLabel;
        private System.Windows.Forms.TextBox NumberCodeBox;
        private System.Windows.Forms.TextBox MobileBox;
        private System.Windows.Forms.Label MobileLabel;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.TextBox FirstNameBoxReadOnly;
        private System.Windows.Forms.TextBox LastNameBoxReadOnly;
        private System.Windows.Forms.TextBox NumberCodeBoxReadOnly;
        private System.Windows.Forms.TextBox MobileBoxReadOnly;
        private System.Windows.Forms.Label FirstNameLabel2;
        private System.Windows.Forms.Label LastNameLabel2;
        private System.Windows.Forms.Label NumberCodeLabel2;
        private System.Windows.Forms.Label MobileLabel2;
        private System.Windows.Forms.TextBox IDBox;
        private System.Windows.Forms.Label IDLabel;
        private System.Windows.Forms.Button GetButton;
        private System.Windows.Forms.TextBox FirstNameBox2;
        private System.Windows.Forms.TextBox LastNameBox2;
        private System.Windows.Forms.TextBox NumberCodeBox2;
        private System.Windows.Forms.TextBox MobileBox2;
        private System.Windows.Forms.TextBox IDBox2;
        private System.Windows.Forms.Label IDLabel2;
        private System.Windows.Forms.Label FirstNameLabel3;
        private System.Windows.Forms.Label LastNameLabel3;
        private System.Windows.Forms.Label NumberCodeLabel3;
        private System.Windows.Forms.Label MobileLabel3;
        private System.Windows.Forms.Button UpdateButton;
    }
}

