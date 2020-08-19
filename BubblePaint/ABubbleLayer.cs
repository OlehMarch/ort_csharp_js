using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

using OpenTK;

namespace BubblePaint
{
    public abstract class ABubbleLayer : UserControl
    {
        protected const int RADIUS = 10;
        protected Graphics graphics;
        protected List<Circle> circles;
        protected Vector2 directionStart;
        protected RectangleBorder border;

        public ABubbleLayer()
        {

        }

        protected void UpdateScreen()
        {
            ClearLayer();
            foreach (var circle in circles)
            {
                circle.Move();
                CheckForCollisions(circle);
                circle.Draw(graphics);
            }
        }

        protected void ClearLayer()
        {
            graphics.Clear(Color.White);
        }

        public virtual void CheckForCollisions(Circle circle)
        {
            circle.CheckForBorderCollision(border);
            circle.CheckForCircleCollision(circles);
        }
    }

}
