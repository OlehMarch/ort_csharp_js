namespace WFDialogs
{
    partial class DialogsForm
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
            this.B_ColorDialog = new System.Windows.Forms.Button();
            this.B_FileBrowserDialog = new System.Windows.Forms.Button();
            this.B_FontDialog = new System.Windows.Forms.Button();
            this.B_OpenFileDialog = new System.Windows.Forms.Button();
            this.B_SaveFileDialog = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.B_PageSetupDialog = new System.Windows.Forms.Button();
            this.B_PrintDialog = new System.Windows.Forms.Button();
            this.B_PrintPreviewDialog = new System.Windows.Forms.Button();
            this.B_ThreadExceptionDialog = new System.Windows.Forms.Button();
            this.B_MessageBox = new System.Windows.Forms.Button();
            this.B_CustomDialog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // B_ColorDialog
            // 
            this.B_ColorDialog.Location = new System.Drawing.Point(13, 13);
            this.B_ColorDialog.Name = "B_ColorDialog";
            this.B_ColorDialog.Size = new System.Drawing.Size(151, 23);
            this.B_ColorDialog.TabIndex = 0;
            this.B_ColorDialog.Text = "Color Dialog";
            this.B_ColorDialog.UseVisualStyleBackColor = true;
            this.B_ColorDialog.Click += new System.EventHandler(this.B_ColorDialog_Click);
            // 
            // B_FileBrowserDialog
            // 
            this.B_FileBrowserDialog.Location = new System.Drawing.Point(13, 42);
            this.B_FileBrowserDialog.Name = "B_FileBrowserDialog";
            this.B_FileBrowserDialog.Size = new System.Drawing.Size(151, 23);
            this.B_FileBrowserDialog.TabIndex = 1;
            this.B_FileBrowserDialog.Text = "Folder Browser Dialog";
            this.B_FileBrowserDialog.UseVisualStyleBackColor = true;
            this.B_FileBrowserDialog.Click += new System.EventHandler(this.B_FileBrowserDialog_Click);
            // 
            // B_FontDialog
            // 
            this.B_FontDialog.Location = new System.Drawing.Point(13, 71);
            this.B_FontDialog.Name = "B_FontDialog";
            this.B_FontDialog.Size = new System.Drawing.Size(151, 23);
            this.B_FontDialog.TabIndex = 2;
            this.B_FontDialog.Text = "Font Dialog";
            this.B_FontDialog.UseVisualStyleBackColor = true;
            this.B_FontDialog.Click += new System.EventHandler(this.B_FontDialog_Click);
            // 
            // B_OpenFileDialog
            // 
            this.B_OpenFileDialog.Location = new System.Drawing.Point(13, 100);
            this.B_OpenFileDialog.Name = "B_OpenFileDialog";
            this.B_OpenFileDialog.Size = new System.Drawing.Size(151, 23);
            this.B_OpenFileDialog.TabIndex = 3;
            this.B_OpenFileDialog.Text = "Open File Dialog";
            this.B_OpenFileDialog.UseVisualStyleBackColor = true;
            this.B_OpenFileDialog.Click += new System.EventHandler(this.B_OpenFileDialog_Click);
            // 
            // B_SaveFileDialog
            // 
            this.B_SaveFileDialog.Location = new System.Drawing.Point(13, 129);
            this.B_SaveFileDialog.Name = "B_SaveFileDialog";
            this.B_SaveFileDialog.Size = new System.Drawing.Size(151, 23);
            this.B_SaveFileDialog.TabIndex = 4;
            this.B_SaveFileDialog.Text = "Save File Dialog";
            this.B_SaveFileDialog.UseVisualStyleBackColor = true;
            this.B_SaveFileDialog.Click += new System.EventHandler(this.B_SaveFileDialog_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // B_PageSetupDialog
            // 
            this.B_PageSetupDialog.Location = new System.Drawing.Point(13, 158);
            this.B_PageSetupDialog.Name = "B_PageSetupDialog";
            this.B_PageSetupDialog.Size = new System.Drawing.Size(151, 23);
            this.B_PageSetupDialog.TabIndex = 5;
            this.B_PageSetupDialog.Text = "Page Setup Dialog";
            this.B_PageSetupDialog.UseVisualStyleBackColor = true;
            this.B_PageSetupDialog.Click += new System.EventHandler(this.B_PageSetupDialog_Click);
            // 
            // B_PrintDialog
            // 
            this.B_PrintDialog.Location = new System.Drawing.Point(13, 187);
            this.B_PrintDialog.Name = "B_PrintDialog";
            this.B_PrintDialog.Size = new System.Drawing.Size(151, 23);
            this.B_PrintDialog.TabIndex = 7;
            this.B_PrintDialog.Text = "Print Dialog";
            this.B_PrintDialog.UseVisualStyleBackColor = true;
            this.B_PrintDialog.Click += new System.EventHandler(this.B_PrintDialog_Click);
            // 
            // B_PrintPreviewDialog
            // 
            this.B_PrintPreviewDialog.Location = new System.Drawing.Point(13, 216);
            this.B_PrintPreviewDialog.Name = "B_PrintPreviewDialog";
            this.B_PrintPreviewDialog.Size = new System.Drawing.Size(151, 23);
            this.B_PrintPreviewDialog.TabIndex = 8;
            this.B_PrintPreviewDialog.Text = "Print Preview Dialog";
            this.B_PrintPreviewDialog.UseVisualStyleBackColor = true;
            this.B_PrintPreviewDialog.Click += new System.EventHandler(this.B_PrintPreviewDialog_Click);
            // 
            // B_ThreadExceptionDialog
            // 
            this.B_ThreadExceptionDialog.Location = new System.Drawing.Point(13, 245);
            this.B_ThreadExceptionDialog.Name = "B_ThreadExceptionDialog";
            this.B_ThreadExceptionDialog.Size = new System.Drawing.Size(151, 23);
            this.B_ThreadExceptionDialog.TabIndex = 9;
            this.B_ThreadExceptionDialog.Text = "Thread Exception Dialog";
            this.B_ThreadExceptionDialog.UseVisualStyleBackColor = true;
            this.B_ThreadExceptionDialog.Click += new System.EventHandler(this.B_ThreadExceptionDialog_Click);
            // 
            // B_MessageBox
            // 
            this.B_MessageBox.Location = new System.Drawing.Point(13, 274);
            this.B_MessageBox.Name = "B_MessageBox";
            this.B_MessageBox.Size = new System.Drawing.Size(151, 23);
            this.B_MessageBox.TabIndex = 10;
            this.B_MessageBox.Text = "Message Box";
            this.B_MessageBox.UseVisualStyleBackColor = true;
            this.B_MessageBox.Click += new System.EventHandler(this.B_MessageBox_Click);
            // 
            // B_CustomDialog
            // 
            this.B_CustomDialog.Location = new System.Drawing.Point(13, 303);
            this.B_CustomDialog.Name = "B_CustomDialog";
            this.B_CustomDialog.Size = new System.Drawing.Size(151, 23);
            this.B_CustomDialog.TabIndex = 11;
            this.B_CustomDialog.Text = "Custom Dialog";
            this.B_CustomDialog.UseVisualStyleBackColor = true;
            this.B_CustomDialog.Click += new System.EventHandler(this.B_CustomDialog_Click);
            // 
            // DialogsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(176, 333);
            this.Controls.Add(this.B_CustomDialog);
            this.Controls.Add(this.B_MessageBox);
            this.Controls.Add(this.B_ThreadExceptionDialog);
            this.Controls.Add(this.B_PrintPreviewDialog);
            this.Controls.Add(this.B_PrintDialog);
            this.Controls.Add(this.B_PageSetupDialog);
            this.Controls.Add(this.B_SaveFileDialog);
            this.Controls.Add(this.B_OpenFileDialog);
            this.Controls.Add(this.B_FontDialog);
            this.Controls.Add(this.B_FileBrowserDialog);
            this.Controls.Add(this.B_ColorDialog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogsForm";
            this.Text = "Dialogs";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button B_ColorDialog;
        private System.Windows.Forms.Button B_FileBrowserDialog;
        private System.Windows.Forms.Button B_FontDialog;
        private System.Windows.Forms.Button B_OpenFileDialog;
        private System.Windows.Forms.Button B_SaveFileDialog;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button B_PageSetupDialog;
        private System.Windows.Forms.Button B_PrintDialog;
        private System.Windows.Forms.Button B_PrintPreviewDialog;
        private System.Windows.Forms.Button B_ThreadExceptionDialog;
        private System.Windows.Forms.Button B_MessageBox;
        private System.Windows.Forms.Button B_CustomDialog;
    }
}

