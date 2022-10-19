using ConsoleApp.v10;
using ConsoleApp.v9;
using System.Diagnostics.Contracts;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ConsoleApp
{
    public class Program
    {
        #region V9 - Pettern Matching
        //public static bool IsLetter(char c) =>
        //   c is >= 'a' and <= 'z' or >= 'A' and <= 'Z';

        //public static bool IsLetterOrSeparator(this char c) =>
        //    c is (>= 'a' and <= 'z') or (>= 'A' and <= 'Z') or ';' or ',';
        #endregion
        static void Main(string[] args)
        {
            #region V9 - Record Types
            //var t = typeof(Person);
            //foreach(var m in t.GetMembers())
            //{
            //    Console.WriteLine($"- {m.Name}");
            //}

            //var p = new Person { Name = "Jhon", Age = 26 };
            //var p2 = new Person { Name = "Jhon", Age = 26 };
            //Console.WriteLine(p == p2);

            //p.Address = new(123, "Flamenco ");
            //p2.Address = new(1234, "Flamenco ");
            //Console.WriteLine(p == p2);

            //Console.WriteLine(typeof(Person).GetInterfaces()[0].Name);

            //var origin = new Point(1, 5);
            //var (x,y) = origin;

            //var p = new Point(2, 3);
            //Console.WriteLine(p.GetHashCode());

            //Car myFirstCar = new() { Color = new() { Name = "Black", Metallic = false}, Engine = "V6" };

            //Car upgradedCar = myFirstCar with { Engine = "V8" }; // clone() = shallow copy | Create a copy by reference

            //upgradedCar.Color.Metallic = true;

            //Console.WriteLine(myFirstCar);
            //Console.WriteLine(upgradedCar);
            #endregion

            #region V9 - Initial Setters

            //var p = new Employee { SSN = 1 };
            #endregion

            #region V9 - Pattern Matching

            //int temperature = 6666;

            //var feel = temperature switch
            //{
            //    < 0 => "freezing",
            //    //and 
            //    >= 0 and <20 => "tolerable",
            //    >= 20 and not (666 or 6666) => "warm",
            //    666 or 6666 => "hellish"
            //};

            //Console.WriteLine(feel);
            #endregion

            #region V9 - TargetTyped

            //var s = new Student { Name = "Sam"};
            //Student s2 = new(){ Name = "Sam"};
            //Student s3 = new(5,"Sam");

            //UseStudent(new(5,"Sam"));

            #endregion

            #region V9 -SourceGenerators
            //Console.WriteLine(new Foo().Bar) ;
            #endregion

            #region V10 - Record Structs
            Point<int> point = new(2, 3);
            Console.WriteLine(point);

            Coords coords = new(1, 2);
            Console.WriteLine(coords);

            Student obj = new Student() {
                Id = 4,
                Name = "Sam",
                Father = new() { Name = "Luis", Age = 50 }
            };

            if (obj is Student {
                Father.Name: "Luis",
                Father.Age: 50
            } d)
            {
                Console.WriteLine(d.Id);
            }
            else Console.WriteLine("Hola");


            var parse = (string s) => int.Parse(s);
            Console.WriteLine(parse("5"));

            var square = [Obsolete] double ( int s) => s*s + 1.5;
            square(5);

            var pow = () => square(5);
            #endregion
        }

        #region V9 - TargetTyped
        //public static void UseStudent(Student s)
        //{
        //    Console.WriteLine(s.Name);
        //}

        //public static Student MakeStudent(int id, string name)
        //{
        //    return new(id, name) { Name = name};
        //}
        #endregion
    }

}

#region V9 - Top Level Calls
// For this part you have to comment all codelines above

//using System;
//using System.Reflection;
////Console.WriteLine("Hello World!");
////Foo();

////void Foo()
////{
////    Console.WriteLine("Foo");
////}

////Console.WriteLine(args.Length);
////Console.WriteLine(args[0]);

////await Task.CompletedTask;

////return 1;
////class Person
////{
////    public int Id { get; set; }
////}

//var method = MethodBase.GetCurrentMethod();

//Console.WriteLine(method.DeclaringType.Namespace);
//Console.WriteLine(method.DeclaringType.Name);
//Console.WriteLine(method.Name);

#endregion