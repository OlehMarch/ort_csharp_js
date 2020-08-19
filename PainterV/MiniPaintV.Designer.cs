using PainterV;

namespace Painter
{
    partial class MiniPaintV
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
            cmd = new XCommand();
            this.components = new System.ComponentModel.Container();
            this.TLP_Main = new System.Windows.Forms.TableLayoutPanel();
            this.mainMenu = new PainterV.UserControls.Menu.MainMenuVector(cmd);
            this.toolBar = new PainterV.UserControls.Menu.ToolBarVector(cmd);
            this.toolBox = new PainterV.UserControls.Menu.ToolBoxVector(cmd);
            this.statusBar = new PainterV.UserControls.Menu.StatusBarVector();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.TabContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewPage = new System.Windows.Forms.TabPage();
            this.canvasVector = new Painter.UserControls.VectorElements.CanvasVector();
            this.propertyPanel = new PainterV.UserControls.Menu.PropertyPanel();
            this.TLP_Main.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.TabContextMenu.SuspendLayout();
            this.NewPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // TLP_Main
            // 
            this.TLP_Main.ColumnCount = 3;
            this.TLP_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 137F));
            this.TLP_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.TLP_Main.Controls.Add(this.mainMenu, 0, 0);
            this.TLP_Main.Controls.Add(this.toolBar, 0, 1);
            this.TLP_Main.Controls.Add(this.toolBox, 0, 2);
            this.TLP_Main.Controls.Add(this.statusBar, 0, 3);
            this.TLP_Main.Controls.Add(this.tabControl, 1, 2);
            this.TLP_Main.Controls.Add(this.propertyPanel, 2, 2);
            this.TLP_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_Main.Location = new System.Drawing.Point(0, 0);
            this.TLP_Main.Name = "TLP_Main";
            this.TLP_Main.RowCount = 4;
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP_Main.Size = new System.Drawing.Size(1438, 745);
            this.TLP_Main.TabIndex = 0;
            // 
            // mainMenu
            // 
            this.TLP_Main.SetColumnSpan(this.mainMenu, 3);
            this.mainMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Margin = new System.Windows.Forms.Padding(0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1438, 29);
            this.mainMenu.TabIndex = 0;
            // 
            // toolBar
            // 
            this.TLP_Main.SetColumnSpan(this.toolBar, 3);
            this.toolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolBar.Location = new System.Drawing.Point(0, 29);
            this.toolBar.Margin = new System.Windows.Forms.Padding(0);
            this.toolBar.Name = "toolBar";
            this.toolBar.Size = new System.Drawing.Size(1438, 30);
            this.toolBar.TabIndex = 1;
            // 
            // toolBox
            // 
            this.toolBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolBox.Location = new System.Drawing.Point(3, 62);
            this.toolBox.Name = "toolBox";
            this.toolBox.Size = new System.Drawing.Size(131, 133);
            this.toolBox.TabIndex = 2;
            // 
            // statusBar
            // 
            this.TLP_Main.SetColumnSpan(this.statusBar, 3);
            this.statusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusBar.Location = new System.Drawing.Point(3, 716);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(1432, 26);
            this.statusBar.TabIndex = 4;
            // 
            // tabControl
            // 
            this.tabControl.ContextMenuStrip = this.TabContextMenu;
            this.tabControl.Controls.Add(this.NewPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(140, 62);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1095, 648);
            this.tabControl.TabIndex = 5;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // TabContextMenu
            // 
            this.TabContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.TabContextMenu.Name = "contextMenuStrip1";
            this.TabContextMenu.Size = new System.Drawing.Size(104, 26);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // NewPage
            // 
            this.NewPage.Controls.Add(this.canvasVector);
            this.NewPage.Location = new System.Drawing.Point(4, 22);
            this.NewPage.Name = "NewPage";
            this.NewPage.Padding = new System.Windows.Forms.Padding(3);
            this.NewPage.Size = new System.Drawing.Size(1087, 622);
            this.NewPage.TabIndex = 0;
            this.NewPage.Text = "NewPage";
            this.NewPage.UseVisualStyleBackColor = true;
            // 
            // canvasVector
            // 
            this.canvasVector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvasVector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvasVector.Location = new System.Drawing.Point(3, 3);
            this.canvasVector.Name = "canvasVector";
            this.canvasVector.Size = new System.Drawing.Size(1081, 616);
            this.canvasVector.TabIndex = 4;
            // 
            // propertyPanel
            // 
            this.propertyPanel.Cmd = null;
            this.propertyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyPanel.Location = new System.Drawing.Point(1241, 62);
            this.propertyPanel.Name = "propertyPanel";
            this.propertyPanel.Size = new System.Drawing.Size(194, 648);
            this.propertyPanel.TabIndex = 6;
            this.propertyPanel.Visible = false;
            // 
            // MiniPaintV
            // 
            this.ClientSize = new System.Drawing.Size(1438, 745);
            this.Controls.Add(this.TLP_Main);
            this.Name = "MiniPaintV";
            this.TLP_Main.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.TabContextMenu.ResumeLayout(false);
            this.NewPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion

        public XCommand cmd;
        private System.Windows.Forms.TableLayoutPanel TLP_Main;
        private PainterV.UserControls.Menu.MainMenuVector mainMenu;
        private PainterV.UserControls.Menu.ToolBarVector toolBar;
        private PainterV.UserControls.Menu.ToolBoxVector toolBox;
        private PainterV.UserControls.Menu.StatusBarVector statusBar;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage NewPage;
        private UserControls.VectorElements.CanvasVector canvasVector;
        private System.Windows.Forms.ContextMenuStrip TabContextMenu;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        public PainterV.UserControls.Menu.PropertyPanel propertyPanel;
    }
}

