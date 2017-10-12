using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steganography.Analysis
{
    class PSNR : MSE
    {
       
       
            public override double Analyse(ref Bitmap first, ref Bitmap second)
            {
                double tmp = 1 / (base.Analyse(ref first, ref second) / (3 * 255 * 255));

                return 10 * Math.Log10(tmp);
            }

            public override string ToString()
            {
                return "PSTR";
            }
        
    }
}
