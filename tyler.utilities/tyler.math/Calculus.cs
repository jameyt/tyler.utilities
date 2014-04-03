using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tyler.math
{
    public class Calculus
    {
        /// <summary>
        /// Estimates the definite integral of x.
        /// </summary>
        /// <param name="startingX">
        /// Starting point for the desired definite integeral.
        /// </param>
        /// <param name="endingX">
        /// Ending point for the desired definite integeral.
        /// </param>
        /// <param name="y">
        /// Function of x.
        /// </param>
        /// <param name="segments">
        /// Number of slices of x, the larger the value the smaller the change in x for each calculation.
        /// </param>
        /// <returns>
        /// An estimation of the definite integral of x.
        /// </returns>
        public static double EstimateDefiniteIntegral(Func<double, double> y, double startingX, double endingX, int segments = 1000000)
        {
            double definiteIntegral = 0;
            double deltaX = (endingX - startingX) * 1.0 / segments;
            double previousY = y(startingX);

            for (int i = 0; i < segments; i++)
            {
                double x = deltaX * i + startingX;
                double currentY = y(x);
                definiteIntegral += deltaX * (currentY + previousY) / 2;
                previousY = currentY;
            }

            return definiteIntegral;
        }

        /// <summary>
        /// Estimates the first derivative at a specific x.
        /// </summary>
        /// <param name="y">
        /// Function of x.
        /// </param>
        /// <param name="x">
        /// Value of x for which you want the first derivative.
        /// </param>
        /// <param name="segmentSize">
        /// Specifies how large of a step to take between the given value of x and a previous value of x to measure the change in y.
        /// </param>
        /// <returns>
        /// First derivative
        /// </returns>
        public static double EstimateFirstDerivative(Func<double, double> y, double x, double segmentSize = 1.0/1000000)
        {
            double y1 = y(x - segmentSize);
            double y2 = y(x);

            return (y2 - y1) / (segmentSize);
        }

        /// <summary>
        /// Estimates the second derivative at a specific x.
        /// </summary>
        /// <param name="y">
        /// Function of x.
        /// </param>
        /// <param name="x">
        /// Value of x for which you want the second derivative.
        /// </param>
        /// <param name="segmentSize">
        /// WARNING:
        /// Specifies how large of a step to take between the given value of x and a previous value of x to measure the change in y.
        /// Use default value unless you know what you are doing.  You will lose accuracy quickly if you make this value too small or too large.
        /// </param>
        /// <returns>
        /// Second derivative
        /// </returns>
        public static double EstimateSecondDerivative(Func<double, double> y, double x, double segmentSize = 1.0/1000)
        {
            double y1 = EstimateFirstDerivative(y, x - segmentSize, segmentSize);
            double y2 = EstimateFirstDerivative(y, x, segmentSize);

            return (y2 - y1) / (segmentSize);
        }

        public static Func<double, double> EstimateTangentLine(Func<double, double> y, double x, double segmentSize = 1.0/1000000)
        {
            double firstDerivative = EstimateFirstDerivative(y, x, segmentSize);

            return z => firstDerivative * z;
        }
    }
}
