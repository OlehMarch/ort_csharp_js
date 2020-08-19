using CutterVisual.API;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CutterVisual
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            canvas = new Canvas(pPackingZone.Size);
            cbPackingTypeList.SelectedIndex = 0;

            pElementStorage.DragEnter += OnDragEnter;
            pElementStorage.DragDrop += OnDragDrop;
            pPackingZone.DragEnter += OnDragEnter;
            pPackingZone.DragDrop += OnDragDrop;

            foreach (Panel item in pElementStorage.Controls)
            {
                item.MouseDown += OnMouseDown;
            }
        }


        private Canvas canvas;
        private RectangleMaster master;
        private Point prevPoint;
        private bool isManual;
        private int maxHeight;


        #region Mementos
        public void SetMemento(IEnumerable<Control> controls)
        {
            pPackingZone.Controls.Clear();
            pPackingZone.Controls.AddRange(controls.ToArray());
        }

        public IEnumerable<Control> GetMemento()
        {
            var container = pElementStorage.Controls.Cast<Control>();
            return container;
        }
        #endregion

        #region ButtonClick Events
        private IEnumerable<Control> PackControls()
        {
            IEnumerable<Control> result = null;
            canvas.AddRange(GetMemento());
            switch (cbPackingTypeList.SelectedIndex)
            {
                case 0:
                    FlowLayoutPackage package = new FlowLayoutPackage();
                    result = package.Pack(canvas);
                    lCoef.Text = package.GetPackingCoefficient(canvas.Size.Height).ToString();
                    break;
                case 1:
                    master = new RectangleMaster(canvas.Rects);
                    result = master.PackRectangles(canvas.Size);
                    lCoef.Text = canvas.GetPackingCoefficient().ToString();
                    break;
                default:
                    break;
            }

            return result;
        }

        private void bAuto_Click(object sender, EventArgs e)
        {
            SetMemento(PackControls().ToArray());
        }

        private void bManual_Click(object sender, EventArgs e)
        {
            isManual = !isManual;
            lCoef.Text = (((float)pPackingZone.Height - (float)maxHeight) / (float)pPackingZone.Height).ToString();
        }
        #endregion

        #region Drag Drop
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (isManual)
            {
                Panel obj = sender as Panel;
                obj.DoDragDrop((sender as Panel), DragDropEffects.Move);
                prevPoint = obj.Location;

                int y = -1;
                int height = 0;
                foreach (Control item in obj.Parent.Controls)
                {
                    if (item.Location.Y > y)
                    {
                        y = item.Location.Y;
                        height = 0;
                    }
                    if (item.Size.Height > height)
                    {
                        height = item.Size.Height;
                    }
                }
                maxHeight = y + height;
            }
        }

        private void OnDragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void OnDragDrop(object sender, DragEventArgs e)
        {
            if (isManual)
            {
                Panel obj = ((Panel)e.Data.GetData(typeof(Panel)));
                obj.Parent = (Panel)sender;
                Point currPoint = obj.Parent.PointToClient(new Point(e.X, e.Y));

                if (!CollisionQuad.IsBoxCollision(obj.Parent.Controls.Cast<Control>(), currPoint))
                {
                    obj.Location = currPoint;
                    canvas.Add(obj);
                }
                else
                {
                    obj.Location = prevPoint;
                }
            }
        }
        #endregion

    }
}
