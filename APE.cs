using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steganography.Analysis
{
    class APE : IAnalysisMethod
    {
         // Произвести анализ
    public double Analyse(ref Bitmap first, ref Bitmap second)
        {
            // Выдать исключение если нет одной или двух картинок
            if (first == null || second == null)
                throw new ArgumentNullException();

            double result = 0;
            int weigh = first.Width;
            int height = first.Height;
            Color color1, color2;
            double tmp = 0;

            // Найти разницу между соответствующими пикселями на картинках
            for (int i = 0; i < weigh; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    tmp = 0;

                    color1 = first.GetPixel(i, j);
                    color2 = second.GetPixel(i, j);

                    tmp += Math.Abs(color1.R - color2.R);
                    tmp += Math.Abs(color1.G - color2.G);
                    tmp += Math.Abs(color1.B - color2.B);

                    result += tmp;
                }
            }

            // Разделить нна результат
            return result / weigh / height;
        }

        public override string ToString()
        {
            return "APE";
        }
    }
}
