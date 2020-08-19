using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    public enum ImgType
    {
        PNG,
        BMP,
        JPEG,
        GIF,
        EMF,
        TIFF
    }

    public static class GetFormatInstance
    {
        public static ISaveable GetInstance(ImgType imgT)
        {
            ISaveable obj = null;
            switch (imgT)
            {
                case ImgType.PNG:
                    {
                        obj = new ImagePNG();
                        break;
                    }
                case ImgType.BMP:
                    {
                        obj = new ImageBMP();
                        break;
                    }
                case ImgType.JPEG:
                    {
                        obj = new ImageJPEG();
                        break;
                    }
                case ImgType.GIF:
                    {
                        obj = new ImageGIF();
                        break;
                    }
                case ImgType.EMF:
                    {
                        obj = new ImageEMF();
                        break;
                    }
                case ImgType.TIFF:
                    {
                        obj = new ImageTIFF();
                        break;
                    }
            }
            return obj;
        }
    }


}
