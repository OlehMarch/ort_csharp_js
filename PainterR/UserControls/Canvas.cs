using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Paint;
using Paint.UserControls;

namespace Paint.UserControls
{
    public partial class Canvas : UserControl
    {
        private Graphics gToScreen;
        private Bitmap bmp;
        private bool isDrawing;
        private ISaveable slObj;
        private event Action UpdateCanvas;
        private ContextControl context;
        public StatusControl status { set; get; }

        public Canvas()
        {
            InitializeComponent();
            Constructor();
        }

        private void Constructor()
        {
            this.pictureBox1.MouseDown += pictureBox1_MouseDown;
            this.pictureBox1.MouseUp += pictureBox1_MouseUp;
            this.pictureBox1.MouseMove += pictureBox1_MouseMove;
            this.UpdateCanvas += Canvas_UpdateCanvas;

            context = new ContextControl();
            gToScreen = this.CreateGraphics();
            DrawingApi.xData = new XData();
            DrawingApi.SetUp(gToScreen);
        }

        public void SetXCommand(XCommand com)
        {
            context.SetXCommand(com);
        }

        public void SelectIOFormat(int index)
        {
            this.slObj = GetFormatInstance.GetInstance((ImgType)index);
        }

        public bool SaveToFile(string path)
        {
            try
            {
                slObj.SaveToFile(path, bmp);
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                UpdateCanvas();
            }
            return true;
        }

        public bool LoadFromFile(string path)
        {
            try
            {
                slObj.LoadFromFile(path, this.gToScreen);
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                UpdateCanvas();
            }
            return true;
        }

        private void CaseMouseMove(MouseEventArgs e)
        {
            if (DrawingApi.xData.Type == ShapeType.MULTILINE)
            {
                if (isDrawing)
                {
                    DrawingApi.Render(gToScreen, DrawingApi.xData.PrevPoint, new Point(e.X, e.Y));
                    DrawingApi.xData.addPosition(e.Location);
                }
            }
        }

        private void CaseMouseUp(MouseEventArgs e)
        {
            isDrawing = false;
            if (DrawingApi.xData.Type != ShapeType.MULTILINE)
            {
                DrawingApi.Render(gToScreen, DrawingApi.xData.PrevPoint, new Point(e.X, e.Y));
                DrawingApi.xData.addPosition(e.Location);
            }
        }

        private void CaseMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = true;
                DrawingApi.xData.addPosition(e.Location);
            }
            else if (e.Button == MouseButtons.Right)
            {
                context.ShowContextMenu();
            }
        }

        #region Mouse Actions

        void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            CaseMouseMove(e);
            UpdateCanvas();
            status.UpdateStatus(e.X, e.Y);
        }

        void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            CaseMouseUp(e);
        }

        void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            CaseMouseDown(e);
        }

        private void Canvas_UpdateCanvas()
        {
            pictureBox1.Invalidate();
        }

        private void Canvas_SizeChanged(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
            gToScreen = Graphics.FromImage(bmp);
            DrawingApi.SetUp(gToScreen);
        }

        #endregion

    }
}
