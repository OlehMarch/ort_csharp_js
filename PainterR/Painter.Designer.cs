namespace Paint
{
    partial class Painter
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
            this.toolboxControl1 = new Paint.UserControls.ToolboxControl();
            this.io1 = new Paint.UserControls.IO();
            this.statusControl1 = new Paint.UserControls.StatusControl();
            this.canvas1 = new Paint.UserControls.Canvas();
            this.menuControl1 = new Paint.UserControls.MenuControl();
            this.shapeTypeSelector1 = new Paint.UserControls.ShapeTypeSelector();
            this.penWidthSelector1 = new Paint.UserControls.PenWidthSelector();
            this.colorSelector1 = new Paint.UserControls.ColorSelector();
            this.SuspendLayout();
            // 
            // toolboxControl1
            // 
            this.toolboxControl1.Location = new System.Drawing.Point(423, 2);
            this.toolboxControl1.Name = "toolboxControl1";
            this.toolboxControl1.Size = new System.Drawing.Size(648, 28);
            this.toolboxControl1.TabIndex = 8;
            // 
            // io1
            // 
            this.io1.canvas = null;
            this.io1.Location = new System.Drawing.Point(2, 272);
            this.io1.Name = "io1";
            this.io1.Size = new System.Drawing.Size(150, 27);
            this.io1.TabIndex = 7;
            // 
            // statusControl1
            // 
            this.statusControl1.canvas = this.canvas1;
            this.statusControl1.Location = new System.Drawing.Point(2, 595);
            this.statusControl1.Name = "statusControl1";
            this.statusControl1.Size = new System.Drawing.Size(1025, 30);
            this.statusControl1.TabIndex = 5;
            // 
            // canvas1
            // 
            this.canvas1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.canvas1.Location = new System.Drawing.Point(158, 36);
            this.canvas1.Name = "canvas1";
            this.canvas1.Size = new System.Drawing.Size(1317, 553);
            this.canvas1.status = this.statusControl1;
            this.canvas1.TabIndex = 0;
            // 
            // menuControl1
            // 
            this.menuControl1.Location = new System.Drawing.Point(2, 2);
            this.menuControl1.Name = "menuControl1";
            this.menuControl1.Size = new System.Drawing.Size(415, 28);
            this.menuControl1.TabIndex = 4;
            // 
            // shapeTypeSelector1
            // 
            this.shapeTypeSelector1.Location = new System.Drawing.Point(2, 239);
            this.shapeTypeSelector1.Name = "shapeTypeSelector1";
            this.shapeTypeSelector1.Size = new System.Drawing.Size(150, 27);
            this.shapeTypeSelector1.TabIndex = 3;
            // 
            // penWidthSelector1
            // 
            this.penWidthSelector1.Location = new System.Drawing.Point(2, 206);
            this.penWidthSelector1.Name = "penWidthSelector1";
            this.penWidthSelector1.Size = new System.Drawing.Size(150, 27);
            this.penWidthSelector1.TabIndex = 2;
            // 
            // colorSelector1
            // 
            this.colorSelector1.Location = new System.Drawing.Point(2, 173);
            this.colorSelector1.Name = "colorSelector1";
            this.colorSelector1.Size = new System.Drawing.Size(150, 27);
            this.colorSelector1.TabIndex = 1;
            // 
            // Painter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 629);
            this.Controls.Add(this.toolboxControl1);
            this.Controls.Add(this.io1);
            this.Controls.Add(this.statusControl1);
            this.Controls.Add(this.menuControl1);
            this.Controls.Add(this.shapeTypeSelector1);
            this.Controls.Add(this.penWidthSelector1);
            this.Controls.Add(this.colorSelector1);
            this.Controls.Add(this.canvas1);
            this.Name = "Painter";
            this.Text = "Painter";
            this.ResumeLayout(false);

        }

        #endregion

        private Paint.UserControls.Canvas canvas1;
        private Paint.UserControls.ColorSelector colorSelector1;
        private Paint.UserControls.PenWidthSelector penWidthSelector1;
        private Paint.UserControls.ShapeTypeSelector shapeTypeSelector1;
        private UserControls.MenuControl menuControl1;
        private UserControls.StatusControl statusControl1;
        private Paint.UserControls.IO io1;
        private UserControls.ToolboxControl toolboxControl1;
    }
}