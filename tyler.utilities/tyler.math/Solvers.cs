using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace tyler.math
{
    public class Solvers
    {

        public static double LinearInterpolation(double x1, double y1, double x2, double y2, double x)
        {
            double y = (y2 - y1) / (x2 - x1) * (x - x1) + y1;

            return y;
        }

        public static double LinearRootApproximation(double x1, double y1, double x2, double y2)
        {
            double x = LinearInterpolation(y1, x1, y2, x2, 0);

            return x;
        }

        /// <summary>
        /// Use Newton's method to find a root location.
        /// </summary>
        /// <param name="function"></param>
        /// <param name="x"></param>
        /// <param name="tolerance"></param>
        /// <returns></returns>
        public static double NewtonsMethod(Func<double, double> function, double x = 0, double tolerance = 0.00001)
        {
            int iterations = 0; //keep track of iterations for debugging purposes

            //initial guess
            double y = function(x); //initial value of function

            while (System.Math.Abs(y) > tolerance && iterations < 100)
            {
                double firstDerivative = Calculus.EstimateFirstDerivative(function, x);

                if (firstDerivative < 0.01) //If the first derivative is very small at the initial guess, Newton's method will move the second guess a large magnitude, so this statement checks and moves the initial guess if this is the case.
                {
                    return NewtonsMethod(function, x / 2 + 1);
                }
                x = x - y / firstDerivative;  //Newton's Method
                y = function(x);
                iterations++;
            }

            Debug.WriteLine("Newton's method iterations: " + iterations);
            return x;
        }

        /// <summary>
        /// Use Newton's method to find the intersection of two functions of x.
        /// </summary>
        /// <param name="function1">
        /// First function of x for which you want the intersection location.
        /// </param>
        /// <param name="function2">
        /// Second function of x for which you want the intersection location.
        /// </param>
        /// <param name="x">
        /// Initial guess, not needed as input unless you suspect the root location you are interested in is near a certain value.
        /// </param>
        /// <param name="tolerance">
        /// A root location will only be returned if the difference between function1 and function2 is less than this value.
        /// </param>
        /// <returns>
        /// Location of intersection between two functions of x
        /// </returns>
        public static double NewtonsMethod(Func<double, double> function1, Func<double, double> function2, double x = 0, double tolerance = 0.00001)
        {
            if (System.Math.Round(Calculus.EstimateFirstDerivative(function1, x) - Calculus.EstimateFirstDerivative(function2, x), 4) == 0 && System.Math.Round(Calculus.EstimateFirstDerivative(function1, x / 2 + 1) - Calculus.EstimateFirstDerivative(function2, x / 2 + 1), 4) == 0)
            {
                //throw new ArgumentException("Functions are parallel.","function1 and function2");
                return double.NaN;
            }

            Func<double, double> function = z => function1(z) - function2(z); //Create function to solve from the difference of the two input functions.

            return NewtonsMethod(function, x, tolerance);
        }

        public static Func<double, double> CreateFunction(List<Datapoint> datapoints)
        {
            double[,] M = new double[datapoints.Count, datapoints.Count + 1];

            for (int i = 0; i < datapoints.Count; i++)
            {
                for (int j = 0; j < datapoints.Count; j++)
                {
                    M[i, j] = System.Math.Pow(datapoints[i].X, datapoints.Count - j - 1);
                }
                M[i, datapoints.Count] = datapoints[i].Y;
            }

            if (
                LinearAlgebra.GaussianElimination(M)
               )
            {
                List<FunctionTerm> functionTerms = new List<FunctionTerm>();

                for (int i = 0; i < datapoints.Count; i++)
                {
                    FunctionTerm functionTerm = new FunctionTerm();
                    functionTerm.A = M[i, datapoints.Count];
                    functionTerm.B = datapoints.Count - i - 1;
                    functionTerms.Add(functionTerm);
                }

                return x =>
                {
                    double sumTerms = 0;
                    foreach (FunctionTerm ft in functionTerms)
                    {
                        sumTerms += ft.A * System.Math.Pow(x, ft.B);
                    }
                    return sumTerms;
                };
            }
            else
            {
                return null;
            }
        }

        public static Func<double, double> CreateFunction(double x1, double y1, double x2, double y2)
        {
            return CreateFunction(
               new List<Datapoint> 
            { 
                new Datapoint(x1, y1), 
                new Datapoint(x2, y2) 
            }
           );
        }

        public static Func<double, double> CreateFunction(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            return CreateFunction(
                 new List<Datapoint> 
            { 
                new Datapoint(x1, y1), 
                new Datapoint(x2, y2), 
                new Datapoint(x3, y3) 
            }
             );
        }

        public static Func<double, double> CreateFunction(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            return CreateFunction(
                new List<Datapoint> 
            { 
                new Datapoint(x1, y1), 
                new Datapoint(x2, y2),
                new Datapoint(x3, y3), 
                new Datapoint(x4, y4) 
            }
            );
        }

        public static Func<double, double> CreateFunction(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4, double x5, double y5)
        {
            return CreateFunction(
                new List<Datapoint> 
            { 
                new Datapoint(x1, y1), 
                new Datapoint(x2, y2),
                new Datapoint(x3, y3), 
                new Datapoint(x4, y4), 
                new Datapoint(x5, y5) 
            }
            );
        }

        public static double FindIntersection(List<Datapoint> datapoints1, List<Datapoint> datapoints2)
        {
            var function1 = CreateFunction(datapoints1);
            var function2 = CreateFunction(datapoints2);

            return NewtonsMethod(function1, function2);
        }

        /// <summary>
        /// Given two functions, returns an x location where they are equal.
        /// </summary>
        /// <param name="function1"></param>
        /// <param name="function2"></param>
        /// <returns>
        /// A value of X where function1(x) = function2(x).
        /// </returns>
        public static double FindIntersection(Func<double, double> function1, Func<double, double> function2)
        {
            return NewtonsMethod(function1, function2);
        }

        /// <summary>
        /// Given a function and a value of that function, returns an x location where the function equals the value.
        /// </summary>
        /// <param name="function"></param>
        /// <param name="y"></param>
        /// <returns>
        /// A value of x where function(x) = y.
        /// </returns>
        public static double FindXGivenY(Func<double, double> function, double y)
        {
            return NewtonsMethod(function, x => y);
        }

        /// <summary>
        /// Given a list of datapoints and a value, returns an x location where the function that reperesents the datapoints equals the value.
        /// </summary>
        /// <param name="datapoints">
        /// 
        /// </param>
        /// <param name="y">
        /// 
        /// </param>
        /// <returns>A value of x where function(x) = y.</returns>
        public static double FindXGivenY(List<Datapoint> datapoints, double y)
        {
            var function = CreateFunction(datapoints);
            return NewtonsMethod(function, x => y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="function"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double FindYGivenX(Func<double, double> function, double x)
        {
            return function(x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="datapoints"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double FindYGivenX(List<Datapoint> datapoints, double x)
        {
            var function = CreateFunction(datapoints);
            return function(x);
        }

    }
}
