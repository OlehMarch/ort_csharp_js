namespace BubblePainter
{
    partial class BubbleFormUCThread
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
            this.bubblePainterThreadUC1 = new BubblePainter.BubblePainterThreadUC();
            this.bubblePainterThreadUC2 = new BubblePainter.BubblePainterThreadUC();
            this.TLP_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // TLP_Main
            // 
            this.TLP_Main.ColumnCount = 2;
            this.TLP_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_Main.Controls.Add(this.bubblePainterThreadUC1, 0, 0);
            this.TLP_Main.Controls.Add(this.bubblePainterThreadUC2, 0, 0);
            this.TLP_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_Main.Location = new System.Drawing.Point(0, 0);
            this.TLP_Main.Margin = new System.Windows.Forms.Padding(0);
            this.TLP_Main.Name = "TLP_Main";
            this.TLP_Main.RowCount = 1;
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_Main.Size = new System.Drawing.Size(707, 534);
            this.TLP_Main.TabIndex = 2;
            // 
            // bubblePainterThreadUC1
            // 
            this.bubblePainterThreadUC1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bubblePainterThreadUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bubblePainterThreadUC1.Location = new System.Drawing.Point(353, 0);
            this.bubblePainterThreadUC1.Margin = new System.Windows.Forms.Padding(0);
            this.bubblePainterThreadUC1.Name = "bubblePainterThreadUC1";
            this.bubblePainterThreadUC1.Size = new System.Drawing.Size(354, 534);
            this.bubblePainterThreadUC1.TabIndex = 3;
            // 
            // bubblePainterThreadUC2
            // 
            this.bubblePainterThreadUC2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bubblePainterThreadUC2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bubblePainterThreadUC2.Location = new System.Drawing.Point(0, 0);
            this.bubblePainterThreadUC2.Margin = new System.Windows.Forms.Padding(0);
            this.bubblePainterThreadUC2.Name = "bubblePainterThreadUC2";
            this.bubblePainterThreadUC2.Size = new System.Drawing.Size(353, 534);
            this.bubblePainterThreadUC2.TabIndex = 2;
            // 
            // BubbleFormUCThread
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 534);
            this.Controls.Add(this.TLP_Main);
            this.Name = "BubbleFormUCThread";
            this.Text = "BubbleFormUC";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BubbleFormUCThread_FormClosing);
            this.TLP_Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLP_Main;
        private BubblePainterThreadUC bubblePainterThreadUC1;
        private BubblePainterThreadUC bubblePainterThreadUC2;
    }
}