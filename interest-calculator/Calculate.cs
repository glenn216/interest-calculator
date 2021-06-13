using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interest_calculator
{
    class Calculate
    {
        internal static float SimpleInterest(int p, float r, float t)
        {
            float s;
            s = p * r * t;
            return s;
        }

        internal static float SimpleInterestResult(int p, float r, float t)
        {
            float result;
            result = p * (1 + r * t);
            return result;
        }

        internal static float CompoundInterest(int p, int n, float r, float t)
        {
            float tmp1, tmp2, result;
            tmp1 = 1 + (r / n);
            tmp2 = (float)Math.Pow(tmp1, n * t);
            result = p * tmp2;
            return result;
        }
    }
}
