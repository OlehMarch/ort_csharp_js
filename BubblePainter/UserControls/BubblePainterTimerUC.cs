using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BubblePainter
{
    public partial class BubblePainterTimerUC : UserControl
    {
        class Ball
        {
            public Color color;
            public int width;
            public int posX;
            public int posY;
            public int dx;
            public int dy;
            public int speed;


            public Ball()
            {
                color = Color.Black;
                width = 30;
                posX = 0;
                posY = 0;
                dx = 3;
                dy = 3;
                speed = 10;
            }

            public Ball(int x, int y)
            {
                color = Color.Black;
                width = 30;
                posX = x;
                posY = y;
                dx = 3;
                dy = 3;
                speed = 10;
            }

            public void SetDirectionVector(int x, int y)
            {
                dx = (x - posX) / speed;
                dy = (y - posY) / speed;
            }

        }

        private Timer _timer;
        private BufferedGraphics _bufGraphics;
        private List<Ball> balls = new List<Ball>();
        private bool _ballAdded = false;

        public BubblePainterTimerUC()
        {
            InitializeComponent();
            InitializeGraphics();
            InitializeAndStartTimer();
        }

        #region Inits
        private void InitializeAndStartTimer()
        {
            _timer = new Timer();
            _timer.Tick += Timer_Tick;
            _timer.Interval = 1;
            _timer.Start();
        }

        private void InitializeGraphics()
        {
            BufferedGraphicsContext context = new BufferedGraphicsContext();
            _bufGraphics = context.Allocate(CreateGraphics(), this.ClientRectangle);
            _bufGraphics.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            context.MaximumBuffer = ClientRectangle.Size;
        }
        #endregion

        #region Timer
        private void Timer_Tick(object sender, EventArgs e)
        {
            Render();
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
        private void BubblePainter_Resize(object sender, EventArgs e)
        {
            _timer.Stop();

            InitializeGraphics();

            _timer.Start();

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
        private void BubblePainter_MouseDown(object sender, MouseEventArgs e)
        {
            _ballAdded = false;
            balls.Add(new Ball(e.X, e.Y));
        }

        private void BubblePainter_MouseUp(object sender, MouseEventArgs e)
        {
            balls[balls.Count - 1].SetDirectionVector(e.X, e.Y);
            _bufGraphics.Graphics.DrawEllipse(new Pen(Color.Red, 5), e.X, e.Y, 30, 30);
            _ballAdded = true;
        }
        #endregion

    }
}
