using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tyler.math
{
    internal class FunctionTerm
    {
        public FunctionTerm() { }

        public FunctionTerm(double a, double b) { A = a; B = b; }

        public double A { get; set; }
        public double B { get; set; }
    }
}
