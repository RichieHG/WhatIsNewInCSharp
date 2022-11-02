using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.v8
{
    public interface IHuman
    {
        string Name { get; set; }

        public void SayHello()
        {
            Console.WriteLine($"Hello, I am {Name}");
        }
    }

    public interface IFriendlyHuman: IHuman
    {
        void IHuman.SayHello()
        {
            Console.WriteLine($"Greeting, my name is {Name}");
        }
    }

    public class Human: IHuman, IFriendlyHuman
    {
        public string Name { get; set; }
    }

    interface ITalk
    {
        void Greet();
    }

    interface IAmBritish: ITalk
    {
        void ITalk.Greet() => Console.WriteLine("Good day!");
    }

    interface IAmAmerican : ITalk
    {
        void ITalk.Greet() => Console.WriteLine("Howdy!");
    }

    public class DualNational: Human, IAmBritish, IAmAmerican
    {
        public void Greet()
        { 
            Console.WriteLine("Hi");
        }
    }
}
