using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Paint.UserControls;

namespace Paint.UserControls
{
    public partial class StatusControl : UserControl
    {
        public StatusControl()
        {
            InitializeComponent();
        }

        public Canvas canvas { set; get; }

        private void FillStatusLabels(int x, int y)
        {
            var coordinates = String.Format("X({0}), Y({1})", x, y);
            var color = DrawingApi.xData.LineColor.ToString();
            var width = DrawingApi.xData.LineWidth.ToString();
            var type = DrawingApi.xData.Type.ToString();
            this.toolLabelCoordinates.Text = coordinates;
            this.toolLabelColor.Text = color;
            this.toolLabelWidth.Text = width;
            this.toolLabelShapeType.Text = type;
        }

        public void UpdateStatus(int x, int y)
        {
            FillStatusLabels(x, y);
        }
    }
}
