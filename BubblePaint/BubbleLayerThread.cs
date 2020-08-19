using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using OpenTK;

namespace BubblePaint
{
    public partial class BubbleLayerThread : ABubbleLayer, IDisposable
    {
        private bool IsExecuting;
        private Thread bubbleThread;
        private object lockBubble = new object();

        public BubbleLayerThread()
        {
            InitializeComponent();

            this.MouseUp += BubbleLayer_MouseUp;
            this.MouseDown += BubbleLayer_MouseDown;
            this.Resize += BubbleLayer_Resize;

            base.graphics = this.CreateGraphics();

            base.circles = new List<Circle>();
            base.border = new RectangleBorder(this);
            IsExecuting = true;
            bubbleThread = new Thread(new ThreadStart(ExecuteBubbleThread));
            bubbleThread.Start();
        }

        void BubbleLayer_Resize(object sender, EventArgs e)
        {
            border = new RectangleBorder(this);
            lock (lockBubble)
            {
                this.graphics = this.CreateGraphics();
            }
        }

        void BubbleLayer_MouseDown(object sender, MouseEventArgs e)
        {
            base.directionStart = new Vector2(e.X, e.Y);
        }

        void BubbleLayer_MouseUp(object sender, MouseEventArgs e)
        {
            var circle = new Circle(base.directionStart, RADIUS, new Vector2(e.X - base.directionStart.X, e.Y - base.directionStart.Y), Color.Red);
            lock (lockBubble)
            {
                base.circles.Add(circle);
            }
        }

        private void ExecuteBubbleThread()
        {
            while (IsExecuting)
            {
                lock (lockBubble)
                {
                    base.UpdateScreen();
                }
                System.Threading.Thread.Sleep(10);
            }
        }

        public new void Dispose()
        {
            base.Dispose();
            lock (lockBubble)
            {
                base.circles.Clear();
                graphics.Dispose();
                IsExecuting = false;
            }
        }
    }
}
