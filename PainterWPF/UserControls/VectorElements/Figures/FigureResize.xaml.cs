using PainterWPF.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PainterWPF.UserControls.VectorElements.Figures
{
    /// <summary>
    /// Логика взаимодействия для FigureResize.xaml
    /// </summary>
    public partial class FigureResize : UserControl
    {
        public FigureResize(SimpleFigures ownerControl, ResizeLocation location)
        {
            InitializeComponent();
            this.ownerControl = ownerControl;
            this.ownerControl.canvas.Children.Add(this);
            this.location = location;
            this.Width = 20;
            this.Height = 20;
            PositionSetUp();
        }


        private ResizeLocation location;
        private SimpleFigures ownerControl;
        private Point prevPoint;
        private bool isInMove;

        public void PositionSetUp()
        {
            switch (location)
            {
                case ResizeLocation.LeftTop:
                    this.Margin = new Thickness(0, 0, this.Width, this.Height);
                    break;
                case ResizeLocation.MiddleTop:
                    this.Margin = new Thickness(ownerControl.Width / 2 - this.Width / 2, 0, this.Width, this.Height);
                    break;
                case ResizeLocation.RightTop:
                    this.Margin = new Thickness(ownerControl.Width - this.Width, 0, this.Width, this.Height);
                    break;
                case ResizeLocation.LeftMiddle:
                    this.Margin = new Thickness(0, ownerControl.Height / 2 - this.Height / 2, this.Width, this.Height);
                    break;
                case ResizeLocation.RightMiddle:
                    this.Margin = new Thickness(ownerControl.Width - this.Width, ownerControl.Height / 2 - this.Height / 2, this.Width, this.Height);
                    break;
                case ResizeLocation.LeftBottom:
                    this.Margin = new Thickness(0, ownerControl.Height - this.Height, this.Width, this.Height);
                    break;
                case ResizeLocation.MiddleBottom:
                    this.Margin = new Thickness(ownerControl.Width / 2 - this.Width / 2, ownerControl.Height - this.Height, this.Width, this.Height);
                    break;
                case ResizeLocation.RightBottom:
                    this.Margin = new Thickness(ownerControl.Width - this.Width, ownerControl.Height - this.Height, this.Width, this.Height);
                    break;
            }
        }

        #region Mouse Actions
        private void UserControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (ownerControl.Selected)
            {
                #region Changing posotion in order of resize block
                if (isInMove == true)
                {
                    Point currPoint = e.GetPosition(this);
                    switch (location)
                    {
                        case ResizeLocation.LeftTop:
                            ownerControl.Width -= currPoint.X - prevPoint.X;
                            ownerControl.Height -= currPoint.Y - prevPoint.Y;
                            ownerControl.Margin = new Thickness()
                            {
                                Left = ownerControl.Margin.Left + currPoint.X - prevPoint.X,
                                Top = ownerControl.Margin.Top + currPoint.Y - prevPoint.Y,
                                Right = ownerControl.Margin.Right,
                                Bottom = ownerControl.Margin.Bottom,
                            };
                            break;
                        case ResizeLocation.MiddleTop:
                            ownerControl.Height -= currPoint.Y - prevPoint.Y;
                            ownerControl.Margin = new Thickness()
                            {
                                Left = ownerControl.Margin.Left,
                                Top = ownerControl.Margin.Top + currPoint.Y - prevPoint.Y,
                                Right = ownerControl.Margin.Right,
                                Bottom = ownerControl.Margin.Bottom,
                            };
                            break;
                        case ResizeLocation.RightTop:
                            ownerControl.Width += currPoint.X - prevPoint.X;
                            ownerControl.Height -= currPoint.Y - prevPoint.Y;
                            ownerControl.Margin = new Thickness()
                            {
                                Left = ownerControl.Margin.Left,
                                Top = ownerControl.Margin.Top + currPoint.Y - prevPoint.Y,
                                Right = ownerControl.Margin.Right,
                                Bottom = ownerControl.Margin.Bottom,
                            };
                            break;
                        case ResizeLocation.LeftMiddle:
                            ownerControl.Width -= currPoint.X - prevPoint.X;
                            ownerControl.Margin = new Thickness()
                            {
                                Left = ownerControl.Margin.Left + currPoint.X - prevPoint.X,
                                Top = ownerControl.Margin.Top,
                                Right = ownerControl.Margin.Right,
                                Bottom = ownerControl.Margin.Bottom,
                            };
                            break;
                        case ResizeLocation.RightMiddle:
                            ownerControl.Width += currPoint.X - prevPoint.X;
                            break;
                        case ResizeLocation.LeftBottom:
                            ownerControl.Width -= currPoint.X - prevPoint.X;
                            ownerControl.Height += currPoint.Y - prevPoint.Y;
                            ownerControl.Margin = new Thickness()
                            {
                                Left = ownerControl.Margin.Left + currPoint.X - prevPoint.X,
                                Top = ownerControl.Margin.Top,
                                Right = ownerControl.Margin.Right,
                                Bottom = ownerControl.Margin.Bottom,
                            };
                            break;
                        case ResizeLocation.MiddleBottom:
                            ownerControl.Height += currPoint.Y - prevPoint.Y;
                            break;
                        case ResizeLocation.RightBottom:
                            ownerControl.Width += currPoint.X - prevPoint.X;
                            ownerControl.Height += currPoint.Y - prevPoint.Y;
                            break;
                    }
                }
                #endregion

                #region Changing the cursor in order of its posotion
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
                #endregion
            }
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ownerControl.Selected && e.LeftButton == MouseButtonState.Pressed)
            {
                prevPoint = e.GetPosition(this);
                isInMove = true;
                ownerControl.isInResize = true;
            }
        }

        private void UserControl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (ownerControl.Selected && e.LeftButton == MouseButtonState.Released)
            {
                isInMove = false;
                ownerControl.isInResize = false;
            }
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            isInMove = false;
            ownerControl.isInResize = false;
            ownerControl.isInMove = false;
        }
        #endregion

    }
}
