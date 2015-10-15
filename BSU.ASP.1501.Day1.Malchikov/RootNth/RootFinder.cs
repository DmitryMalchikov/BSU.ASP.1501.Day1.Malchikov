using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RootNth
{
    public class RootFinder
    {
        public static double FindRoot(double number, double pow, double accuracy)
        {
            if (pow == 1) return number;
            
            double xn = 0;
            for (double x = number / 2; ; x = xn )
            {
                xn = (1 / pow) * ((pow - 1) * x + number / Math.Pow(x, pow - 1));
                if (Math.Abs(x - xn) < accuracy) break;
            }
            return xn;

        }

    }
}
