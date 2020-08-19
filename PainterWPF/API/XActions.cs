using Microsoft.Win32;
using PainterWPF.API.IO;
using PainterWPF.Dialogs;
using PainterWPF.UserControls.VectorElements;
using PainterWPF.UserControls.VectorElements.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace PainterWPF.API
{
    public class ActionWidth : ICmd
    {
        public ActionWidth(XCommand cmd)
        {
            this.cmd = cmd;
        }
        public ActionWidth(CanvasVector canvas)
        {
            this.canvasVector = canvas;
        }
        public override void Action(object sender, EventArgs e)
        {
            WidthDialog dlg = new WidthDialog();
            dlg.ShowDialog();
            float value = dlg.GetWidth();

            cmd.canvasVector.data.LineWidth = value;
            if (cmd.canvasVector.StackControl != null)
            {
                cmd.canvasVector.StackControl.data.LineWidth = value;
                cmd.canvasVector.StackControl.DrawFigure(cmd.canvasVector.StackControl.data.Type);
            }
        }
    }
    public class ActionColor : ICmd
    {
        public ActionColor(XCommand cmd)
        {
            this.cmd = cmd;
        }
        public ActionColor(CanvasVector canvas)
        {
            this.canvasVector = canvas;
        }
        public override void Action(object sender, EventArgs e)
        {
            using (System.Windows.Forms.ColorDialog dlg = new System.Windows.Forms.ColorDialog())
            {
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Color wpfColor = Color.FromArgb(dlg.Color.A, dlg.Color.R, dlg.Color.G, dlg.Color.B);
                    cmd.canvasVector.data.LineColor = wpfColor;
                    if (cmd.canvasVector.StackControl != null)
                    {
                        cmd.canvasVector.StackControl.data.LineColor = wpfColor;
                        cmd.canvasVector.StackControl.DrawFigure(cmd.canvasVector.StackControl.data.Type);
                    }
                }
            }
        }
    }
    public class ActionType : ICmd
    {
        public ActionType(XCommand cmd)
        {
            this.cmd = cmd;
        }
        public ActionType(CanvasVector canvas)
        {
            this.canvasVector = canvas;
        }
        public override void Action(object sender, EventArgs e)
        {
            ShapeTypeDialog dlg = new ShapeTypeDialog();
            dlg.ShowDialog();
            ShapeType type = dlg.GetShapeType();

            if (cmd.canvasVector != null)
            {
                cmd.canvasVector.data.Type = type;
                if (cmd.canvasVector.StackControl != null)
                {
                    cmd.canvasVector.StackControl.data.Type = type;
                    cmd.canvasVector.StackControl.DrawFigure(type);
                }
            }
        }
    }
    public class ActionSave : ICmd
    {
        public ActionSave(XCommand cmd)
        {
            this.cmd = cmd;
        }
        public ActionSave(CanvasVector canvas)
        {
            this.canvasVector = canvas;
        }
        public override void Action(object sender, EventArgs e)
        {
            try
            {
                List<UIElement> controls = cmd.canvasVector.GetMemento();

                SaveFileDialog saveFD = new SaveFileDialog();
                saveFD.Filter = "JSON (*.json)|*.json|CSV (*.csv)|*.csv|XML (*.xml)|*.xml|YML (*.yml)|*.yml";
                bool? res = saveFD.ShowDialog();

                if (res == true)
                {
                    // TODO: save file
                    IFigureIO f = FigureIO_Selector.GetInstance(saveFD.FileName.Remove(0, saveFD.FileName.LastIndexOf('.') + 1));
                    f.PathToFile = saveFD.FileName;
                    f.Write(controls);
                }

                // need to close dialog after saving
            }
            catch { }
        }
    }
    public class ActionLoad : ICmd
    {
        public string fileName = null;
        public static UIElement[] elems;
        public ActionLoad(XCommand cmd)
        {
            this.cmd = cmd;
        }
        public ActionLoad(CanvasVector canvas)
        {
            this.canvasVector = canvas;
        }
        public static void Draw(UIElement[] elems, XCommand cmd)
        {

            cmd.canvasVector = TabControlVector.tabCanvases[TabControlVector.nameLast];
            foreach (var item in elems)
            {
                cmd.canvasVector.canvas.Children.Add(item);
            }


            DrawingVector2DTool.figures = new List<UIElement>();
            for (int i = 0; i < cmd.canvasVector.canvas.Children.Count; ++i)
            {
                SimpleFigures fi = cmd.canvasVector.canvas.Children[i] as SimpleFigures;
                fi.GainFocus += cmd.canvasVector.OnGainFocus;
                fi.LostFocus += cmd.canvasVector.OnLostFocus;
                fi.FigurePaste += cmd.canvasVector.OnFigurePaste;

                DrawingVector2DTool.figures.Add(cmd.canvasVector.canvas.Children[i]);
            }
        }
        public override void Action(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFD = new OpenFileDialog();
                openFD.Filter = "JSON (*.json)|*.json|CSV (*.csv)|*.csv|XML (*.xml)|*.xml|YML (*.yml)|*.yml";
                bool? res = openFD.ShowDialog();

                    IFigureIO f = FigureIO_Selector.GetInstance(openFD.FileName.Remove(0, openFD.FileName.LastIndexOf('.') + 1));
                    fileName = openFD.FileName;
                    f.PathToFile = openFD.FileName;
                    elems = f.Read().ToArray();
            }
            catch { }
        }

    }
}
