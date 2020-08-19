namespace Task1_5
{
    partial class Calculator
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.TB_FirstOperand = new System.Windows.Forms.TextBox();
            this.TB_Operation = new System.Windows.Forms.TextBox();
            this.TB_Result = new System.Windows.Forms.TextBox();
            this.TB_SecondOperand = new System.Windows.Forms.TextBox();
            this.B_Calculate = new System.Windows.Forms.Button();
            this.L_SO = new System.Windows.Forms.Label();
            this.L_FO = new System.Windows.Forms.Label();
            this.L_Operation = new System.Windows.Forms.Label();
            this.L_Result = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TB_FirstOperand
            // 
            this.TB_FirstOperand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_FirstOperand.Location = new System.Drawing.Point(139, 14);
            this.TB_FirstOperand.Margin = new System.Windows.Forms.Padding(5);
            this.TB_FirstOperand.MaxLength = 20;
            this.TB_FirstOperand.Name = "TB_FirstOperand";
            this.TB_FirstOperand.Size = new System.Drawing.Size(184, 27);
            this.TB_FirstOperand.TabIndex = 0;
            // 
            // TB_Operation
            // 
            this.TB_Operation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Operation.Location = new System.Drawing.Point(139, 51);
            this.TB_Operation.Margin = new System.Windows.Forms.Padding(5);
            this.TB_Operation.MaxLength = 1;
            this.TB_Operation.Name = "TB_Operation";
            this.TB_Operation.Size = new System.Drawing.Size(184, 27);
            this.TB_Operation.TabIndex = 1;
            // 
            // TB_Result
            // 
            this.TB_Result.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Result.Location = new System.Drawing.Point(139, 125);
            this.TB_Result.Margin = new System.Windows.Forms.Padding(5);
            this.TB_Result.Name = "TB_Result";
            this.TB_Result.ReadOnly = true;
            this.TB_Result.Size = new System.Drawing.Size(184, 27);
            this.TB_Result.TabIndex = 3;
            // 
            // TB_SecondOperand
            // 
            this.TB_SecondOperand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_SecondOperand.Location = new System.Drawing.Point(139, 88);
            this.TB_SecondOperand.Margin = new System.Windows.Forms.Padding(5);
            this.TB_SecondOperand.MaxLength = 20;
            this.TB_SecondOperand.Name = "TB_SecondOperand";
            this.TB_SecondOperand.Size = new System.Drawing.Size(184, 27);
            this.TB_SecondOperand.TabIndex = 2;
            // 
            // B_Calculate
            // 
            this.B_Calculate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Calculate.Location = new System.Drawing.Point(12, 160);
            this.B_Calculate.Name = "B_Calculate";
            this.B_Calculate.Size = new System.Drawing.Size(311, 41);
            this.B_Calculate.TabIndex = 4;
            this.B_Calculate.Text = "Calculate";
            this.B_Calculate.UseVisualStyleBackColor = true;
            this.B_Calculate.Click += new System.EventHandler(this.B_Calculate_Click);
            // 
            // L_SO
            // 
            this.L_SO.Location = new System.Drawing.Point(12, 88);
            this.L_SO.Name = "L_SO";
            this.L_SO.Size = new System.Drawing.Size(119, 27);
            this.L_SO.TabIndex = 6;
            this.L_SO.Text = "First operand:";
            this.L_SO.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // L_FO
            // 
            this.L_FO.Location = new System.Drawing.Point(12, 14);
            this.L_FO.Name = "L_FO";
            this.L_FO.Size = new System.Drawing.Size(119, 27);
            this.L_FO.TabIndex = 7;
            this.L_FO.Text = "First operand:";
            this.L_FO.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // L_Operation
            // 
            this.L_Operation.Location = new System.Drawing.Point(12, 51);
            this.L_Operation.Name = "L_Operation";
            this.L_Operation.Size = new System.Drawing.Size(119, 27);
            this.L_Operation.TabIndex = 8;
            this.L_Operation.Text = "Operation:";
            this.L_Operation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // L_Result
            // 
            this.L_Result.Location = new System.Drawing.Point(12, 125);
            this.L_Result.Name = "L_Result";
            this.L_Result.Size = new System.Drawing.Size(119, 27);
            this.L_Result.TabIndex = 9;
            this.L_Result.Text = "Result:";
            this.L_Result.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 213);
            this.Controls.Add(this.L_Result);
            this.Controls.Add(this.L_Operation);
            this.Controls.Add(this.L_FO);
            this.Controls.Add(this.L_SO);
            this.Controls.Add(this.B_Calculate);
            this.Controls.Add(this.TB_Result);
            this.Controls.Add(this.TB_SecondOperand);
            this.Controls.Add(this.TB_Operation);
            this.Controls.Add(this.TB_FirstOperand);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form1";
            this.Text = "Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TB_FirstOperand;
        private System.Windows.Forms.TextBox TB_Operation;
        private System.Windows.Forms.TextBox TB_Result;
        private System.Windows.Forms.TextBox TB_SecondOperand;
        private System.Windows.Forms.Button B_Calculate;
        private System.Windows.Forms.Label L_SO;
        private System.Windows.Forms.Label L_FO;
        private System.Windows.Forms.Label L_Operation;
        private System.Windows.Forms.Label L_Result;
    }
}

