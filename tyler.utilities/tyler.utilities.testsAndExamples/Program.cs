using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tyler.math;
using tyler.text;

namespace tyler.utilities.testsAndExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test Comment
            double definiteIntegralAverageError = Tests.TestEstimateDefiniteIntegral();

            double firstDerivativeAverageError = Tests.TestEstimateFirstDerivative();

            double secondDerivativeAverageError = Tests.TestEstimateSecondDerivative();

            double tangentLineAverageError = Tests.TestEstimateTangentLine();

            double newtonsMethodRoot = Solvers.NewtonsMethod(x => System.Math.Pow(x, 2) - 2);

            double newtonsMethodRoot2 = Solvers.NewtonsMethod(x => 2 * x - 1, x => System.Math.Pow(x, 2) - 4);

            double[,] M = new double[3, 4] 
            {
                { 4, 2, 1, 9 }, 
                { 9, 3, 1, 22 }, 
                { 16, 4, 1, 39 } 
            };

            bool pass = LinearAlgebra.GaussianElimination(M);

            var datapoints1 = new List<Datapoint>();
            datapoints1.Add(new Datapoint(2.0, 9.0));
            datapoints1.Add(new Datapoint(3.0, 22.0));
            datapoints1.Add(new Datapoint(4.0, 39));

            var function1 = Solvers.CreateFunction(datapoints1);

            double y0 = function1(0);
            double y1 = function1(1);
            double y2 = function1(2);
            double y3 = function1(3);
            double y4 = function1(4);

            var datapoints2 = new List<Datapoint>();
            datapoints2.Add(new Datapoint(1, 5));
            datapoints2.Add(new Datapoint(2.0, 9.0));

            var function2 = Solvers.CreateFunction(datapoints2);

            double newtonsMethodRoot3 = Solvers.NewtonsMethod(function1, function2);

            var datapoints3 = new List<Datapoint>();
            datapoints3.Add(new Datapoint(0, -2));
            datapoints3.Add(new Datapoint(1, 0));
            datapoints3.Add(new Datapoint(2, 4));
            datapoints3.Add(new Datapoint(3, 16));

            var function3 = Solvers.CreateFunction(datapoints3);

            double newtonsMethodRoot4 = Solvers.NewtonsMethod(function3);

            double y5 = function3(4); //Should be 42
            //Console.Read();

            double d1 = tyler.text.Parsers.Parse("1.0");
            double d2 = tyler.text.Parsers.Parse("xyz");
        }
    }
}
