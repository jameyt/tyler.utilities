using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tyler.text
{
    public class Parsers
    {
        public static double Parse(string s)
        {
            double result;
            return double.TryParse(s, out result) ? result : double.NaN;
        }

        //public static float Parse(string s)
        //{
        //    float result;
        //    return float.TryParse(s, out result) ? result : float.NaN;
        //}

        //public static int Parse(string s)
        //{
        //    int result;
        //    return int.TryParse(s, out result) ? result : int.MinValue;
        //}

        //public static DateTime Parse(string s)
        //{
        //    DateTime result;
        //    return DateTime.TryParse(s, out result) ? result : DateTime.MinValue;
        //}
    }
}
