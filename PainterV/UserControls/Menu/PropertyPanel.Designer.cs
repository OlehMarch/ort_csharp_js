namespace PainterV.UserControls.Menu
{
    partial class PropertyPanel
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
            this.TLP_Main = new System.Windows.Forms.TableLayoutPanel();
            this.L_Location = new System.Windows.Forms.Label();
            this.L_Location_X = new System.Windows.Forms.Label();
            this.L_Location_Y = new System.Windows.Forms.Label();
            this.L_Size = new System.Windows.Forms.Label();
            this.L_Size_Width = new System.Windows.Forms.Label();
            this.L_Size_Height = new System.Windows.Forms.Label();
            this.B_Color = new System.Windows.Forms.Button();
            this.B_LineWidth = new System.Windows.Forms.Button();
            this.B_ShapeType = new System.Windows.Forms.Button();
            this.NUD_Location_X = new System.Windows.Forms.NumericUpDown();
            this.NUD_Location_Y = new System.Windows.Forms.NumericUpDown();
            this.NUD_Size_Width = new System.Windows.Forms.NumericUpDown();
            this.NUD_Size_Height = new System.Windows.Forms.NumericUpDown();
            this.Panel_End = new System.Windows.Forms.Panel();
            this.TLP_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Location_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Location_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Size_Width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Size_Height)).BeginInit();
            this.SuspendLayout();
            // 
            // TLP_Main
            // 
            this.TLP_Main.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.TLP_Main.ColumnCount = 2;
            this.TLP_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLP_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_Main.Controls.Add(this.L_Location, 0, 0);
            this.TLP_Main.Controls.Add(this.L_Location_X, 0, 1);
            this.TLP_Main.Controls.Add(this.L_Location_Y, 0, 2);
            this.TLP_Main.Controls.Add(this.L_Size, 0, 3);
            this.TLP_Main.Controls.Add(this.L_Size_Width, 0, 4);
            this.TLP_Main.Controls.Add(this.L_Size_Height, 0, 5);
            this.TLP_Main.Controls.Add(this.B_Color, 0, 6);
            this.TLP_Main.Controls.Add(this.B_LineWidth, 0, 7);
            this.TLP_Main.Controls.Add(this.B_ShapeType, 0, 8);
            this.TLP_Main.Controls.Add(this.NUD_Location_X, 1, 1);
            this.TLP_Main.Controls.Add(this.NUD_Location_Y, 1, 2);
            this.TLP_Main.Controls.Add(this.NUD_Size_Width, 1, 4);
            this.TLP_Main.Controls.Add(this.NUD_Size_Height, 1, 5);
            this.TLP_Main.Controls.Add(this.Panel_End, 0, 9);
            this.TLP_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_Main.Location = new System.Drawing.Point(0, 0);
            this.TLP_Main.Name = "TLP_Main";
            this.TLP_Main.RowCount = 10;
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_Main.Size = new System.Drawing.Size(195, 234);
            this.TLP_Main.TabIndex = 0;
            // 
            // L_Location
            // 
            this.TLP_Main.SetColumnSpan(this.L_Location, 2);
            this.L_Location.Dock = System.Windows.Forms.DockStyle.Fill;
            this.L_Location.Location = new System.Drawing.Point(4, 1);
            this.L_Location.Name = "L_Location";
            this.L_Location.Size = new System.Drawing.Size(187, 23);
            this.L_Location.TabIndex = 0;
            this.L_Location.Text = "Location";
            this.L_Location.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // L_Location_X
            // 
            this.L_Location_X.Dock = System.Windows.Forms.DockStyle.Fill;
            this.L_Location_X.Location = new System.Drawing.Point(4, 25);
            this.L_Location_X.Name = "L_Location_X";
            this.L_Location_X.Size = new System.Drawing.Size(100, 23);
            this.L_Location_X.TabIndex = 1;
            this.L_Location_X.Text = "X:";
            this.L_Location_X.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // L_Location_Y
            // 
            this.L_Location_Y.Dock = System.Windows.Forms.DockStyle.Fill;
            this.L_Location_Y.Location = new System.Drawing.Point(4, 49);
            this.L_Location_Y.Name = "L_Location_Y";
            this.L_Location_Y.Size = new System.Drawing.Size(100, 23);
            this.L_Location_Y.TabIndex = 2;
            this.L_Location_Y.Text = "Y:";
            this.L_Location_Y.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // L_Size
            // 
            this.TLP_Main.SetColumnSpan(this.L_Size, 2);
            this.L_Size.Dock = System.Windows.Forms.DockStyle.Fill;
            this.L_Size.Location = new System.Drawing.Point(4, 73);
            this.L_Size.Name = "L_Size";
            this.L_Size.Size = new System.Drawing.Size(187, 23);
            this.L_Size.TabIndex = 3;
            this.L_Size.Text = "Size";
            this.L_Size.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // L_Size_Width
            // 
            this.L_Size_Width.Dock = System.Windows.Forms.DockStyle.Fill;
            this.L_Size_Width.Location = new System.Drawing.Point(4, 97);
            this.L_Size_Width.Name = "L_Size_Width";
            this.L_Size_Width.Size = new System.Drawing.Size(100, 23);
            this.L_Size_Width.TabIndex = 4;
            this.L_Size_Width.Text = "Width:";
            this.L_Size_Width.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // L_Size_Height
            // 
            this.L_Size_Height.Dock = System.Windows.Forms.DockStyle.Fill;
            this.L_Size_Height.Location = new System.Drawing.Point(4, 121);
            this.L_Size_Height.Name = "L_Size_Height";
            this.L_Size_Height.Size = new System.Drawing.Size(100, 23);
            this.L_Size_Height.TabIndex = 5;
            this.L_Size_Height.Text = "Height:";
            this.L_Size_Height.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // B_Color
            // 
            this.TLP_Main.SetColumnSpan(this.B_Color, 2);
            this.B_Color.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Color.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.B_Color.Location = new System.Drawing.Point(1, 145);
            this.B_Color.Margin = new System.Windows.Forms.Padding(0);
            this.B_Color.Name = "B_Color";
            this.B_Color.Size = new System.Drawing.Size(193, 23);
            this.B_Color.TabIndex = 6;
            this.B_Color.Text = "Change color";
            this.B_Color.UseVisualStyleBackColor = true;
            // 
            // B_LineWidth
            // 
            this.TLP_Main.SetColumnSpan(this.B_LineWidth, 2);
            this.B_LineWidth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_LineWidth.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.B_LineWidth.Location = new System.Drawing.Point(1, 169);
            this.B_LineWidth.Margin = new System.Windows.Forms.Padding(0);
            this.B_LineWidth.Name = "B_LineWidth";
            this.B_LineWidth.Size = new System.Drawing.Size(193, 23);
            this.B_LineWidth.TabIndex = 7;
            this.B_LineWidth.Text = "Change line width";
            this.B_LineWidth.UseVisualStyleBackColor = true;
            // 
            // B_ShapeType
            // 
            this.TLP_Main.SetColumnSpan(this.B_ShapeType, 2);
            this.B_ShapeType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_ShapeType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.B_ShapeType.Location = new System.Drawing.Point(1, 193);
            this.B_ShapeType.Margin = new System.Windows.Forms.Padding(0);
            this.B_ShapeType.Name = "B_ShapeType";
            this.B_ShapeType.Size = new System.Drawing.Size(193, 23);
            this.B_ShapeType.TabIndex = 8;
            this.B_ShapeType.Text = "Change shape type";
            this.B_ShapeType.UseVisualStyleBackColor = true;
            // 
            // NUD_Location_X
            // 
            this.NUD_Location_X.BackColor = System.Drawing.SystemColors.Control;
            this.NUD_Location_X.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NUD_Location_X.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NUD_Location_X.Location = new System.Drawing.Point(111, 28);
            this.NUD_Location_X.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.NUD_Location_X.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            -2147483648});
            this.NUD_Location_X.Name = "NUD_Location_X";
            this.NUD_Location_X.Size = new System.Drawing.Size(80, 16);
            this.NUD_Location_X.TabIndex = 9;
            this.NUD_Location_X.ValueChanged += new System.EventHandler(this.NUD_Location_X_ValueChanged);
            // 
            // NUD_Location_Y
            // 
            this.NUD_Location_Y.BackColor = System.Drawing.SystemColors.Control;
            this.NUD_Location_Y.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NUD_Location_Y.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NUD_Location_Y.Location = new System.Drawing.Point(111, 52);
            this.NUD_Location_Y.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.NUD_Location_Y.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            -2147483648});
            this.NUD_Location_Y.Name = "NUD_Location_Y";
            this.NUD_Location_Y.Size = new System.Drawing.Size(80, 16);
            this.NUD_Location_Y.TabIndex = 10;
            this.NUD_Location_Y.ValueChanged += new System.EventHandler(this.NUD_Location_Y_ValueChanged);
            // 
            // NUD_Size_Width
            // 
            this.NUD_Size_Width.BackColor = System.Drawing.SystemColors.Control;
            this.NUD_Size_Width.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NUD_Size_Width.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NUD_Size_Width.Location = new System.Drawing.Point(111, 100);
            this.NUD_Size_Width.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.NUD_Size_Width.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            -2147483648});
            this.NUD_Size_Width.Name = "NUD_Size_Width";
            this.NUD_Size_Width.Size = new System.Drawing.Size(80, 16);
            this.NUD_Size_Width.TabIndex = 11;
            this.NUD_Size_Width.ValueChanged += new System.EventHandler(this.NUD_Size_Width_ValueChanged);
            // 
            // NUD_Size_Height
            // 
            this.NUD_Size_Height.BackColor = System.Drawing.SystemColors.Control;
            this.NUD_Size_Height.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NUD_Size_Height.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NUD_Size_Height.Location = new System.Drawing.Point(111, 124);
            this.NUD_Size_Height.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.NUD_Size_Height.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            -2147483648});
            this.NUD_Size_Height.Name = "NUD_Size_Height";
            this.NUD_Size_Height.Size = new System.Drawing.Size(80, 16);
            this.NUD_Size_Height.TabIndex = 12;
            this.NUD_Size_Height.ValueChanged += new System.EventHandler(this.NUD_Size_Height_ValueChanged);
            // 
            // Panel_End
            // 
            this.TLP_Main.SetColumnSpan(this.Panel_End, 2);
            this.Panel_End.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_End.Location = new System.Drawing.Point(1, 217);
            this.Panel_End.Margin = new System.Windows.Forms.Padding(0);
            this.Panel_End.Name = "Panel_End";
            this.Panel_End.Size = new System.Drawing.Size(193, 16);
            this.Panel_End.TabIndex = 13;
            // 
            // PropertyPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TLP_Main);
            this.Name = "PropertyPanel";
            this.Size = new System.Drawing.Size(195, 234);
            this.TLP_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Location_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Location_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Size_Width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Size_Height)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLP_Main;
        private System.Windows.Forms.Label L_Location;
        private System.Windows.Forms.Label L_Location_X;
        private System.Windows.Forms.Label L_Location_Y;
        private System.Windows.Forms.Label L_Size;
        private System.Windows.Forms.Label L_Size_Width;
        private System.Windows.Forms.Label L_Size_Height;
        private System.Windows.Forms.Button B_Color;
        private System.Windows.Forms.Button B_LineWidth;
        private System.Windows.Forms.Button B_ShapeType;
        private System.Windows.Forms.NumericUpDown NUD_Location_X;
        private System.Windows.Forms.NumericUpDown NUD_Location_Y;
        private System.Windows.Forms.NumericUpDown NUD_Size_Width;
        private System.Windows.Forms.NumericUpDown NUD_Size_Height;
        private System.Windows.Forms.Panel Panel_End;
    }
}
