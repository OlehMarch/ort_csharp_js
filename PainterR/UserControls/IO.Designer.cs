namespace Paint.UserControls
{
    partial class IO
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonIO = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonIO
            // 
            this.buttonIO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonIO.Location = new System.Drawing.Point(0, 0);
            this.buttonIO.Name = "buttonIO";
            this.buttonIO.Size = new System.Drawing.Size(82, 31);
            this.buttonIO.TabIndex = 0;
            this.buttonIO.Text = "Save / Load";
            this.buttonIO.UseVisualStyleBackColor = true;
            // 
            // IO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonIO);
            this.Name = "IO";
            this.Size = new System.Drawing.Size(82, 31);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonIO;
    }
}
