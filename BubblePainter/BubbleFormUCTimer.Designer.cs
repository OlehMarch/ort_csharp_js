namespace BubblePainter
{
    partial class BubbleFormUCTimer
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
            this.bubblePainterTimerUC2 = new BubblePainter.BubblePainterTimerUC();
            this.bubblePainterTimerUC1 = new BubblePainter.BubblePainterTimerUC();
            this.TLP_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // TLP_Main
            // 
            this.TLP_Main.ColumnCount = 2;
            this.TLP_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_Main.Controls.Add(this.bubblePainterTimerUC1, 0, 0);
            this.TLP_Main.Controls.Add(this.bubblePainterTimerUC2, 0, 0);
            this.TLP_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_Main.Location = new System.Drawing.Point(0, 0);
            this.TLP_Main.Margin = new System.Windows.Forms.Padding(0);
            this.TLP_Main.Name = "TLP_Main";
            this.TLP_Main.RowCount = 1;
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_Main.Size = new System.Drawing.Size(742, 534);
            this.TLP_Main.TabIndex = 2;
            // 
            // bubblePainterTimerUC2
            // 
            this.bubblePainterTimerUC2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bubblePainterTimerUC2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bubblePainterTimerUC2.Location = new System.Drawing.Point(0, 0);
            this.bubblePainterTimerUC2.Margin = new System.Windows.Forms.Padding(0);
            this.bubblePainterTimerUC2.Name = "bubblePainterTimerUC2";
            this.bubblePainterTimerUC2.Size = new System.Drawing.Size(371, 534);
            this.bubblePainterTimerUC2.TabIndex = 2;
            // 
            // bubblePainterTimerUC1
            // 
            this.bubblePainterTimerUC1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bubblePainterTimerUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bubblePainterTimerUC1.Location = new System.Drawing.Point(371, 0);
            this.bubblePainterTimerUC1.Margin = new System.Windows.Forms.Padding(0);
            this.bubblePainterTimerUC1.Name = "bubblePainterTimerUC1";
            this.bubblePainterTimerUC1.Size = new System.Drawing.Size(371, 534);
            this.bubblePainterTimerUC1.TabIndex = 3;
            // 
            // BubbleFormUCTimer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 534);
            this.Controls.Add(this.TLP_Main);
            this.Name = "BubbleFormUCTimer";
            this.Text = "BubbleFormUC";
            this.TLP_Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLP_Main;
        private BubblePainterTimerUC bubblePainterTimerUC1;
        private BubblePainterTimerUC bubblePainterTimerUC2;
    }
}