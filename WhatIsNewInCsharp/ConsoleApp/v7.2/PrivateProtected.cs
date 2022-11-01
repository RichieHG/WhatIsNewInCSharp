using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.v7._2
{
    public class Base
    {
        private int a;
        protected internal int b;
        // 1) Derived classes (ANY assembly)
        // 2) Classes in same assembly

        private protected int c;
        // 1) Containing class
        // 2) Derived classes but only in current assembly
    }

    public class Derived : Base
    {
        public Derived()
        {
            b = 1;
            c = 2;
        }
    }
}
