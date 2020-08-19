namespace Task4_02
{
    partial class DisplayBST
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
            this.PB_Graph = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Graph)).BeginInit();
            this.SuspendLayout();
            // 
            // PB_Graph
            // 
            this.PB_Graph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PB_Graph.Location = new System.Drawing.Point(0, 0);
            this.PB_Graph.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PB_Graph.Name = "PB_Graph";
            this.PB_Graph.Size = new System.Drawing.Size(1135, 739);
            this.PB_Graph.TabIndex = 0;
            this.PB_Graph.TabStop = false;
            // 
            // DisplayBST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 739);
            this.Controls.Add(this.PB_Graph);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DisplayBST";
            this.Text = "DisplayBST";
            ((System.ComponentModel.ISupportInitialize)(this.PB_Graph)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PB_Graph;
    }
}