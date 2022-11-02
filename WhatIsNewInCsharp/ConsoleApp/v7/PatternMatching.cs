using ConsoleApp.v7._2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.v7
{
    public class Shape
    {
        public (int, int) Coordinate;
    }

    public class Rectangle : Shape
    {
        public int Width, Height;

        public Rectangle()
        {

        }
        public void Deconstruct(out (int, int) p, out int w, out int h)
        {
            p = Coordinate;
            w = Width;
            h = Height;
        }
    }

    public class Circle : Shape
    {
        public int Radius;

        public Circle()
        {
                
        }
        public void Deconstruct(out (int, int) p, out int r)
        {
            p = Coordinate;
            r = Radius;
        }
    }
}
