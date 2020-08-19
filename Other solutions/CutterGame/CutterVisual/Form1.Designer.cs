namespace CutterVisual
{
    partial class Form1
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
            this.pPackingZone = new System.Windows.Forms.Panel();
            this.pElementStorage = new System.Windows.Forms.Panel();
            this.cbPackingTypeList = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.bAuto = new System.Windows.Forms.Button();
            this.bManual = new System.Windows.Forms.Button();
            this.lPackingCoef = new System.Windows.Forms.Label();
            this.lCoef = new System.Windows.Forms.Label();
            this.pElementStorage.SuspendLayout();
            this.SuspendLayout();
            // 
            // pPackingZone
            // 
            this.pPackingZone.AllowDrop = true;
            this.pPackingZone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pPackingZone.Location = new System.Drawing.Point(12, 12);
            this.pPackingZone.Name = "pPackingZone";
            this.pPackingZone.Size = new System.Drawing.Size(328, 355);
            this.pPackingZone.TabIndex = 0;
            // 
            // pElementStorage
            // 
            this.pElementStorage.AllowDrop = true;
            this.pElementStorage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pElementStorage.Controls.Add(this.panel5);
            this.pElementStorage.Controls.Add(this.panel4);
            this.pElementStorage.Controls.Add(this.panel3);
            this.pElementStorage.Controls.Add(this.panel2);
            this.pElementStorage.Controls.Add(this.panel1);
            this.pElementStorage.Location = new System.Drawing.Point(346, 12);
            this.pElementStorage.Name = "pElementStorage";
            this.pElementStorage.Size = new System.Drawing.Size(328, 355);
            this.pElementStorage.TabIndex = 1;
            // 
            // cbPackingTypeList
            // 
            this.cbPackingTypeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPackingTypeList.FormattingEnabled = true;
            this.cbPackingTypeList.Items.AddRange(new object[] {
            "FlowLayout",
            "LinearPacking"});
            this.cbPackingTypeList.Location = new System.Drawing.Point(12, 373);
            this.cbPackingTypeList.Name = "cbPackingTypeList";
            this.cbPackingTypeList.Size = new System.Drawing.Size(121, 21);
            this.cbPackingTypeList.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(65, 51);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(238, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(87, 86);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(268, 104);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(57, 92);
            this.panel3.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Location = new System.Drawing.Point(3, 71);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(65, 32);
            this.panel4.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Location = new System.Drawing.Point(99, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(114, 51);
            this.panel5.TabIndex = 1;
            // 
            // bAuto
            // 
            this.bAuto.Location = new System.Drawing.Point(12, 400);
            this.bAuto.Name = "bAuto";
            this.bAuto.Size = new System.Drawing.Size(121, 23);
            this.bAuto.TabIndex = 3;
            this.bAuto.Text = "Auto";
            this.bAuto.UseVisualStyleBackColor = true;
            this.bAuto.Click += new System.EventHandler(this.bAuto_Click);
            // 
            // bManual
            // 
            this.bManual.Location = new System.Drawing.Point(12, 429);
            this.bManual.Name = "bManual";
            this.bManual.Size = new System.Drawing.Size(121, 23);
            this.bManual.TabIndex = 4;
            this.bManual.Text = "Manual";
            this.bManual.UseVisualStyleBackColor = true;
            this.bManual.Click += new System.EventHandler(this.bManual_Click);
            // 
            // lPackingCoef
            // 
            this.lPackingCoef.AutoSize = true;
            this.lPackingCoef.Location = new System.Drawing.Point(180, 380);
            this.lPackingCoef.Name = "lPackingCoef";
            this.lPackingCoef.Size = new System.Drawing.Size(102, 13);
            this.lPackingCoef.TabIndex = 5;
            this.lPackingCoef.Text = "Packing Coefficient:";
            // 
            // lCoef
            // 
            this.lCoef.AutoSize = true;
            this.lCoef.Location = new System.Drawing.Point(183, 400);
            this.lCoef.Name = "lCoef";
            this.lCoef.Size = new System.Drawing.Size(0, 13);
            this.lCoef.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 465);
            this.Controls.Add(this.lCoef);
            this.Controls.Add(this.lPackingCoef);
            this.Controls.Add(this.bManual);
            this.Controls.Add(this.bAuto);
            this.Controls.Add(this.cbPackingTypeList);
            this.Controls.Add(this.pElementStorage);
            this.Controls.Add(this.pPackingZone);
            this.Name = "Form1";
            this.Text = "Form1";
            this.pElementStorage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pPackingZone;
        private System.Windows.Forms.Panel pElementStorage;
        private System.Windows.Forms.ComboBox cbPackingTypeList;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bAuto;
        private System.Windows.Forms.Button bManual;
        private System.Windows.Forms.Label lPackingCoef;
        private System.Windows.Forms.Label lCoef;
    }
}

