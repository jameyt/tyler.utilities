using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tyler.math
{
    public class LinearAlgebra
    {

        /// <summary>
        /// Computes the solution of a system of linear equations.
        /// </summary>
        /// <param name="M">
        /// The system of linear equations as an augmented matrix[row, col] where (rows + 1 == cols).
        /// It will contain the solution in "row echelon form" if the function returns "true".
        /// </param>
        /// <returns>
        /// Returns whether the matrix has a unique solution or not.  If a unique solution exists, the answer is in the original reference of M.
        /// </returns>
        /// <remarks>
        /// Credit to janismac, http://www.codeproject.com/Members/janismac, for providing inspiration and working code 
        /// (http://www.codeproject.com/Tips/388179/Linear-Equation-Solver-Gaussian-Elimination-Csharp) 
        /// for this function as it exists today.
        /// </remarks>
        public static bool GaussianElimination(double[,] M)
        {
            int rowCount = M.GetUpperBound(0) + 1;
            //algorithm must at least have one row and must be provided with a (n x n+1) matrix
            if (M == null || rowCount < 1 || M.Length != rowCount * (rowCount + 1))
            {
                return false;
            }
            else
            {
                //pivoting
                for (int col = 0; col + 1 < rowCount; col++) if (M[col, col] == 0)
                    //check for zero coefficients
                    {
                        //Find non-zero coefficient
                        int swapRow = col + 1;
                        for (; swapRow < rowCount; swapRow++)
                        {
                            if (M[swapRow, col] != 0) break;
                        }

                        if (M[swapRow, col] != 0)
                        {
                            //Swap row with above row
                            double[] tmp = new double[rowCount + 1];
                            for (int i = 0; i < rowCount + 1; i++)
                            {
                                tmp[i] = M[swapRow, i]; M[swapRow, i] = M[col, i]; M[col, i] = tmp[i];
                            }
                        }
                        else
                        {
                            //Matrix has no unique solution
                            return false;
                        }
                    }

                //Eliminate
                for (int sourceRow = 0; sourceRow + 1 < rowCount; sourceRow++)
                {
                    for (int destRow = sourceRow + 1; destRow < rowCount; destRow++)
                    {
                        double df = M[sourceRow, sourceRow];
                        double sf = M[destRow, sourceRow];
                        for (int i = 0; i < rowCount + 1; i++)
                        {
                            //Simplify terms from the n x n until it is simplified to only having terms in row pos = col pos, ex: M[1,1], M[2,2] etc.
                            M[destRow, i] = M[destRow, i] * df - M[sourceRow, i] * sf;
                        }
                    }
                }

                //Back insert
                for (int row = rowCount - 1; row >= 0; row--)
                {
                    double f = M[row, row];
                    if (f == 0)
                    {
                        //If any of these positions are zero, you cannot have a solution because you have no value for that variable.
                        return false;
                    }
                    for (int i = 0; i < rowCount + 1; i++)
                    {
                        //Simplify the n x n matrix to an identity matrix.  This places all the important numerical information in the last column.
                        M[row, i] /= f;
                    }
                    for (int destRow = 0; destRow < row; destRow++)
                    {
                        M[destRow, rowCount] -= M[destRow, row] * M[row, rowCount]; M[destRow, row] = 0;
                    }
                }
                return true;
            }
        }
    }
}
