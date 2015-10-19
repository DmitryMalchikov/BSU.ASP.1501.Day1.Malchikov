using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RootNth
{
    public class RootFinder
    {
        public static double FindRoot(double number, int pow, double accuracy)
        {
            if (number < 0)
                throw new ArgumentException();
            if (number == 0) return 0;
            if (pow <= 0)
                throw new ArgumentException();
            if (pow == 1) return number;

            
            double xn = 0;
            for (double x = number / 2; ; x = xn )
            {
                xn = (1.0 / pow) * ((pow - 1) * x + number / Math.Pow(x, pow - 1));
                if (Math.Abs(x - xn) < accuracy) break;
            }

            return xn;

        }

    }
}
