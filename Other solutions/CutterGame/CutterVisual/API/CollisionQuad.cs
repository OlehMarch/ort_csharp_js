using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CutterVisual.API
{
    public class CollisionQuad
    {
        public static bool IsBoxCollision(IEnumerable<Control> controls, Point point)
        {
            foreach (var item in controls)
            {
                if (point.X >= item.Location.X && (item.Location.X + item.Size.Width) >= point.X)
                {
                    if (point.Y >= item.Location.Y && (item.Location.Y + item.Size.Height) >= point.Y)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
