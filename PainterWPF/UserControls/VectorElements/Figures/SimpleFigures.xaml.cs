using PainterWPF.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using PainterWPF.API.Figures;

namespace PainterWPF.UserControls.VectorElements.Figures
{
    /// <summary>
    /// Логика взаимодействия для SimpleFigures.xaml
    /// </summary>
    public partial class SimpleFigures : UserControl
    {
        public SimpleFigures(Thickness position, XData data)
        {
            InitializeComponent();
            InitializeComponentData(position, data);
            DrawFigure(data.Type);
            ResizeFiguresCreation();
            ResizeFiguresHide();
        }


        #region Defines
        public XData data;
        private Point prevPoint;
        private const int OFFSET_SIZE = 2;
        public bool isInMove;
        public bool isInResize;

        public bool Selected { get; set; }
        public event EventHandler GainFocus;
        public new event EventHandler LostFocus;
        public event EventHandler FigurePaste;
        #endregion

        #region Common
        private void InitializeComponentData(Thickness position, XData data)
        {
            this.data = data;
            this.BorderBrush = Brushes.Black;
            if (data.Path != null && data.Path.Count != 0)
            {
                List<double> xArray = new List<double>();
                List<double> yArray = new List<double>();

                foreach (var item in data.Path)
                {
                    xArray.Add(item.X);
                    yArray.Add(item.Y);
                }

                int x1 = (int)xArray.Min();
                int y1 = (int)yArray.Min();
                int x2 = (int)xArray.Max();
                int y2 = (int)yArray.Max();
                Point[] path = data.Path.ToArray();

                for (int i = 0; i < data.Path.Count; i++)
                {
                    path[i].X -= x1;
                    path[i].Y -= y1;
                }
                data.Path = path.ToList();

                this.Margin = new Thickness(x1, y1, x2, y2);
            }
            else
            {
                this.Margin = position;
            }
            this.Width = Math.Abs(this.Margin.Right - this.Margin.Left);
            this.Height = Math.Abs(this.Margin.Bottom - this.Margin.Top);
        }

        public void ContextMenuSetUp(XCommand cmd)
        {
            ContextMenu_Color.Click += new RoutedEventHandler(cmd.aColor.Action);
            ContextMenu_PenWidth.Click += new RoutedEventHandler(cmd.aWidth.Action);
            ContextMenu_ShapeType.Click += new RoutedEventHandler(cmd.aType.Action);
        }

        public void DeselectControl()
        {
            this.Selected = false;
            this.BorderThickness = new Thickness(0);
            this.Cursor = Cursors.Arrow;
            ResizeFiguresHide();
        }

        public void ClearCanvas()
        {
            Shape[] shape = this.canvas.Children.OfType<Shape>().ToArray();
            if (shape != null && shape.Length != 0)
            {
                this.canvas.Children.Remove(shape[0]);
            }
        }
        #endregion

        #region Drawing
        public void DrawFigure(ShapeType type)
        {
            try
            {
                ClearCanvas();
                Shape shape = null;
                switch (type)
                {
                    case ShapeType.LINE:
                        shape = new Line()
                        {
                            X1 = 0 + data.LineWidth / 2,
                            Y1 = 0 + data.LineWidth / 2,
                            X2 = this.Width - data.LineWidth / 2,
                            Y2 = this.Height - data.LineWidth / 2
                        };
                        break;

                    case ShapeType.ELLIPSE:
                        shape = new Ellipse();
                        break;

                    case ShapeType.RECTANGLE:
                        shape = new Rectangle();
                        break;

                    case ShapeType.CRECTANGLE:
                        shape = new Rectangle()
                        {
                            RadiusX = 10,
                            RadiusY = 10
                        };
                        break;

                    case ShapeType.MULTILINE:
                        shape = new Polyline
                        {
                            Points = new PointCollection(data.Path)
                        };
                        break;

                    default:
                        throw new ArgumentException();
                }

                shape.Stroke = new SolidColorBrush(data.LineColor);
                shape.StrokeThickness = data.LineWidth;
                shape.StrokeStartLineCap = PenLineCap.Round;
                shape.StrokeEndLineCap = PenLineCap.Round;

                shape.Width = this.Width;
                shape.Height = this.Height;

                shape.Margin = new Thickness(
                    0,
                    0,
                    shape.Width - data.LineWidth * 2,
                    shape.Height - data.LineWidth * 2
                );

                canvas.Children.Add(shape);
            }
            catch { }
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
            foreach (FigureResize item in this.canvas.Children.OfType<FigureResize>())
            {
                item.Visibility = Visibility.Visible;
                Canvas.SetZIndex(item, (int)99);
            }
        }

        private void ResizeFiguresHide()
        {
            foreach (FigureResize item in this.canvas.Children.OfType<FigureResize>())
            {
                item.Visibility = Visibility.Collapsed;
            }
        }
        #endregion

        #region Mouse Events
        private void canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Selected && e.ChangedButton == MouseButton.Left && e.LeftButton == MouseButtonState.Pressed)
            {
                prevPoint = e.GetPosition(canvas);
                isInMove = true;
            }
        }

        private void canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (Selected && e.ChangedButton == MouseButton.Left && e.LeftButton == MouseButtonState.Released)
            {
                isInMove = false;
            }

            if (e.ChangedButton == MouseButton.Middle && e.MiddleButton == MouseButtonState.Released)
            {
                Selected = !Selected;

                if (Selected)
                {
                    this.BorderThickness = new Thickness(1);
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

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (Selected)
            {
                Cursor = Cursors.Hand;
                if (isInResize == true)
                {
                    return;
                }
                if (isInMove == true)
                {
                    Point currPoint = e.GetPosition(canvas);
                    double offsetX = currPoint.X - prevPoint.X;
                    double offsetY = currPoint.Y - prevPoint.Y;
                    this.Margin = new Thickness(
                        this.Margin.Left + offsetX,
                        this.Margin.Top + offsetY,
                        this.Margin.Right + offsetX,
                        this.Margin.Bottom + offsetY
                    );
                }
                
            }
        }
        #endregion

        #region Key Events
        private void canvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (Selected)
            {
                if (e.Key == Key.Up && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                {
                    this.Margin = new Thickness(
                        this.Margin.Left,
                        this.Margin.Top - OFFSET_SIZE,
                        this.Margin.Right,
                        this.Margin.Bottom
                    );
                    this.Height += OFFSET_SIZE;
                }
                else if (e.Key == Key.Up)
                {
                    this.Margin = new Thickness(
                        this.Margin.Left,
                        this.Margin.Top - OFFSET_SIZE,
                        this.Margin.Right,
                        this.Margin.Bottom - OFFSET_SIZE
                    );
                }
        ///////////////////////////////////////////////////////////////
                else if (e.Key == Key.Down && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                {
                    this.Margin = new Thickness(
                        this.Margin.Left,
                        this.Margin.Top,
                        this.Margin.Right,
                        this.Margin.Bottom + OFFSET_SIZE
                    );
                    this.Height += OFFSET_SIZE;
                }
                else if (e.Key == Key.Down)
                {
                    this.Margin = new Thickness(
                        this.Margin.Left,
                        this.Margin.Top + OFFSET_SIZE,
                        this.Margin.Right,
                        this.Margin.Bottom + OFFSET_SIZE
                    );
                }
        ///////////////////////////////////////////////////////////////
                else if (e.Key == Key.Left && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                {
                    this.Margin = new Thickness(
                        this.Margin.Left - OFFSET_SIZE,
                        this.Margin.Top,
                        this.Margin.Right,
                        this.Margin.Bottom
                    );
                    this.Width += OFFSET_SIZE;
                }
                else if (e.Key == Key.Left)
                {
                    this.Margin = new Thickness(
                        this.Margin.Left - OFFSET_SIZE,
                        this.Margin.Top,
                        this.Margin.Right - OFFSET_SIZE,
                        this.Margin.Bottom
                    );
                }
        ///////////////////////////////////////////////////////////////
                else if (e.Key == Key.Right && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                {
                    this.Margin = new Thickness(
                        this.Margin.Left,
                        this.Margin.Top,
                        this.Margin.Right + OFFSET_SIZE,
                        this.Margin.Bottom
                    );
                    this.Width += OFFSET_SIZE;
                }
                else if (e.Key == Key.Right)
                {
                    this.Margin = new Thickness(
                        this.Margin.Left + OFFSET_SIZE,
                        this.Margin.Top,
                        this.Margin.Right + OFFSET_SIZE,
                        this.Margin.Bottom
                    );
                }
        ///////////////////////////////////////////////////////////////
                else if (e.Key == Key.C && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                {
                    Figure f = new Figure();
                    f.Bounds = this.Margin;
                    f.PenWidth = this.data.LineWidth;
                    f.Color = new byte[] { this.data.LineColor.A, this.data.LineColor.R, this.data.LineColor.G, this.data.LineColor.B };
                    f.Path = this.data.Path.ToArray();
                    f.ShapeType = this.data.Type;
                    Clipboard.SetData("FigureFormat", f);
                }
                else if (e.Key == Key.V && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                {
                    this.FigurePaste(Clipboard.GetData("FigureFormat") as Figure, null); 
                }
            }
        }
        #endregion

        private void canvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (data.Type == ShapeType.MULTILINE)
            {
                this.canvas.Children.Remove(this.canvas.Children.OfType<Shape>().ToArray()[0]);
            }
            DrawFigure(data.Type);
            foreach (FigureResize item in this.canvas.Children.OfType<FigureResize>())
            {
                item.PositionSetUp();
            }
        }
        
    }
}
