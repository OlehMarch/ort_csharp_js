using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Paint
{
    public class ImagePNG : ISaveable
    {
        public void LoadFromFile(string path, Graphics g1)
        {
            Bitmap bmp = new Bitmap(path);
            g1.DrawImage(bmp, 0, 0);
        }

        public void SaveToFile(string path, Image img)
        {
            img.Save(path, System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
