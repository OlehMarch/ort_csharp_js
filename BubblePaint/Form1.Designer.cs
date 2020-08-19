namespace BubblePaint
{
    partial class Form1
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
            this.bubbleLayer1 = new BubblePaint.BubbleLayerTimer();
            this.bubbleLayerThread1 = new BubblePaint.BubbleLayerThread();
            this.SuspendLayout();
            // 
            // bubbleLayer1
            // 
            this.bubbleLayer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bubbleLayer1.AutoSize = true;
            this.bubbleLayer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bubbleLayer1.Location = new System.Drawing.Point(21, 12);
            this.bubbleLayer1.Name = "bubbleLayer1";
            this.bubbleLayer1.Size = new System.Drawing.Size(515, 465);
            this.bubbleLayer1.TabIndex = 0;
            // 
            // bubbleLayerThread1
            // 
            this.bubbleLayerThread1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bubbleLayerThread1.AutoSize = true;
            this.bubbleLayerThread1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bubbleLayerThread1.Location = new System.Drawing.Point(542, 12);
            this.bubbleLayerThread1.Name = "bubbleLayerThread1";
            this.bubbleLayerThread1.Size = new System.Drawing.Size(515, 465);
            this.bubbleLayerThread1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 489);
            this.Controls.Add(this.bubbleLayerThread1);
            this.Controls.Add(this.bubbleLayer1);
            this.Name = "Form1";
            this.Text = "Bubble Paint";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BubbleLayerTimer bubbleLayer1;
        private BubbleLayerThread bubbleLayerThread1;

    }
}

