namespace MultichatVisual.UI.Auth
{
    partial class Auth
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
            this.TB_Name = new System.Windows.Forms.TextBox();
            this.lName = new System.Windows.Forms.Label();
            this.B_OK = new System.Windows.Forms.Button();
            this.B_Admin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TB_Name
            // 
            this.TB_Name.Location = new System.Drawing.Point(9, 32);
            this.TB_Name.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TB_Name.Name = "TB_Name";
            this.TB_Name.Size = new System.Drawing.Size(194, 20);
            this.TB_Name.TabIndex = 0;
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Location = new System.Drawing.Point(9, 7);
            this.lName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(107, 13);
            this.lName.TabIndex = 1;
            this.lName.Text = "Enter your nickname:";
            // 
            // B_OK
            // 
            this.B_OK.Location = new System.Drawing.Point(145, 64);
            this.B_OK.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.B_OK.Name = "B_OK";
            this.B_OK.Size = new System.Drawing.Size(56, 23);
            this.B_OK.TabIndex = 2;
            this.B_OK.Text = "&OK";
            this.B_OK.UseVisualStyleBackColor = true;
            this.B_OK.Click += new System.EventHandler(this.B_OK_Click);
            // 
            // B_Admin
            // 
            this.B_Admin.Location = new System.Drawing.Point(9, 64);
            this.B_Admin.Name = "B_Admin";
            this.B_Admin.Size = new System.Drawing.Size(113, 23);
            this.B_Admin.TabIndex = 4;
            this.B_Admin.Text = "Log In As Admin";
            this.B_Admin.UseVisualStyleBackColor = true;
            this.B_Admin.Click += new System.EventHandler(this.B_Admin_Click);
            // 
            // Auth
            // 
            this.AcceptButton = this.B_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 92);
            this.Controls.Add(this.B_Admin);
            this.Controls.Add(this.B_OK);
            this.Controls.Add(this.lName);
            this.Controls.Add(this.TB_Name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Auth";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Authorization";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TB_Name;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Button B_OK;
        private System.Windows.Forms.Button B_Admin;
    }
}