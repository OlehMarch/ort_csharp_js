using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Painter.UserControls.VectorElements.Figures;

namespace PainterV.UserControls.VectorElements.Figures
{
    public enum ResizeLocation : int
    {
        LeftTop = 1,
        MiddleTop = 2,
        RightTop = 3,
        LeftMiddle = 4,
        RightMiddle = 5,
        LeftBottom = 6,
        MiddleBottom = 7,
        RightBottom = 8
    }

    public partial class FigureResize : UserControl
    {
        public FigureResize(SimpleFigures ownerControl, ResizeLocation location)
        {
            InitializeComponent();
            this.ownerControl = ownerControl;
            this.ownerControl.Controls.Add(this);
            this.ownerControl.Controls[this.ownerControl.Controls.Count - 1].BringToFront();
            this.location = location;
            this.Size = new Size(20, 20);
            PositionSetUp();
        }


        private ResizeLocation location;
        private SimpleFigures ownerControl;
        private Point prevPoint;


        public void PositionSetUp()
        {
            switch (location)
            {
                case ResizeLocation.LeftTop:
                    this.Left = 0;
                    this.Top = 0;
                    break;
                case ResizeLocation.MiddleTop:
                    this.Left = ownerControl.Size.Width / 2 - this.Size.Width / 2;
                    this.Top = 0;
                    break;
                case ResizeLocation.RightTop:
                    this.Left = ownerControl.Size.Width - this.Size.Width;
                    this.Top = 0;
                    break;
                case ResizeLocation.LeftMiddle:
                    this.Left = 0;
                    this.Top = ownerControl.Size.Height / 2 - this.Size.Height / 2;
                    break;
                case ResizeLocation.RightMiddle:
                    this.Left = ownerControl.Size.Width - this.Size.Width;
                    this.Top = ownerControl.Size.Height / 2 - this.Size.Height / 2;
                    break;
                case ResizeLocation.LeftBottom:
                    this.Left = 0;
                    this.Top = ownerControl.Size.Height - this.Size.Height;
                    break;
                case ResizeLocation.MiddleBottom:
                    this.Left = ownerControl.Size.Width / 2 - this.Size.Width / 2;
                    this.Top = ownerControl.Size.Height - this.Size.Height;
                    break;
                case ResizeLocation.RightBottom:
                    this.Left = ownerControl.Size.Width - this.Size.Width;
                    this.Top = ownerControl.Size.Height - this.Size.Height;
                    break;
            }
        }

        #region Mouse Actions
        private void FigureResize_MouseMove(object sender, MouseEventArgs e)
        {
            if (ownerControl.Selected)
            {
                if (location == ResizeLocation.LeftTop || location == ResizeLocation.RightBottom)
                {
                    Cursor = Cursors.SizeNWSE;
                }
                else if (location == ResizeLocation.RightTop || location == ResizeLocation.LeftBottom)
                {
                    Cursor = Cursors.SizeNESW;
                }
                else if (location == ResizeLocation.MiddleTop || location == ResizeLocation.MiddleBottom)
                {
                    Cursor = Cursors.SizeNS;
                }
                else if (location == ResizeLocation.LeftMiddle || location == ResizeLocation.RightMiddle)
                {
                    Cursor = Cursors.SizeWE;
                }
                else
                {
                    Cursor = Cursors.Hand;
                }
            }
        }

        private void FigureResize_MouseDown(object sender, MouseEventArgs e)
        {
            if (ownerControl.Selected && e.Button == MouseButtons.Left)
            {
                prevPoint = e.Location;
            }
        }

        private void FigureResize_MouseUp(object sender, MouseEventArgs e)
        {
            if (ownerControl.Selected && e.Button == MouseButtons.Left)
            {
                switch (location)
                {
                    case ResizeLocation.LeftTop:
                        ownerControl.Width -= e.Location.X - prevPoint.X;
                        ownerControl.Height -= e.Location.Y - prevPoint.Y;
                        ownerControl.Left += e.Location.X - prevPoint.X;
                        ownerControl.Top += e.Location.Y - prevPoint.Y;
                        break;
                    case ResizeLocation.MiddleTop:
                        ownerControl.Height -= e.Location.Y - prevPoint.Y;
                        ownerControl.Top += e.Location.Y - prevPoint.Y;
                        break;
                    case ResizeLocation.RightTop:
                        ownerControl.Width += e.Location.X - prevPoint.X;
                        ownerControl.Height -= e.Location.Y - prevPoint.Y;
                        ownerControl.Top += e.Location.Y - prevPoint.Y;
                        break;
                    case ResizeLocation.LeftMiddle:
                        ownerControl.Width -= e.Location.X - prevPoint.X;
                        ownerControl.Left += e.Location.X - prevPoint.X;
                        break;
                    case ResizeLocation.RightMiddle:
                        ownerControl.Width += e.Location.X - prevPoint.X;
                        break;
                    case ResizeLocation.LeftBottom:
                        ownerControl.Width -= e.Location.X - prevPoint.X;
                        ownerControl.Height += e.Location.Y - prevPoint.Y;
                        ownerControl.Left -= e.Location.Y - prevPoint.Y;
                        break;
                    case ResizeLocation.MiddleBottom:
                        ownerControl.Height += e.Location.Y - prevPoint.Y;
                        break;
                    case ResizeLocation.RightBottom:
                        ownerControl.Width += e.Location.X - prevPoint.X;
                        ownerControl.Height += e.Location.Y - prevPoint.Y;
                        break;
                }
            }
        }
        #endregion

    }
}
