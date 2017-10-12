using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Steganography.Analysis
{
    class BER : IAnalysisMethod
    {
        // Анализировать
        public double Analyse(ref Bitmap first, ref Bitmap second)
        {
            if (first == null || second == null)
                throw new ArgumentNullException();


            int weigh = first.Width;
            int height = first.Height;
            Color color1, color2;
            int errors = 0;
            // Найти схожесть пикселей
            for (int i = 0; i < weigh; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    color1 = first.GetPixel(i, j);
                    color2 = second.GetPixel(i, j);

                    if (!color1.Equals(color2))
                    {
                        errors++;
                    }
                }
            }

            return ((double)errors) / (weigh * height) * 100;
        }

        public override string ToString()
        {
            return "BER";
        }
    }
}
