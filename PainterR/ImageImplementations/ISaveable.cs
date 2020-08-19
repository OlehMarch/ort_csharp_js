using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Paint
{
    public interface ISaveable
    {
        void SaveToFile(string path, Image img);
        void LoadFromFile(string path, Graphics g1);
    }
}
