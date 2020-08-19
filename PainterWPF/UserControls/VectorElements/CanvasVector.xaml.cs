using PainterWPF.API;
using PainterWPF.API.Figures;
using PainterWPF.UserControls.Menu;
using PainterWPF.UserControls.VectorElements.Figures;
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

namespace PainterWPF.UserControls.VectorElements
{
    /// <summary>
    /// Логика взаимодействия для CanvasVector.xaml
    /// </summary>
    public partial class CanvasVector : UserControl
    {
        public CanvasVector()
        {
            InitializeComponent();
            data = new XData();
        }


        #region Defines
        private bool isDrawing;
        public XData data;
        public SimpleFigures StackControl;
        public XCommand cmd;
        public event MouseEventHandler CanvasMouseMove;
        #endregion


        #region Common
        public void SetCanvasMouseMoveEventHandler(StatusBarVector status)
        {
            CanvasMouseMove += status.Canvas_MouseMove;
        }
        #endregion

        #region Focus & ControlPaste Events
        public void OnGainFocus(object sender, EventArgs e)
        {
            SimpleFigures obj = sender as SimpleFigures;
            OnLostFocus(StackControl, null);
            StackControl = obj;
            StackControl.Focusable = true;
            Keyboard.Focus(StackControl);
            StackControl.Focus();
        }

        public void OnLostFocus(object sender, EventArgs e)
        {
            Keyboard.ClearFocus();
            SimpleFigures obj = sender as SimpleFigures;
            if (obj != null)
            {
                obj.Focusable = false;
                obj.DeselectControl();
            }
            StackControl = null;
        }

        public void OnFigurePaste(object sender, EventArgs e)
        {
            Figure obj = sender as Figure;
            XData newData = new XData();
            newData.LineColor = Color.FromArgb(obj.Color[0], obj.Color[1], obj.Color[2], obj.Color[3]);
            newData.LineWidth = obj.PenWidth;
            newData.Type = obj.ShapeType;
            newData.Path = obj.Path.ToList();

            SimpleFigures ctrl = (SimpleFigures)DrawingVector2DTool.Render(this,
                    obj.Bounds, newData, cmd);
            ctrl.GainFocus += this.OnGainFocus;
            ctrl.LostFocus += this.OnLostFocus;
            ctrl.FigurePaste += this.OnFigurePaste;

            ctrl.ContextMenu_Color.Click += new RoutedEventHandler(cmd.aColor.Action);
            ctrl.ContextMenu_PenWidth.Click += new RoutedEventHandler(cmd.aWidth.Action);
            ctrl.ContextMenu_ShapeType.Click += new RoutedEventHandler(cmd.aType.Action);
        }
        #endregion

        #region Mementos
        public List<UIElement> GetMemento()
        {
            List<UIElement> collecton = new List<UIElement>();
            foreach (var item in DrawingVector2DTool.figures)
            {
                collecton.Add(item);
            }
            return collecton;
        }
        #endregion

        #region Mouse Actions
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (data.Type == ShapeType.MULTILINE)
            {
                if (isDrawing)
                {
                    Point currPoint = e.GetPosition(canvas);

                    Shape line = new Line
                    {
                        Stroke = new SolidColorBrush(data.LineColor),
                        StrokeThickness = data.LineWidth,
                        X1 = data.PrevPoint.X,
                        Y1 = data.PrevPoint.Y,
                        X2 = currPoint.X,
                        Y2 = currPoint.Y,
                        StrokeStartLineCap = PenLineCap.Round,
                        StrokeEndLineCap = PenLineCap.Round
                    };
                    canvas.Children.Add(line);

                    data.AddPosition(currPoint);
                    data.Path.Add(currPoint);
                }
            }

            CanvasMouseMove(this, e);
        }

        private void canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && e.LeftButton == MouseButtonState.Pressed)
            {
                if (StackControl == null)
                {
                    isDrawing = true;
                }
                data.AddPosition(e.GetPosition(canvas));
                if (data.Type == ShapeType.MULTILINE)
                {
                    data.Path.Add(data.PrevPoint);
                }
            }
        }

        private void canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (StackControl == null && e.ChangedButton == MouseButton.Left && e.LeftButton == MouseButtonState.Released)
            {
                isDrawing = false;

                SimpleFigures ctrl = (SimpleFigures)DrawingVector2DTool.Render(this,
                    new Thickness(data.PrevPoint.X, data.PrevPoint.Y, 
                        e.GetPosition(canvas).X, e.GetPosition(canvas).Y),
                    (XData)data.Clone(), cmd
                );

                ctrl.GainFocus += this.OnGainFocus;
                ctrl.LostFocus += this.OnLostFocus;
                ctrl.FigurePaste += this.OnFigurePaste;

                ctrl.ContextMenu_Color.Click += new RoutedEventHandler(cmd.aColor.Action);
                ctrl.ContextMenu_PenWidth.Click += new RoutedEventHandler(cmd.aWidth.Action);
                ctrl.ContextMenu_ShapeType.Click += new RoutedEventHandler(cmd.aType.Action);

                data.AddPosition(e.GetPosition(canvas));
                if (data.Type == ShapeType.MULTILINE)
                {
                    Line[] lines = this.canvas.Children.OfType<Line>().ToArray();
                    foreach (var item in lines)
                    {
                        this.canvas.Children.Remove(item);
                    }
                    data.Path = new List<Point>();
                }
            }
        }
        #endregion

    }
}
