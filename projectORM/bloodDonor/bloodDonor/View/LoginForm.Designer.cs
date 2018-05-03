namespace bloodDonor
{
    partial class LoginForm
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
            this.userTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.usernameLbl = new System.Windows.Forms.Label();
            this.passwordLbl = new System.Windows.Forms.Label();
            this.messageLbl = new System.Windows.Forms.Label();
            this.logInBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // userTextBox
            // 
            this.userTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.userTextBox.Location = new System.Drawing.Point(133, 100);
            this.userTextBox.Margin = new System.Windows.Forms.Padding(3, 30, 3, 3);
            this.userTextBox.Name = "userTextBox";
            this.userTextBox.Size = new System.Drawing.Size(175, 22);
            this.userTextBox.TabIndex = 0;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.passwordTextBox.Location = new System.Drawing.Point(133, 143);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(175, 22);
            this.passwordTextBox.TabIndex = 1;
            // 
            // usernameLbl
            // 
            this.usernameLbl.AutoSize = true;
            this.usernameLbl.Location = new System.Drawing.Point(33, 100);
            this.usernameLbl.Margin = new System.Windows.Forms.Padding(3, 30, 3, 0);
            this.usernameLbl.Name = "usernameLbl";
            this.usernameLbl.Size = new System.Drawing.Size(77, 17);
            this.usernameLbl.TabIndex = 2;
            this.usernameLbl.Text = "Username:";
            // 
            // passwordLbl
            // 
            this.passwordLbl.AutoSize = true;
            this.passwordLbl.Location = new System.Drawing.Point(33, 145);
            this.passwordLbl.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.passwordLbl.Name = "passwordLbl";
            this.passwordLbl.Size = new System.Drawing.Size(73, 17);
            this.passwordLbl.TabIndex = 3;
            this.passwordLbl.Text = "Password:";
            // 
            // messageLbl
            // 
            this.messageLbl.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.messageLbl, 2);
            this.messageLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageLbl.Location = new System.Drawing.Point(33, 40);
            this.messageLbl.Margin = new System.Windows.Forms.Padding(3, 40, 3, 0);
            this.messageLbl.Name = "messageLbl";
            this.messageLbl.Size = new System.Drawing.Size(259, 24);
            this.messageLbl.TabIndex = 4;
            this.messageLbl.Text = "Welcome back! Please log in!";
            // 
            // logInBtn
            // 
            this.logInBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.logInBtn.Location = new System.Drawing.Point(133, 213);
            this.logInBtn.Name = "logInBtn";
            this.logInBtn.Size = new System.Drawing.Size(175, 37);
            this.logInBtn.TabIndex = 5;
            this.logInBtn.Text = "Log In";
            this.logInBtn.UseVisualStyleBackColor = true;
            this.logInBtn.Click += new System.EventHandler(this.logInBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.exitBtn.Location = new System.Drawing.Point(133, 283);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(175, 40);
            this.exitBtn.TabIndex = 6;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.71428F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Controls.Add(this.exitBtn, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.usernameLbl, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.passwordTextBox, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.userTextBox, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.logInBtn, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.passwordLbl, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.messageLbl, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(342, 353);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 353);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximumSize = new System.Drawing.Size(500, 500);
            this.MinimumSize = new System.Drawing.Size(360, 400);
            this.Name = "Form1";
            this.Text = "Please log in";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox userTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label usernameLbl;
        private System.Windows.Forms.Label passwordLbl;
        private System.Windows.Forms.Label messageLbl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Button logInBtn;
    }
}

