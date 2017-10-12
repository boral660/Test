using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Steganography.Analysis
{
    //Structural SIMilarity index
    class NCC : IAnalysisMethod
    {
         // Произвести анализ
    public double Analyse(ref Bitmap first, ref Bitmap second)
        {
            // Выдать исключение, если нет одной или двух картинок
            if (first == null || second == null)
                return 0;

            double tmp = 0;
            double result = 0;
             Color color1, color2;
        // Найти числитель
            double numerator = 0;
              for (int i=0 ; i < first.Width && i<second.Width; i++)
            {
                for (int j=0;j<first.Height && j<second.Height;j++)
                {
                    tmp = 0;

                    color1 = first.GetPixel(i, j);
                    color2 = second.GetPixel(i, j);
                    
                    tmp += color1.R * color2.R;
                    tmp += color1.G * color2.G;
                    tmp += color1.B * color2.B;

                    numerator += tmp;
                }
            }
              double res1 = calcSquare(ref first);
              double res2 = calcSquare(ref second);



              return numerator / Math.Sqrt(res1 * res2) ;
        }

    private double calcSquare(ref Bitmap first)
    {
        double result = 0;
        double tmp = 0;
        Color color;

        for (int i = 0; i < first.Width; i++)
        {
            for (int j = 0; j < first.Height; j++)
            {
                tmp = 0;

                color = first.GetPixel(i, j);
                tmp += color.R * color.R;
                tmp += color.G * color.G;
                tmp += color.B * color.B;

                result += tmp;
            }
        }

        return result;
    }

        public override string ToString()
        {
            return "NCC";
        }
    }
    }
