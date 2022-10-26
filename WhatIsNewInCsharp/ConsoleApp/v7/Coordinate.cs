using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.v7
{
    public class Coordinate
    {
        public int X, Y;

        public void Deconstruct(out int x, out int y)
        {
            x = X;
            y = Y;
        }
    }
}
