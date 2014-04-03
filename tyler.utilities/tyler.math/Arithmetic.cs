using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tyler.math
{
    internal class Arithmetic
    {

        /// <summary>
        /// Calculates the percent error of the actual value when compared to the expected value.
        /// </summary>
        /// <param name="actual">
        /// Actual value
        /// </param>
        /// <param name="expected">
        /// Expected value
        /// </param>
        /// <returns>
        /// Error as a percentage.
        /// </returns>
        internal static double CalculatePercentError(double actual, double expected)
        {
            double percentError = 0.0;

            if (expected.Equals(0))
            {
                if (actual > 0.001)
                {
                    percentError = (actual / 0.001) * 100;
                }
            }
            else
            {
                percentError = System.Math.Abs(actual - expected) / expected * 100;
            }
            return percentError;
        }

    }
}
