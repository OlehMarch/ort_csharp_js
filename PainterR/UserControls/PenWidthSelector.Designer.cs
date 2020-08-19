namespace Paint.UserControls
{
    partial class PenWidthSelector
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
            this.buttonSetWidth = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSetWidth
            // 
            this.buttonSetWidth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetWidth.Location = new System.Drawing.Point(0, 0);
            this.buttonSetWidth.Name = "buttonSetWidth";
            this.buttonSetWidth.Size = new System.Drawing.Size(137, 37);
            this.buttonSetWidth.TabIndex = 0;
            this.buttonSetWidth.Text = "Width";
            this.buttonSetWidth.UseVisualStyleBackColor = true;
            // 
            // PenWidthSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonSetWidth);
            this.Name = "PenWidthSelector";
            this.Size = new System.Drawing.Size(137, 37);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSetWidth;
    }
}
