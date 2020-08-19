using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;

namespace paiting.Droid.Api
{
    public class DrawView : View
    {
        private Path drawPath;
        private Paint drawPaint, canvasPaint;
        private Color paintColor;
        private Canvas drawCanvas;
        private Bitmap canvasBitmap;

        public DrawView(Context ctx) : base(ctx)
        {
            paintColor = Color.Black;
            drawPath = new Path();
            drawPaint = new Paint();
            SetPaintProperties();
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
            canvas.DrawBitmap(canvasBitmap, 0, 0, canvasPaint);
            canvas.DrawPath(drawPath, drawPaint);
        }

        private void SetPaintProperties()
        {
            drawPaint.Color = paintColor;
            drawPaint.AntiAlias = true;
            drawPaint.StrokeWidth = 20;
            drawPaint.SetStyle(Paint.Style.Stroke);
            drawPaint.StrokeJoin = Paint.Join.Round;
            drawPaint.StrokeCap = Paint.Cap.Round;
            canvasPaint = new Paint(PaintFlags.Dither);
        }

        protected override void OnLayout(bool changed, int left, int top, int right, int bottom)
        {
            base.OnLayout(changed, left, top, right, bottom);
            canvasBitmap = Bitmap.CreateBitmap(right - left, bottom - top, Bitmap.Config.Argb8888);
            drawCanvas = new Canvas(canvasBitmap);
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            float touchX = e.GetX();
            float touchY = e.GetY();
            switch (e.Action)
            {
                case MotionEventActions.Down:
                    {
                        drawPath.MoveTo(touchX, touchY);
                        break;
                    }
                case MotionEventActions.Move:
                    {
                        drawPath.LineTo(touchX, touchY);
                        break;
                    }
                case MotionEventActions.Up:
                    {
                        drawCanvas.DrawPath(drawPath, drawPaint);
                        drawPath.Reset();
                        break;
                    }
            }
            Invalidate();
            return true;
        }
    }
}