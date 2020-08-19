using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.Content.Res;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System.Timers;
using Android.Graphics;
using Android.Graphics.Drawables;
using Timer = System.Timers.Timer;
using Android.Views.InputMethods;

namespace myNewCalc.Droid
{
    public class BallsFragment : Fragment
    {
        private int _count = 0;
        private FrameLayout _ball;
        private int _maxX;
        private int _maxY;
        private List<float> _dx, _dy;

        private List<ImageView> _lBalls;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            Rect rect = new Rect();
            this.Activity.Window.DecorView.GetWindowVisibleDisplayFrame(rect);
            int statusBarHeight = rect.Top;

            int dispW = Activity.Window.DecorView.Width; //rect.Width();
            int dispH = Activity.Window.DecorView.Height; //rect.Height();


            _ball = (FrameLayout)inflater.Inflate(Resource.Layout.Balls, container, false);

            _lBalls = new List<ImageView>();

            if (Arguments != null)
            {
                Bundle args = Arguments;
                _count = Convert.ToInt16(args.GetString("res"));
            }

            _dx = new List<float>();
            _dy = new List<float>();

            _maxX = dispW;
            _maxY = dispH - statusBarHeight;
            Log.Info("BallsFragment  ", " _maxY=" + _maxY + " dispH = " + dispH);

            for (int i = 1; i <= _count; i++)
            {
                ImageView ball = new ImageView(Activity);
                _ball.AddView(ball);
                Random r = new Random();
                int radius = r.Next(20, 100);
                Thread.Sleep(10);
                _dx.Add(r.Next(100));
                _dy.Add(r.Next(100));
                ball.LayoutParameters.Width = radius;
                ball.LayoutParameters.Height = radius;
                ball.SetX(r.Next(_maxX));
                ball.SetY(r.Next(Convert.ToInt16(_maxY)));

                GradientDrawable drw = Resources.GetDrawable(Resource.Drawable.RoundedView) as GradientDrawable;
                drw.SetColor(Color.Argb(r.Next(127, 255), r.Next(255), r.Next(255), r.Next(255)));

                ball.SetImageDrawable(drw);
                ball.SetBackgroundColor(Color.Transparent);

                _lBalls.Add(ball);
            }

            Timer timer = new Timer(50);
            timer.Elapsed += Move;
            timer.Start();

            return _ball;
        }

        public void Move(object sender, ElapsedEventArgs e)
        {
            Activity.RunOnUiThread(() =>
            {
                for (int i = 0; i < _lBalls.Count; i++)
                {
                    int w = _lBalls[i].Width;
                    float x = _lBalls[i].GetX();
                    float y = _lBalls[i].GetY();
                    if (x < 0 || x > _maxX - w) _dx[i] = -_dx[i];
                    if (y < 0 || y > _maxY - w) _dy[i] = -_dy[i];
                    x += _dx[i];
                    y += _dy[i];

                    _lBalls[i].SetX(x);
                    _lBalls[i].SetY(y);
                    _ball.Invalidate();
                }
            });
        }
    }
}