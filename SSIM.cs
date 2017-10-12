using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Steganography.Analysis
{
    class SSIM : IAnalysisMethod
    {
         // Произвести анализ
    public double Analyse(ref Bitmap first, ref Bitmap second)
        {
            double result = 0;
            double cheslit = 0;
            double znamenatel = 0;
            double c1 = 0.01 * 255 * 0.01 * 255;
            double c2 = 0.03 * 255 * 0.03 * 255;
            double intens1 = calcIntens(ref first);
            double intens2 = calcIntens(ref second);
            double kontr1=Math.Sqrt(calcKontrst(ref first,intens1));
            double kontr2=Math.Sqrt(calcKontrst( ref second,intens2));
            cheslit = (2 * intens1 * intens2 + c1) * (c2 + 2 * calcKontrstFor2(ref first, ref second, intens1, intens2));
            znamenatel = (intens1 * intens1 + intens2 * intens2 + c1) * (c2 + kontr1 * kontr1 + kontr2 * kontr2);
            result = cheslit / znamenatel;
            return result;
        }


        // Вычислить среднее значение интенсивности
    public double calcIntens(ref Bitmap first)
    {
        double result = 0;
        int weigh = first.Width;
        int height = first.Height;
        Color color1;
        double tmp = 0;

        for (int i = 0; i < weigh; i++)
        {
            for (int j = 0; j < height; j++)
            {
                tmp = 0;

                color1 = first.GetPixel(i, j);

                tmp += color1.R;
                tmp += color1.G;
                tmp +=color1.B;

                result += tmp;
            }
        }

        return result/(weigh*height);
    }

    // Вычислить контрастность
    public double calcKontrst(ref Bitmap first, double intens)
    {
        double result = 0;
        int weigh = first.Width;
        int height = first.Height;
        Color color1;
        double tmp = 0;

        for (int i = 0; i < weigh; i++)
        {
            for (int j = 0; j < height; j++)
            {
                tmp = 0;

                color1 = first.GetPixel(i, j);

                tmp += color1.R;
                tmp += color1.G;
                tmp += color1.B;
                tmp -= intens;
                result += tmp*tmp;
            }
        }

        return result / (weigh * height -1);
    }
    // Вычислить контрастность
    public double calcKontrstFor2(ref Bitmap first, ref Bitmap second, double intens1,double intens2)
    {
        double result = 0;
        int weigh = first.Width;
        int height = first.Height;
        Color color1,color2;
        double tmp = 0;
        double tmp2 = 0;

        for (int i = 0; i < weigh && i<second.Width; i++)
        {
            for (int j = 0; j < height && j<second.Height; j++)
            {
                tmp = 0;
                tmp2 = 0;
                color1 = first.GetPixel(i, j);
                color2 = second.GetPixel(i, j);

                tmp = tmp +color1.R;
                tmp = tmp + color1.G;
                tmp = tmp + color1.B;
                tmp -= intens1;

                tmp2 = tmp2 + color2.R;
                tmp2 = tmp2 + color2.G;
                tmp2 = tmp2 + color2.B;
                tmp2 -= intens2;

                result += tmp * tmp2;
            }
        }

        return result / (weigh * height - 1);
    }
        
        public override string ToString()
        {
            return "SSIM";
        }
    }
    }
