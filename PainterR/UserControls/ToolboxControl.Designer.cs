namespace Paint.UserControls
{
    partial class ToolboxControl
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
            this.B_ColorSelector = new System.Windows.Forms.Button();
            this.buttonWidth = new System.Windows.Forms.Button();
            this.buttonShape = new System.Windows.Forms.Button();
            this.buttonIO = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // B_ColorSelector
            // 
            this.B_ColorSelector.Location = new System.Drawing.Point(3, 3);
            this.B_ColorSelector.Name = "B_ColorSelector";
            this.B_ColorSelector.Size = new System.Drawing.Size(158, 21);
            this.B_ColorSelector.TabIndex = 4;
            this.B_ColorSelector.Text = "Color";
            this.B_ColorSelector.UseVisualStyleBackColor = true;
            // 
            // buttonWidth
            // 
            this.buttonWidth.Location = new System.Drawing.Point(167, 3);
            this.buttonWidth.Name = "buttonWidth";
            this.buttonWidth.Size = new System.Drawing.Size(128, 23);
            this.buttonWidth.TabIndex = 5;
            this.buttonWidth.Text = "Width";
            this.buttonWidth.UseVisualStyleBackColor = true;
            // 
            // buttonShape
            // 
            this.buttonShape.Location = new System.Drawing.Point(301, 3);
            this.buttonShape.Name = "buttonShape";
            this.buttonShape.Size = new System.Drawing.Size(115, 23);
            this.buttonShape.TabIndex = 6;
            this.buttonShape.Text = "Shape Type";
            this.buttonShape.UseVisualStyleBackColor = true;
            // 
            // buttonIO
            // 
            this.buttonIO.Location = new System.Drawing.Point(422, 3);
            this.buttonIO.Name = "buttonIO";
            this.buttonIO.Size = new System.Drawing.Size(109, 23);
            this.buttonIO.TabIndex = 7;
            this.buttonIO.Text = "S \\ L";
            this.buttonIO.UseVisualStyleBackColor = true;
            // 
            // ToolboxControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonIO);
            this.Controls.Add(this.buttonShape);
            this.Controls.Add(this.buttonWidth);
            this.Controls.Add(this.B_ColorSelector);
            this.Name = "ToolboxControl";
            this.Size = new System.Drawing.Size(535, 28);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button B_ColorSelector;
        private System.Windows.Forms.Button buttonWidth;
        private System.Windows.Forms.Button buttonShape;
        private System.Windows.Forms.Button buttonIO;
    }
}
