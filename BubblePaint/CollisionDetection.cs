using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;

namespace BubblePaint
{
    public static class CollisionDetection
    {
        public static bool IsCollisionCircleLine(Circle circle, Vector2 lineStart, Vector2 lineEnd)
        {
            Vector2 p1 = lineStart - circle.Center;
            Vector2 p2 = lineEnd - circle.Center;

            Vector2 deltaLine = lineEnd - lineStart;
            //составляем коэффициенты квадратного уравнения на пересечение прямой и окружности.
            //если на отрезке [0..1] есть отрицательные значения, значит отрезок пересекает окружность
            float a = deltaLine.X * deltaLine.X + deltaLine.Y * deltaLine.Y;
            float b = 2 * (p1.X * deltaLine.X + p1.Y * deltaLine.Y);
            float c = p1.X * p1.X + p1.Y * p1.Y - circle.Radius * circle.Radius;

            //а теперь проверяем, есть ли на отрезке [0..1] решения
            if (-b < 0)
            {
                return (c < 0);
            }
            if (-b < (2 * a))
            {
                return ((4 * a * c - b * b) < 0);
            }

            return (a + b + c < 0);
        }
    }
}
