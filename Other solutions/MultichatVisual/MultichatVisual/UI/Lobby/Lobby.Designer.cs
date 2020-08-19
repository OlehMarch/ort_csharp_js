namespace MultichatVisual
{
    partial class Lobby
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.LB_ChatRooms = new System.Windows.Forms.ListBox();
            this.B_Create = new System.Windows.Forms.Button();
            this.B_Connect = new System.Windows.Forms.Button();
            this.B_ConnectToServer = new System.Windows.Forms.Button();
            this.B_Moderate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LB_ChatRooms
            // 
            this.LB_ChatRooms.FormattingEnabled = true;
            this.LB_ChatRooms.Location = new System.Drawing.Point(9, 10);
            this.LB_ChatRooms.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LB_ChatRooms.Name = "LB_ChatRooms";
            this.LB_ChatRooms.Size = new System.Drawing.Size(209, 329);
            this.LB_ChatRooms.TabIndex = 0;
            // 
            // B_Create
            // 
            this.B_Create.Location = new System.Drawing.Point(222, 11);
            this.B_Create.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.B_Create.Name = "B_Create";
            this.B_Create.Size = new System.Drawing.Size(163, 26);
            this.B_Create.TabIndex = 1;
            this.B_Create.Text = "Create room";
            this.B_Create.UseVisualStyleBackColor = true;
            this.B_Create.Click += new System.EventHandler(this.B_Create_Click);
            // 
            // B_Connect
            // 
            this.B_Connect.Location = new System.Drawing.Point(222, 41);
            this.B_Connect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.B_Connect.Name = "B_Connect";
            this.B_Connect.Size = new System.Drawing.Size(163, 26);
            this.B_Connect.TabIndex = 2;
            this.B_Connect.Text = "Enter room";
            this.B_Connect.UseVisualStyleBackColor = true;
            this.B_Connect.Click += new System.EventHandler(this.B_Connect_Click);
            // 
            // B_ConnectToServer
            // 
            this.B_ConnectToServer.Location = new System.Drawing.Point(222, 314);
            this.B_ConnectToServer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.B_ConnectToServer.Name = "B_ConnectToServer";
            this.B_ConnectToServer.Size = new System.Drawing.Size(163, 26);
            this.B_ConnectToServer.TabIndex = 3;
            this.B_ConnectToServer.Text = "Connect to server";
            this.B_ConnectToServer.UseVisualStyleBackColor = true;
            this.B_ConnectToServer.Click += new System.EventHandler(this.B_ConnectToServer_Click);
            // 
            // B_Moderate
            // 
            this.B_Moderate.Location = new System.Drawing.Point(223, 145);
            this.B_Moderate.Name = "B_Moderate";
            this.B_Moderate.Size = new System.Drawing.Size(162, 23);
            this.B_Moderate.TabIndex = 4;
            this.B_Moderate.Text = "Moderate";
            this.B_Moderate.UseVisualStyleBackColor = true;
            this.B_Moderate.Visible = false;
            this.B_Moderate.Click += new System.EventHandler(this.B_Moderate_Click);
            // 
            // Lobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 349);
            this.Controls.Add(this.B_Moderate);
            this.Controls.Add(this.B_ConnectToServer);
            this.Controls.Add(this.B_Connect);
            this.Controls.Add(this.B_Create);
            this.Controls.Add(this.LB_ChatRooms);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Lobby";
            this.Text = "Lobby";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LB_ChatRooms;
        private System.Windows.Forms.Button B_Create;
        private System.Windows.Forms.Button B_Connect;
        private System.Windows.Forms.Button B_ConnectToServer;
        private System.Windows.Forms.Button B_Moderate;
    }
}

