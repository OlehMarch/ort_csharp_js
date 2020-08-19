using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using PainterV;
using Painter.Vector;
using PainterV.UserControls.VectorElements.Figures;
using PainterV.UserControls.Menu;

namespace Painter.UserControls.VectorElements.Figures
{
    public partial class SimpleFigures : UserControl
    {
        public SimpleFigures(Rectangle rect, XData data)
        {
            InitializeComponent();
            InitializeComponentData(rect, data);
            InitializeOnKeyEvents();
            DrawFigure(data.Type);
            ResizeFiguresCreation();
            ResizeFiguresHide();
        }


        #region Defines
        public XData data;

        private Bitmap DrawArea;
        private Point prevPoint;
        private const int OFFSET_SIZE = 2;

        public PropertyPanel PropertyPanel { get; set; }
        public bool Selected { get; set; }
        public event EventHandler GainFocus;
        public new event EventHandler LostFocus;
        public event EventHandler FigurePaste;
        #endregion


        #region Common
        private void InitializeComponentData(Rectangle rect, XData data)
        {
            this.data = data;
            if (data.Path != null && data.Path.Count != 0)
            {
                MultilineSetUp();
            }
            else
            {
                this.Left = rect.X;
                this.Top = rect.Y;
                this.Width = rect.Width;
                this.Height = rect.Height;
            }
        }

        private void InitializeOnKeyEvents()
        {
            this.SetStyle(ControlStyles.Selectable, true);
        }

        public void ContextMenuSetUp(XCommand cmd)
        {
            ContextMenu_Color.Click += new EventHandler(cmd.aColor.Action);
            ContextMenu_PenWidth.Click += new EventHandler(cmd.aWidth.Action);
            ContextMenu_ShapeType.Click += new EventHandler(cmd.aType.Action);
        }

        public void DeselectControl()
        {
            this.Selected = false;
            this.BorderStyle = BorderStyle.None;
            this.Cursor = Cursors.Default;
            ResizeFiguresHide();
        }
        #endregion

        #region Drawing
        public void DrawFigure(ShapeType type)
        {
            try
            {
                DrawArea = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);
                pictureBox.Image = DrawArea;
                Graphics g = Graphics.FromImage(DrawArea);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                Render(g, type);
                g.Dispose();
            }
            catch { }
        }

        private void Render(Graphics g, ShapeType type)
        {
            float offset = data.LineWidth / 2;
            switch (type)
            {
                case ShapeType.LINE:
                    g.DrawLine(new Pen(data.LineColor, data.LineWidth), 
                        0 + offset, 0 + offset, 
                        Width - offset, Height - offset);
                    break;

                case ShapeType.ELLIPSE:
                    g.DrawEllipse(new Pen(data.LineColor, data.LineWidth), 
                        0 + offset, 0 + offset, 
                        Width - data.LineWidth - 1, Height - data.LineWidth - 1);
                    break;

                case ShapeType.RECTANGLE:
                    this.BorderStyle = BorderStyle.None;
                    g.DrawRectangle(new Pen(data.LineColor, 
                        data.LineWidth), 0 + offset, 0 + offset, 
                        Width - data.LineWidth - 1, Height - data.LineWidth - 1);
                    break;

                case ShapeType.CRECTANGLE:
                    this.BorderStyle = BorderStyle.None;
                    DrawCurvedRect(
                        g,
                        new Point((int)(0 + offset), (int)(0 + offset)),
                        new Point((int)(Width - offset - 1), (int)(Height - offset - 1))
                    );
                    break;

                case ShapeType.MULTILINE:
                    g.DrawLines(new Pen(data.LineColor, data.LineWidth), data.Path.ToArray());
                    break;

                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        private void ResizeFiguresCreation()
        {
            for (int i = 1; i <= 8; i++)
            {
                FigureResize resizeFigure = new FigureResize(this, (ResizeLocation)i);
            }
        }

        private void ResizeFiguresShow()
        {
            foreach (FigureResize item in this.Controls.OfType<FigureResize>())
            {
                item.Show();
            }
        }

        private void ResizeFiguresHide()
        {
            foreach (FigureResize item in this.Controls.OfType<FigureResize>())
            {
                item.Hide();
            }
        }
        #endregion

        #region Curved Rect
        private void DrawCurvedRect(Graphics g, Point p1, Point p2)
        {
            Point pStart = Point.Empty;
            Point pEnd = Point.Empty;
            if (p1.X < p2.X || p1.Y < p2.Y)
            {
                pStart = p1;
            }
            else
            {
                pStart = p2;
            }
            if (pStart == p1)
            {
                pEnd = p2;
            }
            else
            {
                pEnd = p1;
            }
            g.DrawPath(
                new Pen(data.LineColor, data.LineWidth),
                CurvedRect(new Rectangle(pStart.X, pStart.Y, pEnd.X - pStart.X, pEnd.Y - pStart.Y), 10)
            );
        }

        private GraphicsPath CurvedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            path.AddArc(arc, 180, 90);

            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
        #endregion

        #region Multiline
        private void MultilineSetUp()
        {
            List<float> xArray = new List<float>();
            List<float> yArray = new List<float>();

            foreach (var item in data.Path)
            {
                xArray.Add(item.X);
                yArray.Add(item.Y);
            }

            int x1 = (int)xArray.Min();
            int y1 = (int)yArray.Min();
            int x2 = (int)xArray.Max();
            int y2 = (int)yArray.Max();
            PointF[] path = data.Path.ToArray();

            for (int i = 0; i < data.Path.Count; i++)
            {
                path[i].X -= x1;
                path[i].Y -= y1;
            }
            data.Path = path.ToList();

            this.Left = x1;
            this.Top = y1;
            this.Width = x2 - x1;
            this.Height = y2 - y1;
        }
        #endregion

        #region Mouse Events
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (Selected && e.Button == MouseButtons.Left)
            {
                prevPoint = e.Location;
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (Selected && e.Button == MouseButtons.Left)
            {
                this.Left += e.Location.X - prevPoint.X;
                this.Top += e.Location.Y - prevPoint.Y;
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (Selected)
            {
                Cursor = Cursors.Hand;
            }
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                Selected = !Selected;

                if (Selected)
                {
                    this.BorderStyle = BorderStyle.FixedSingle;
                    ResizeFiguresShow();
                    this.GainFocus(this, null);
                }
                else
                {
                    ResizeFiguresHide();
                    this.LostFocus(this, null);
                }
            }
        }
        #endregion

        #region Key Events
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (Selected)
            {
                if (keyData == Keys.Up)
                {
                    this.Location = new Point(Location.X, Location.Y - OFFSET_SIZE);
                }
                if (keyData == (Keys.Control | Keys.Up))
                {
                    this.Top -= OFFSET_SIZE;
                    this.Height += OFFSET_SIZE;
                    this.OnResize(null);
                }

                if (keyData == Keys.Down)
                {
                    this.Location = new Point(Location.X, Location.Y + OFFSET_SIZE);
                }
                if (keyData == (Keys.Control | Keys.Down))
                {
                    this.Height += OFFSET_SIZE;
                    this.OnResize(null);
                }

                if (keyData == Keys.Left)
                {
                    this.Location = new Point(Location.X - OFFSET_SIZE, Location.Y);
                }
                if (keyData == (Keys.Control | Keys.Left))
                {
                    this.Left -= OFFSET_SIZE;
                    this.Width += OFFSET_SIZE;
                    this.OnResize(null);
                }

                if (keyData == Keys.Right)
                {
                    this.Location = new Point(Location.X + OFFSET_SIZE, Location.Y);
                }
                if (keyData == (Keys.Control | Keys.Right))
                {
                    this.Size = new Size(this.Width + OFFSET_SIZE, this.Height);
                    this.OnResize(null);
                }
                if (keyData == (Keys.Control | Keys.C))
                {
                    Figure f = new Figure();
                    f.Bounds = this.Bounds;
                    f.PenWidth = this.data.LineWidth;
                    f.Color = this.data.LineColor.ToArgb();
                    f.Path = this.data.Path.ToArray();
                    f.ShapeType = this.data.Type;
                    Clipboard.SetData("FigureFormat", f);
                }
                if (keyData == (Keys.Control | Keys.V))
                {
                    this.FigurePaste(Clipboard.GetData("FigureFormat") as Figure, null);
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        private void pictureBox_SizeChanged(object sender, EventArgs e)
        {
            DrawFigure(data.Type);
            foreach (FigureResize item in this.Controls.OfType<FigureResize>())
            {
                item.PositionSetUp();
            }
            pictureBox.Invalidate();
            if (PropertyPanel != null)
            {
                PropertyPanel.UpdateSize(this.Size);
            }
        }

        private void SimpleFigures_LocationChanged(object sender, EventArgs e)
        {
            if (PropertyPanel != null)
            {
                PropertyPanel.UpdateLocation(this.Location);
            }
        }

        private void ContextMenu_Properties_Click(object sender, EventArgs e)
        {
            if (Selected)
            {
                PropertyPanel.ShowProperties(this.Location, this.Size);
            }
            
        }
        
    }
}
