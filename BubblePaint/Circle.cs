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
    public sealed class Circle
    {
        public int Radius { set; get; }
        public Vector2 Center { set; get; }
        public Vector2 Direction { set; get; }
        public Color Color { set; get; }
        public int Speed { set; get; }

        public void Draw(Graphics g)
        {
            float x = Center.X + Radius, y = Center.Y + Radius;
            float diameter = Radius * 2;
            g.DrawEllipse(new Pen(Color, 2.0f), x, y, diameter, diameter);
        }

        public void Move()
        {
            Center += Direction * Speed;
        }

        public void CheckForBorderCollision(RectangleBorder border)
        {
            if (CollisionDetection.IsCollisionCircleLine(this, border.LeftStart, border.LeftEnd))
            {
                this.Direction = GetReflection(Direction, NormalizeVector(new Vector2(1, 0)));
            }
            else if (CollisionDetection.IsCollisionCircleLine(this, border.RightStart, border.RightEnd))
            {
                this.Direction = GetReflection(Direction, NormalizeVector(new Vector2(-1, 0)));
            }
            else if (CollisionDetection.IsCollisionCircleLine(this, border.TopStart, border.TopEnd))
            {
                this.Direction = GetReflection(Direction, NormalizeVector(new Vector2(0, -1)));
            }
            else if (CollisionDetection.IsCollisionCircleLine(this, border.BottomStart, border.BottomEnd))
            {
                this.Direction = GetReflection(Direction, NormalizeVector(new Vector2(0, 1)));
            }
        }

        public void CheckForCircleCollision(IEnumerable<Circle> circles)
        {
            foreach (var circle2 in circles)
            {
                if (this.Equals(circle2))
                    continue;

                float vecDistance = VectorMagnitude(circle2.Center - this.Center);
                int sumRadius = this.Radius + circle2.Radius;
                if (vecDistance <= sumRadius)
                {
                    var normal = this.Center - circle2.Center;
                    normal = NormalizeVector(ref normal);
                    this.Direction = GetReflection(this.Direction, normal);
                }
            }
        }

        public Circle(Vector2 center, int radius, Vector2 direction, Color color)
        {
            this.Center = center;
            this.Radius = radius;
            this.Direction = NormalizeVector(ref direction);
            this.Color = color;
            this.Speed = 2;
        }

        public Vector2 GetReflection(Vector2 incidentVec, Vector2 normalVec)
        {
            Vector2 reflectVec;
            normalVec = -normalVec;
            reflectVec = incidentVec - 2 * normalVec * DotProduct(incidentVec, normalVec);
            return reflectVec;
        }

        private float DotProduct(Vector2 left, Vector2 right)
        {
            return left.X*right.X + left.Y*right.Y;
        }

        private float VectorMagnitude(Vector2 vec)
        {
            return Convert.ToSingle(Math.Sqrt(vec.X*vec.X + vec.Y*vec.Y));
        }

        private Vector2 NormalizeVector(Vector2 vec)
        {
            return new Vector2(vec/VectorMagnitude(vec));
        }

        private Vector2 NormalizeVector(ref Vector2 vec)
        {
            return NormalizeVector(vec);
        }
    }
}
