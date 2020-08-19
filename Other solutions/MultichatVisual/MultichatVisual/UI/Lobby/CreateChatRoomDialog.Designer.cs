namespace MultichatVisual.UI.Lobby
{
    partial class CreateChatRoomDialog
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
            this.lCharRoomName = new System.Windows.Forms.Label();
            this.TB_ChatRoomName = new System.Windows.Forms.TextBox();
            this.B_OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lCharRoomName
            // 
            this.lCharRoomName.AutoSize = true;
            this.lCharRoomName.Location = new System.Drawing.Point(15, 12);
            this.lCharRoomName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lCharRoomName.Name = "lCharRoomName";
            this.lCharRoomName.Size = new System.Drawing.Size(114, 13);
            this.lCharRoomName.TabIndex = 0;
            this.lCharRoomName.Text = "Enter chat room name:";
            // 
            // TB_ChatRoomName
            // 
            this.TB_ChatRoomName.Location = new System.Drawing.Point(15, 29);
            this.TB_ChatRoomName.Margin = new System.Windows.Forms.Padding(2);
            this.TB_ChatRoomName.Name = "TB_ChatRoomName";
            this.TB_ChatRoomName.Size = new System.Drawing.Size(194, 20);
            this.TB_ChatRoomName.TabIndex = 1;
            // 
            // B_OK
            // 
            this.B_OK.Location = new System.Drawing.Point(158, 53);
            this.B_OK.Margin = new System.Windows.Forms.Padding(2);
            this.B_OK.Name = "B_OK";
            this.B_OK.Size = new System.Drawing.Size(51, 32);
            this.B_OK.TabIndex = 2;
            this.B_OK.Text = "&OK";
            this.B_OK.UseVisualStyleBackColor = true;
            this.B_OK.Click += new System.EventHandler(this.B_OK_Click);
            // 
            // CreateChatRoomDialog
            // 
            this.AcceptButton = this.B_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 91);
            this.Controls.Add(this.B_OK);
            this.Controls.Add(this.TB_ChatRoomName);
            this.Controls.Add(this.lCharRoomName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateChatRoomDialog";
            this.ShowIcon = false;
            this.Text = "Create chat room";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lCharRoomName;
        private System.Windows.Forms.TextBox TB_ChatRoomName;
        private System.Windows.Forms.Button B_OK;
    }
}