using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PainterV.UserControls.Menu
{
    public partial class PropertyPanel : UserControl
    {
        public PropertyPanel()
        {
            InitializeComponent();
        }


        public XCommand Cmd { get; set; }


        public void AttachEventHandlers()
        {
            this.B_Color.Click += new EventHandler(Cmd.aColor.Action);
            this.B_LineWidth.Click += new EventHandler(Cmd.aWidth.Action);
            this.B_ShapeType.Click += new EventHandler(Cmd.aType.Action);
        }

        public void ShowProperties(Point Location, Size Size)
        {
            this.NUD_Location_X.Value = Location.X;
            this.NUD_Location_Y.Value = Location.Y;
            this.NUD_Size_Width.Value = Size.Width;
            this.NUD_Size_Height.Value = Size.Height;
            this.Show();
        }

        public void UpdateLocation(Point Location)
        {
            this.NUD_Location_X.Value = Location.X;
            this.NUD_Location_Y.Value = Location.Y;
        }

        public void UpdateSize(Size Size)
        {
            this.NUD_Size_Width.Value = Size.Width;
            this.NUD_Size_Height.Value = Size.Height;
        }

        #region ValueChanged Handlers
        private void NUD_Location_X_ValueChanged(object sender, EventArgs e)
        {
            if (Cmd != null && Cmd.canvas.StackControl != null && Cmd.canvas.StackControl.Selected == true)
            {
                Cmd.canvas.StackControl.Left = (int)NUD_Location_X.Value;
            }
        }

        private void NUD_Location_Y_ValueChanged(object sender, EventArgs e)
        {
            if (Cmd != null && Cmd.canvas.StackControl != null && Cmd.canvas.StackControl.Selected == true)
            {
                Cmd.canvas.StackControl.Top = (int)NUD_Location_Y.Value;
            }
        }

        private void NUD_Size_Width_ValueChanged(object sender, EventArgs e)
        {
            if (Cmd != null && Cmd.canvas.StackControl != null && Cmd.canvas.StackControl.Selected == true)
            {
                Cmd.canvas.StackControl.Width = (int)NUD_Size_Width.Value;
            }
        }

        private void NUD_Size_Height_ValueChanged(object sender, EventArgs e)
        {
            if (Cmd != null && Cmd.canvas.StackControl != null && Cmd.canvas.StackControl.Selected == true)
            {
                Cmd.canvas.StackControl.Height = (int)NUD_Size_Height.Value;
            }
        }
        #endregion

    }
}
