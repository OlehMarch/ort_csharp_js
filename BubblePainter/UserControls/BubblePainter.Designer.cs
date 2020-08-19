namespace BubblePainter
{
    partial class BubblePainterUC
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BubblePainterUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "BubblePainterUC";
            this.Size = new System.Drawing.Size(312, 315);
            this.SizeChanged += new System.EventHandler(this.BubblePainter_Resize);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BubblePainter_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BubblePainter_MouseUp);
            this.Resize += new System.EventHandler(this.BubblePainter_Resize);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
