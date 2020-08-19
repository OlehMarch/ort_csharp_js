namespace MultichatVisual.UI.Chat
{
    partial class Chat
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
            this.TLP_Main = new System.Windows.Forms.TableLayoutPanel();
            this.TB_Message = new System.Windows.Forms.TextBox();
            this.B_Send = new System.Windows.Forms.Button();
            this.LB_Messages = new System.Windows.Forms.ListBox();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.MainMenu_Logout = new System.Windows.Forms.ToolStripMenuItem();
            this.B_PrivateMessage = new System.Windows.Forms.Button();
            this.LB_UserList = new System.Windows.Forms.ListBox();
            this.TLP_Main.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // TLP_Main
            // 
            this.TLP_Main.ColumnCount = 4;
            this.TLP_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.TLP_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TLP_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.TLP_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TLP_Main.Controls.Add(this.TB_Message, 0, 2);
            this.TLP_Main.Controls.Add(this.B_Send, 1, 2);
            this.TLP_Main.Controls.Add(this.LB_Messages, 0, 1);
            this.TLP_Main.Controls.Add(this.MainMenu, 0, 0);
            this.TLP_Main.Controls.Add(this.B_PrivateMessage, 3, 2);
            this.TLP_Main.Controls.Add(this.LB_UserList, 2, 1);
            this.TLP_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_Main.Location = new System.Drawing.Point(0, 0);
            this.TLP_Main.Name = "TLP_Main";
            this.TLP_Main.RowCount = 3;
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TLP_Main.Size = new System.Drawing.Size(715, 407);
            this.TLP_Main.TabIndex = 0;
            // 
            // TB_Message
            // 
            this.TB_Message.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TB_Message.Location = new System.Drawing.Point(3, 353);
            this.TB_Message.Multiline = true;
            this.TB_Message.Name = "TB_Message";
            this.TB_Message.Size = new System.Drawing.Size(244, 51);
            this.TB_Message.TabIndex = 0;
            // 
            // B_Send
            // 
            this.B_Send.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Send.Location = new System.Drawing.Point(253, 353);
            this.B_Send.Name = "B_Send";
            this.B_Send.Size = new System.Drawing.Size(101, 51);
            this.B_Send.TabIndex = 1;
            this.B_Send.Text = "Send";
            this.B_Send.UseVisualStyleBackColor = true;
            this.B_Send.Click += new System.EventHandler(this.B_Send_Click);
            // 
            // LB_Messages
            // 
            this.TLP_Main.SetColumnSpan(this.LB_Messages, 2);
            this.LB_Messages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LB_Messages.FormattingEnabled = true;
            this.LB_Messages.ItemHeight = 16;
            this.LB_Messages.Location = new System.Drawing.Point(3, 31);
            this.LB_Messages.Name = "LB_Messages";
            this.LB_Messages.Size = new System.Drawing.Size(351, 316);
            this.LB_Messages.TabIndex = 2;
            // 
            // MainMenu
            // 
            this.TLP_Main.SetColumnSpan(this.MainMenu, 4);
            this.MainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenu_Logout});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.MainMenu.Size = new System.Drawing.Size(715, 28);
            this.MainMenu.TabIndex = 3;
            this.MainMenu.Text = "menuStrip1";
            // 
            // MainMenu_Logout
            // 
            this.MainMenu_Logout.Name = "MainMenu_Logout";
            this.MainMenu_Logout.Size = new System.Drawing.Size(68, 24);
            this.MainMenu_Logout.Text = "Logout";
            this.MainMenu_Logout.Click += new System.EventHandler(this.MainMenu_Logout_Click);
            // 
            // B_PrivateMessage
            // 
            this.B_PrivateMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_PrivateMessage.Location = new System.Drawing.Point(610, 353);
            this.B_PrivateMessage.Name = "B_PrivateMessage";
            this.B_PrivateMessage.Size = new System.Drawing.Size(102, 51);
            this.B_PrivateMessage.TabIndex = 4;
            this.B_PrivateMessage.Text = "Send Private Message";
            this.B_PrivateMessage.UseVisualStyleBackColor = true;
            this.B_PrivateMessage.Click += new System.EventHandler(this.B_PrivateMessage_Click);
            // 
            // LB_UserList
            // 
            this.TLP_Main.SetColumnSpan(this.LB_UserList, 2);
            this.LB_UserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LB_UserList.FormattingEnabled = true;
            this.LB_UserList.ItemHeight = 16;
            this.LB_UserList.Location = new System.Drawing.Point(360, 31);
            this.LB_UserList.Name = "LB_UserList";
            this.LB_UserList.Size = new System.Drawing.Size(352, 316);
            this.LB_UserList.TabIndex = 5;
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 407);
            this.Controls.Add(this.TLP_Main);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "Chat";
            this.Text = "Chat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Chat_FormClosing);
            this.Load += new System.EventHandler(this.Chat_Load);
            this.TLP_Main.ResumeLayout(false);
            this.TLP_Main.PerformLayout();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLP_Main;
        private System.Windows.Forms.TextBox TB_Message;
        private System.Windows.Forms.Button B_Send;
        private System.Windows.Forms.ListBox LB_Messages;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_Logout;
        private System.Windows.Forms.Button B_PrivateMessage;
        private System.Windows.Forms.ListBox LB_UserList;
    }
}