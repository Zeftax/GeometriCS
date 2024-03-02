using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometriCS
{
    /// <summary>
    /// Common utilities throughout the library.
    /// </summary>
    internal static class Utils
    {
        /// <summary>
        /// Default precision for double equality comparison.
        /// </summary>
        private const double DOUBLEPRECISION = 1E-5;

        /// <summary>
        /// Tests whether the difference between two doubles is within a given limit.
        /// </summary>
        /// <param name="a">First value to test.</param>
        /// <param name="b">Second value to test.</param>
        /// <param name="prec">Maximum allowed difference.</param>
        /// <returns>Do the values almost equal each other.</returns>
        public static bool DoubleEquals(double a, double b, double prec = DOUBLEPRECISION) => Math.Abs(a - b) <= prec;  
    }
}
