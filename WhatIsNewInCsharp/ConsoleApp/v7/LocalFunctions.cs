using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.v7
{
    public class EquationSolver
    {
        public static Tuple<double, double>
            SolveQuadratic(double a, double b, double c)
        {
            // b*b-4*a*c

            //This function would be in its own method, but it could be only for
            //this kind of equations, for that reason, we can use local functions
            //var CalculateDiscriminant = new Func<double, double, double, double>(
            //    (aa, bb, cc) => bb * bb - 4 * aa * cc);

            //double CalculateDiscriminant(double aa, double bb, double cc)
            //{
            //    return bb * bb - 4 * aa * cc;
            //}

            //double CalculateDiscriminant()
            //{
            //    return b * b - 4 * a * c;
            //}

            double CalculateDiscriminant() => b * b - 4 * a * c;

            var disc = CalculateDiscriminant();
            var rootDisc = Math.Sqrt(disc);
            return Tuple.Create(
                (-b - rootDisc) / (2 * a),
                (-b + rootDisc) / (2 * a)
            );

            //You can define you local function after you've used it
            //double CalculateDiscriminant() => b * b - 4 * a * c;

        }
    }
}
