using System;
using System.Collections.Generic;
using Timer = System.Timers.Timer;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Android.Graphics;

namespace myNewCalc.Droid
{
    public class Calc_Fragment : Fragment
    {
        private FrameLayout _calc;
        private int _a = 0;
        private int _b = 0;
        private string _op = "";
        private bool _fl = true;
        private TextView _textView;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            _calc = (FrameLayout)inflater.Inflate(Resource.Layout.Calc, container, false);

            int[] numBtnsId = new[]
            {
                Resource.Id.num1_btn,
                Resource.Id.num2_btn,
                Resource.Id.num3_btn,
                Resource.Id.num4_btn,
                Resource.Id.num5_btn,
                Resource.Id.num6_btn,
                Resource.Id.num7_btn,
                Resource.Id.num8_btn,
                Resource.Id.num9_btn,
                Resource.Id.num0_btn
            };

            List<Button> numBtns = new List<Button>();

            foreach (int btnID in numBtnsId)
            {
                numBtns.Add(_calc.FindViewById<Button>(btnID));
            }

            foreach (Button btn in numBtns)
            {
                btn.Click += (sender, args) => buttonNum_Click(sender, args);
            }

            Button btnPlus = _calc.FindViewById<Button>(Resource.Id.add_btn);
            Button btnMinus = _calc.FindViewById<Button>(Resource.Id.sub_btn);
            Button btnMult = _calc.FindViewById<Button>(Resource.Id.mul_btn);
            Button btnDiv = _calc.FindViewById<Button>(Resource.Id.div_btn);
            Button btnEq = _calc.FindViewById<Button>(Resource.Id.equals_btn);

            Button btnBalls = _calc.FindViewById<Button>(Resource.Id.add_balls_btn);
            Button btnClear = _calc.FindViewById<Button>(Resource.Id.clear_btn);
            Button btnTimer = _calc.FindViewById<Button>(Resource.Id.timer_btn);

            _textView = _calc.FindViewById<TextView>(Resource.Id.textView1);

            if (Arguments != null)
            {
                Bundle args = Arguments;
                _textView.Text = args.GetString("res");
            }

            btnPlus.Click += new System.EventHandler(buttonOP_Click);
            btnMinus.Click += new System.EventHandler(buttonOP_Click);
            btnMult.Click += new System.EventHandler(buttonOP_Click);
            btnDiv.Click += new System.EventHandler(buttonOP_Click);

            btnEq.Click += new System.EventHandler(buttonEq_Click);

            btnTimer.Click += delegate
            {
                Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(2000);
                    Bitmap imageBitmap = null;

                    using (var webClient = new WebClient())
                    {
                        var imageBytes = webClient.DownloadData("http://www.123software.ru/wp-content/uploads/2015/10/Bez-imeni-2.png");
                        if (imageBytes != null && imageBytes.Length > 0)
                        {
                            imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                            _calc.FindViewById<ImageView>(Resource.Id.imgView).SetImageBitmap(imageBitmap);
                        }
                    }
                });
            };

            btnBalls.Click += delegate
            {
                FragmentTransaction ft = FragmentManager.BeginTransaction();
                Fragment ballsFr = new BallsFragment();

                Bundle bndl = new Bundle();
                bndl.PutString("res", _textView.Text == "" ? "0" : _textView.Text);

                ballsFr.Arguments = bndl;
                ft.Add(Resource.Id.calcLayout, ballsFr, "ballsFr");
                ft.AddToBackStack(this.Tag);
                ft.Commit();
            };

            btnClear.Click += delegate
            {
                _a = 0;
                _b = 0;
                _op = "";
                _fl = false;
                _textView.Text = "";
                FragmentManager.PopBackStack();
                _calc.FindViewById<ImageView>(Resource.Id.imgView).SetImageBitmap(Bitmap.CreateBitmap(1, 1, Bitmap.Config.Argb8888));
            };

            return _calc;
        }

        private void buttonNum_Click(object sender, EventArgs e)
        {
            var name = ((Button)sender).Text;
            if (_fl && _textView.Text != "0")
            {
                _textView.Text += name;
            }
            else
            {
                _textView.Text = name;
                _fl = true;
            }
        }

        private void buttonOP_Click(object sender, EventArgs e)
        {
            var name = ((Button)sender).Text;
            if (_textView.Text != "")
            {
                _a = Convert.ToInt32(_textView.Text);
            }
            else
            {
                _a = 0;
            }
            _op = name == "+" ? "%28" : name;
            _textView.Text = "";
        }

        private async void buttonEq_Click(object sender, EventArgs e)
        {
            _b = Convert.ToInt32(_textView.Text);
            //string res = MyClass.Calc(_a, _b, _op);
            string res = await HttpCalc.Execute(_a, _b, _op);
            _textView.Text = res;
            _fl = false;
        }
    }
}