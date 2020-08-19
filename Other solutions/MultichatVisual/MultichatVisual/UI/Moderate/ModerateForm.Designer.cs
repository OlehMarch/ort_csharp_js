namespace MultichatVisual.UI.Moderate
{
    partial class ModerateForm
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
            this.LB_UserList = new System.Windows.Forms.ListBox();
            this.B_Ban = new System.Windows.Forms.Button();
            this.B_Unban = new System.Windows.Forms.Button();
            this.NUD_BanTime = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_BanTime)).BeginInit();
            this.SuspendLayout();
            // 
            // LB_UserList
            // 
            this.LB_UserList.FormattingEnabled = true;
            this.LB_UserList.ItemHeight = 16;
            this.LB_UserList.Location = new System.Drawing.Point(13, 10);
            this.LB_UserList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LB_UserList.Name = "LB_UserList";
            this.LB_UserList.Size = new System.Drawing.Size(239, 292);
            this.LB_UserList.TabIndex = 0;
            // 
            // B_Ban
            // 
            this.B_Ban.Location = new System.Drawing.Point(260, 41);
            this.B_Ban.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.B_Ban.Name = "B_Ban";
            this.B_Ban.Size = new System.Drawing.Size(107, 36);
            this.B_Ban.TabIndex = 1;
            this.B_Ban.Text = "Ban";
            this.B_Ban.UseVisualStyleBackColor = true;
            this.B_Ban.Click += new System.EventHandler(this.B_Ban_Click);
            // 
            // B_Unban
            // 
            this.B_Unban.Location = new System.Drawing.Point(260, 84);
            this.B_Unban.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.B_Unban.Name = "B_Unban";
            this.B_Unban.Size = new System.Drawing.Size(107, 36);
            this.B_Unban.TabIndex = 2;
            this.B_Unban.Text = "Unban";
            this.B_Unban.UseVisualStyleBackColor = true;
            this.B_Unban.Click += new System.EventHandler(this.B_Unban_Click);
            // 
            // NUD_BanTime
            // 
            this.NUD_BanTime.Location = new System.Drawing.Point(260, 12);
            this.NUD_BanTime.Maximum = new decimal(new int[] {
            60000000,
            0,
            0,
            0});
            this.NUD_BanTime.Name = "NUD_BanTime";
            this.NUD_BanTime.Size = new System.Drawing.Size(107, 22);
            this.NUD_BanTime.TabIndex = 3;
            // 
            // ModerateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 313);
            this.Controls.Add(this.NUD_BanTime);
            this.Controls.Add(this.B_Unban);
            this.Controls.Add(this.B_Ban);
            this.Controls.Add(this.LB_UserList);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ModerateForm";
            this.Text = "ModerateForm";
            this.Load += new System.EventHandler(this.ModerateForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NUD_BanTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LB_UserList;
        private System.Windows.Forms.Button B_Ban;
        private System.Windows.Forms.Button B_Unban;
        private System.Windows.Forms.NumericUpDown NUD_BanTime;
    }
}