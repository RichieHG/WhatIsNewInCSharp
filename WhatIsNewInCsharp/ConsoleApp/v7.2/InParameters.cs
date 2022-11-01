using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.v7._2
{
    struct Point
    {
        public double X, Y;

        public Point(double x, double y)
        {
            X = x;
            Y = y;
               
        }

        #region V7.2 - RefReadOnlyVariables
        private static v7._2.Point origin = new v7._2.Point();
        public static ref readonly v7._2.Point Origin => ref origin;
        #endregion


        public override string ToString()
        {
            return $"({X},{Y})";
        }

        public void Reset()
        {
            X = Y = 0;
        }
    }
}
