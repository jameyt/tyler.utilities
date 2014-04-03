using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tyler.math
{
    public class Tests
    {

        /// <summary>
        /// Test that the EstimateDefiniteIntegral function is working sufficiently.
        /// </summary>
        /// <returns>
        /// Average percent error of a set of test integrations.
        /// </returns>
        public static double TestEstimateDefiniteIntegral()
        {
            var percentErrors = new List<double>();

            percentErrors.Add(TestEstimateDefiniteIntegral(x => System.Math.Pow(x, (1.0 / 3.0)), 14.4, 29.1, 40.855));

            percentErrors.Add(TestEstimateDefiniteIntegral(x => System.Math.Pow(x, 0.5), 1.7, 3.1, 2.161));

            percentErrors.Add(TestEstimateDefiniteIntegral(x => System.Math.Pow(x, 2), 8.7, 99.99, 333014));

            percentErrors.Add(TestEstimateDefiniteIntegral(x => System.Math.Pow(x, 3), 1.2, 2.8, 14.85));

            percentErrors.Add(TestEstimateDefiniteIntegral(x => 2 * x, 11.1, 77.7, 5914.08));

            percentErrors.Add(TestEstimateDefiniteIntegral(x => 0.5 * x, 55.1, -22, -638.003));

            percentErrors.Add(TestEstimateDefiniteIntegral(x => 1.0 / x, 1000, 1616, 0.479954));

            percentErrors.Add(TestEstimateDefiniteIntegral(x => System.Math.Sin(x), 1, 6, -0.419868));

            double errorSummer = 0.0;
            int errorCount = 0;

            foreach (var percentError in percentErrors)
            {
                errorSummer += System.Math.Abs(percentError);
                errorCount++;
            }

            double averagePercentError = errorSummer / errorCount;

            return averagePercentError;
        }

        /// <summary>
        /// Test that the EstimateFirstDerivative function is working sufficiently.
        /// </summary>
        /// <returns>
        /// Average percent error of a set of test first derivatives.
        /// </returns>
        public static double TestEstimateFirstDerivative()
        {
            var percentErrors = new List<double>();

            percentErrors.Add(TestEstimateFirstDerivative(x => System.Math.Pow(x, (1.0 / 3.0)), 100, 0.01547196));

            percentErrors.Add(TestEstimateFirstDerivative(x => System.Math.Pow(x, 0.5), 10, 0.158114));

            percentErrors.Add(TestEstimateFirstDerivative(x => System.Math.Pow(x, 2), 72, 144));

            percentErrors.Add(TestEstimateFirstDerivative(x => System.Math.Pow(x, 3), 8.8, 232.32));

            percentErrors.Add(TestEstimateFirstDerivative(x => 2 * x, 1111.1111, 2));

            percentErrors.Add(TestEstimateFirstDerivative(x => 0.5 * x, -888, 0.5));

            percentErrors.Add(TestEstimateFirstDerivative(x => 1.0 / x, 55, -0.0003305785));

            percentErrors.Add(TestEstimateFirstDerivative(x => System.Math.Sin(x), 2, -0.4161468));

            double errorSummer = 0.0;
            int errorCount = 0;

            foreach (var percentError in percentErrors)
            {
                errorSummer += System.Math.Abs(percentError);
                errorCount++;
            }

            double averagePercentError = errorSummer / errorCount;

            return averagePercentError;
        }

        /// <summary>
        /// Test that the EstimateSecondDerivative function is working sufficiently.
        /// </summary>
        /// <returns>
        /// Average percent error of a set of test second derivatives.
        /// </returns>
        public static double TestEstimateSecondDerivative()
        {
            var percentErrors = new List<double>();

            percentErrors.Add(TestEstimateSecondDerivative(x => System.Math.Pow(x, (1.0 / 3.0)), 100, -0.0001031464));

            percentErrors.Add(TestEstimateSecondDerivative(x => System.Math.Pow(x, 0.5), 10, -0.00790569));

            percentErrors.Add(TestEstimateSecondDerivative(x => System.Math.Pow(x, 2), 144, 2));

            percentErrors.Add(TestEstimateSecondDerivative(x => System.Math.Pow(x, 3), 8.8, 52.8));

            percentErrors.Add(TestEstimateSecondDerivative(x => 2 * x, 1111.1111, 0));

            percentErrors.Add(TestEstimateSecondDerivative(x => 0.5 * x, -888, 0));

            percentErrors.Add(TestEstimateSecondDerivative(x => 1.0 / x, 55, 0.0000120210368));

            percentErrors.Add(TestEstimateSecondDerivative(x => System.Math.Sin(x), 2, -0.909297));

            double errorSummer = 0.0;
            int errorCount = 0;

            foreach (var percentError in percentErrors)
            {
                errorSummer += System.Math.Abs(percentError);
                errorCount++;
            }

            double averagePercentError = errorSummer / errorCount;

            return averagePercentError;
        }

        /// <summary>
        /// Test that the EstimateTangentLine function is working sufficiently.
        /// </summary>
        /// <returns>
        /// Average percent error of a set of test tangent lines.
        /// </returns>
        public static double TestEstimateTangentLine()
        {
            var percentErrors = new List<double>();

            percentErrors.Add(TestEstimateTangentLine(x => System.Math.Pow(x, (1.0 / 3.0)), 100, x => 0.01547196 * x));

            percentErrors.Add(TestEstimateTangentLine(x => System.Math.Pow(x, 0.5), 10, x => 0.158114 * x));

            percentErrors.Add(TestEstimateTangentLine(x => System.Math.Pow(x, 2), 72, x => 144 * x));

            percentErrors.Add(TestEstimateTangentLine(x => System.Math.Pow(x, 3), 8.8, x => 232.32 * x));

            percentErrors.Add(TestEstimateTangentLine(x => 2 * x, 1111.1111, x => 2 * x));

            percentErrors.Add(TestEstimateTangentLine(x => 0.5 * x, -888, x => 0.5 * x));

            percentErrors.Add(TestEstimateTangentLine(x => 1.0 / x, 55, x => -0.0003305785 * x));

            percentErrors.Add(TestEstimateTangentLine(x => System.Math.Sin(x), 2, x => -0.4161468 * x));

            double errorSummer = 0.0;
            int errorCount = 0;

            foreach (var percentError in percentErrors)
            {
                errorSummer += System.Math.Abs(percentError);
                errorCount++;
            }

            double averagePercentError = errorSummer / errorCount;

            return averagePercentError;
        }

        /// <summary>
        /// Find the error of the EstimateDefiniteIntegral function for a specific function of x.
        /// </summary>
        /// <param name="y">Function of x.</param>        
        /// <param name="startingX"></param>
        /// <param name="endingX"></param>
        /// <param name="expectedAnswer">Expected integral value.</param>
        /// <param name="segments">Number of slices to take for estimation.  
        /// As the number gets larger the estimate gets more accurate and slower, as the number gets smaller it gets less accurate and faster.
        /// </param>
        /// <returns>
        /// Percent error for the function in question.
        /// </returns>
        private static double TestEstimateDefiniteIntegral(Func<double, double> y, double startingX,
            double startingY, double expectedAnswer, int segments = 1000000)
        {
            double testedIntegral = Calculus.EstimateDefiniteIntegral(y, startingX, startingY, segments);
            double percentError = Arithmetic.CalculatePercentError(testedIntegral, expectedAnswer);

            return percentError;
        }

        /// <summary>
        /// Find the error of the EstimateFirstDerivative function for a specific function of x.
        /// </summary>
        /// <param name="y">Function of x.</param>
        /// <param name="x"></param>
        /// <param name="expectedAnswer"></param>
        /// <param name="segmentSize"></param>
        /// <returns>
        /// Percent error for the function in question.
        /// </returns>
        private static double TestEstimateFirstDerivative(Func<double, double> y, double x,
            double expectedAnswer, double segmentSize = 1.0/1000000)
        {
            double testedIntegral = Calculus.EstimateFirstDerivative(y, x, segmentSize);
            double percentError = Arithmetic.CalculatePercentError(testedIntegral, expectedAnswer);

            return percentError;
        }

        /// <summary>
        /// Find the error of the EstimateSecondDerivative function for a specific function of x.
        /// </summary>
        /// <param name="y">Function of x.</param>
        /// <param name="x"></param>
        /// <param name="expectedAnswer"></param>
        /// <param name="segmentSize"></param>
        /// <returns>
        /// Percent error for the function in question.
        /// </returns>
        private static double TestEstimateSecondDerivative(Func<double, double> y, double x, double expectedAnswer, double segmentSize = 1.0/1000)
        {
            double testedIntegral = Calculus.EstimateSecondDerivative(y, x, segmentSize);

            double percentError = Arithmetic.CalculatePercentError(testedIntegral, expectedAnswer);

            return percentError;
        }

        /// <summary>
        /// Find the error of the EstimateTangentLine function for a specific function of x.
        /// </summary>
        /// <param name="y">
        /// Function of x.
        /// </param>
        /// <param name="x">
        /// Value of x for which you want the tangent line.
        /// </param>
        /// <param name="expectedAnswer">
        /// Expected tangent line function.
        /// </param>
        /// <param name="segmentSize">
        /// Step size for the first derivative calculation.
        /// </param>
        /// <returns>
        /// Percent error of the estimated tangent line when compared to the expected tangent line at 1/2x, x, and 2x.
        /// </returns>
        private static double TestEstimateTangentLine(Func<double, double> y, double x,
            Func<double, double> expectedAnswer, double segmentSize = 1.0/1000000)
        {
            Func<double, double> testedTangentLine = Calculus.EstimateTangentLine(y, x, segmentSize);

            double errorHalfX = Arithmetic.CalculatePercentError(testedTangentLine(x * 0.5), expectedAnswer(x * 0.5));

            double errorX = Arithmetic.CalculatePercentError(testedTangentLine(x), expectedAnswer(x));

            double errorDoubleX = Arithmetic.CalculatePercentError(testedTangentLine(x * 2), expectedAnswer(x * 2));

            return (errorHalfX + errorX + errorDoubleX) / 3;
        }
   

    }
}
