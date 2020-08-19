namespace Paint.UserControls
{
    partial class ShapeTypeSelector
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
            this.buttonShape = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonShape
            // 
            this.buttonShape.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonShape.Location = new System.Drawing.Point(0, 0);
            this.buttonShape.Name = "buttonShape";
            this.buttonShape.Size = new System.Drawing.Size(150, 51);
            this.buttonShape.TabIndex = 0;
            this.buttonShape.Text = "Shape";
            this.buttonShape.UseVisualStyleBackColor = true;
            // 
            // ShapeTypeSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonShape);
            this.Name = "ShapeTypeSelector";
            this.Size = new System.Drawing.Size(150, 51);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonShape;
    }
}
