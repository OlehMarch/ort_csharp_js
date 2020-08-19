using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace BubblePainter
{
    public partial class BubbleFormThread : Form
    {
        private BufferedGraphics _bufGraphics;
        private Thread bubbleThread;

        private List<Ball> balls = new List<Ball>();
        private bool _ballAdded = false;
        private bool IsExecuting = true;
        private object lockBubble = new object();


        public BubbleFormThread()
        {
            InitializeComponent();
            InitializeAndStartThread();
            InitializeGraphics();
        }

        #region Inits
        private void InitializeAndStartThread()
        {
            bubbleThread = new Thread(new ThreadStart(UpdateScreen));
            bubbleThread.Start();
        }

        private void InitializeGraphics()
        {
            BufferedGraphicsContext context = new BufferedGraphicsContext();
            _bufGraphics = context.Allocate(CreateGraphics(), this.ClientRectangle);
            _bufGraphics.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            context.MaximumBuffer = ClientRectangle.Size;
        }
        #endregion

        #region Thread functions
        private void UpdateScreen()
        {
            while (IsExecuting)
            {
                lock (lockBubble)
                {
                    Render();
                }
                Thread.Sleep(10);
            }
            
        }

        private void Render()
        {
            if (balls.Count > 0)
            {
                _bufGraphics.Graphics.Clear(BackColor);

                int size = balls.Count;
                if (!_ballAdded)
                {
                    size--;
                }

                for (int i = 0; i < size; ++i)
                {
                    balls[i].posX += balls[i].dx;
                    balls[i].posY += balls[i].dy;

                    if (balls[i].posX <= 0 || balls[i].posX + balls[i].width >= ClientSize.Width)
                    {
                        balls[i].dx = -balls[i].dx;
                    }
                    if (balls[i].posY <= 0 || balls[i].posY + balls[i].width >= ClientSize.Height)
                    {
                        balls[i].dy = -balls[i].dy;
                    }

                    _bufGraphics.Graphics.DrawEllipse(new Pen(Color.Red, 5), balls[i].posX, balls[i].posY, 30, 30);
                    _bufGraphics.Render();
                }
            }
        }
        #endregion

        #region Resize
        private void BubbleForm_Resize(object sender, EventArgs e)
        {
            lock (lockBubble)
            {
                InitializeGraphics();
            }

            ResetPositions();
        }

        private void ResetPositions()
        {
            foreach (var val in balls)
            {
                if (val.posX + val.width >= ClientSize.Width)
                {
                    val.posX = ClientSize.Width - val.width;
                }

                if (val.posY + val.width >= ClientSize.Height)
                {
                    val.posY = ClientSize.Height - val.width;
                }
            }
        }
        #endregion

        #region Mouse Events
        private void BubbleForm_MouseDown(object sender, MouseEventArgs e)
        {
            _ballAdded = false;
            balls.Add(new Ball(e.X, e.Y));
        }

        private void BubbleForm_MouseUp(object sender, MouseEventArgs e)
        {
            balls[balls.Count - 1].SetDirectionVector(e.X, e.Y);
            lock (lockBubble)
            {
                _bufGraphics.Graphics.DrawEllipse(new Pen(Color.Red, 10), e.X, e.Y, 30, 30);
            }
            _ballAdded = true;
        }

        #endregion

        private void BubbleFormThread_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsExecuting = false;
            bubbleThread.Abort();
            base.Dispose();
        }

    }
}
