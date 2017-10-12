using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//testы
namespace Steganography.Analysis
{
    public interface IAnalysisMethod
    {
        double Analyse(ref Bitmap first, ref Bitmap second);

        
    }
}
