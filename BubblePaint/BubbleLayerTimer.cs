using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenTK;

namespace BubblePaint
{
    public partial class BubbleLayerTimer : ABubbleLayer, IDisposable
    {
        private Timer timer;

        public BubbleLayerTimer()
        {
            InitializeComponent();

            this.MouseUp += BubbleLayer_MouseUp;
            this.MouseDown += BubbleLayer_MouseDown;
            this.Resize += BubbleLayer_Resize;

            graphics = this.CreateGraphics();

            circles = new List<Circle>();
            border = new RectangleBorder(this);
            timer = new Timer();
            timer.Interval = 10;
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void BubbleLayer_Resize(object sender, EventArgs e)
        {
            border = new RectangleBorder(this);
            this.graphics = this.CreateGraphics();
        }

        void BubbleLayer_MouseDown(object sender, MouseEventArgs e)
        {
            directionStart = new Vector2(e.X, e.Y);
        }

        void BubbleLayer_MouseUp(object sender, MouseEventArgs e)
        {
            var circle = new Circle(directionStart, RADIUS, new Vector2(e.X - directionStart.X, e.Y - directionStart.Y), Color.Red);
            circles.Add(circle);
        }

        object lockthis = new object();

        private void timer_Tick(object sender, EventArgs e)
        {
            UpdateScreen();
        }

        public new void Dispose()
        {
            base.Dispose();
            timer.Stop();
            timer.Tick -= timer_Tick;
            timer.Dispose();
            circles.Clear();
            graphics.Dispose(); 
        }
    }
}
