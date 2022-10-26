using ConsoleApp.v10;
using ConsoleApp.v7;
using ConsoleApp.v9;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ConsoleApp
{
    public class Program
    {

        #region V7 - Pattern Matching

        //public void DisplayShape(Shape shape)
        //{
        //    if (shape is Rectangle)
        //    {
        //        var rc = (Rectangle)shape;
        //    }

        //    var rec = shape as Rectangle;
        //    if(rec != null)
        //    {
        //        Console.WriteLine("It's a rectangle");
        //    }

        //    //New feature
        //    if(shape is Rectangle r)
        //    {

        //    }

        //    if(!(shape is Circle notCircle))
        //    {

        //    }

        //    switch (shape)
        //    {
        //        case Circle c:

        //            break;
        //        case Rectangle rc when (rc.Height != rc.Width):
        //            break;
        //    }
        //}
        #endregion

        #region V7 - Tuples

        static Tuple<double, double> SumAndProduct(double a, double b)
        {
            return Tuple.Create(a + b, a * b);
        }

        static (double sum, double product, double pow) NewSumAndProduct(double a, double b)
        {
            return (a + b, a * b, Math.Pow(a,b));
        }
        #endregion

        #region V9 - Pattern Matching
        //public static bool IsLetter(char c) =>
        //   c is >= 'a' and <= 'z' or >= 'A' and <= 'Z';

        //public static bool IsLetterOrSeparator(this char c) =>
        //    c is (>= 'a' and <= 'z') or (>= 'A' and <= 'Z') or ';' or ',';
        #endregion
        static void Main(string[] args)
        {
            #region V7 - Out Variables
            //DateTime dt;
            //if (DateTime.TryParse("01/01/1990", out dt)) Console.WriteLine(dt);

            //if (DateTime.TryParse("02/08/1996", out DateTime birthDate))
            //    Console.WriteLine(birthDate);

            //Console.WriteLine(birthDate.Month);

            //int.TryParse("abc", out var i);
            //Console.WriteLine(i);
            #endregion

            #region V7 - Tuples
            //var sp = SumAndProduct(2, 3);
            //Console.WriteLine($"sum = {sp.Item1} | product = {sp.Item2}");

            //var newSP = NewSumAndProduct(2, 3);
            //Console.WriteLine($"sum = {newSP.sum} | product = {newSP.product} | pow = {newSP.pow}");
            //Console.WriteLine(newSP.GetType());

            //(double ss, double pp, double ppp) = NewSumAndProduct(2, 3);
            //Console.WriteLine($"sum = {ss} | product = {pp} | pow = {ppp}");

            //var (sum, product, pow) = NewSumAndProduct(2, 3);
            //Console.WriteLine($"sum = {sum} | product = {product} | pow = {pow}");

            //double s, p, pw;
            //(s,p,pw) = NewSumAndProduct(2, 3);
            //Console.WriteLine($"sum = {s} | product = {p} | pow = {pw}");

            //var me = (name: "Nefta", age: 26);
            //Console.WriteLine(me);
            //Console.WriteLine(me.GetType());
            //Console.WriteLine(me.name);
            //Console.WriteLine(me.age);

            //var snp = new Func<double, double, (double sum, double product, double pow)>((a, b) => (a +b, a *b, Math.Pow(a,b)));
            //var result = snp(2, 3);
            //Console.WriteLine($"sum = {result.sum} | product = {result.product} | pow = {result.pow}");
            #endregion

            #region V7 - Deconstruction
            //var me = (name: "Nefta", age: 26);
            //var (name, age) = me;

            //var myPoint = new Coordinate();
            //myPoint.X = 5;
            //var (x, y) = myPoint;
            //Console.WriteLine($"{x}");


            ////If you dont care "X" value, you can use underscore '_'
            //var (x2, _) = myPoint;
            //Console.WriteLine($"{x2}");
            #endregion

            #region V7 - LocalFunctions
            //var result = EquationSolver.SolveQuadratic(1,10,16);
            //Console.WriteLine(result);

            #endregion

            #region V7 - Ref Returns and Locals
            //int[] numbers = { 1, 2, 3, 4, 5, 6, };

            //ref int refToSecond = ref numbers[1];


            ////refToSecond = ref numbers[3];
            //refToSecond = 123;
            //var valueOfSecond = refToSecond;

            //Array.Resize(ref numbers, 1);

            //Console.WriteLine($"Second = {refToSecond} | ArraySize = {numbers.Length}");

            //refToSecond = 321;
            //numbers.SetValue(321, 0);
            //Console.WriteLine($"Second = {refToSecond} | ArraySize = {numbers.Length}");

            //Console.WriteLine(String.Join(",",numbers));

            //var numbersList = new List<int> { 1,2,3,4,5,6,7 };
            ////ref int second = ref numbersList[2];

            //ref int Find(int[] numbersArray, int value) {
            //    for(int i = 0; i< numbersArray.Length; i++)
            //    {
            //        if (numbersArray[i] == value) return ref numbersArray[i];
            //    }
            //    throw new ArgumentException("NotFound");
            //};

            //int[] moreNumbers = { 20, 30, 40 };
            //ref int refTo30 = ref Find(moreNumbers, 30);
            //Console.WriteLine($"Reference = {refTo30} | Array = {String.Join(",", moreNumbers)}");

            //refTo30 = 1000;

            //Find(moreNumbers, 40) = 121212;
            //Console.WriteLine($"Reference = {refTo30} | Array = {String.Join(",", moreNumbers)}");

            //ref int Min(ref int x, ref int y)
            //{
            //    if (x < y) return ref x;
            //    else return ref y;
            //}

            //int a = 1, b=2;
            //int min = Min(ref a, ref b);

            //Console.WriteLine($"Min = {min} | A = {a} | B = {b}");

            //min = 19;
            //Console.WriteLine($"Min = {min} | A = {a} | B = {b}");

            //ref int minR = ref Min(ref a, ref b);
            //Console.WriteLine($"Min = {minR} | A = {a} | B = {b}");

            //minR = 19;
            //Console.WriteLine($"Min = {minR} | A = {a} | B = {b}");
            #endregion

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
            //Point<int> point = new(2, 3);
            //Console.WriteLine(point);

            //Coords coords = new(1, 2);
            //Console.WriteLine(coords);

            //Student obj = new Student() {
            //    Id = 4,
            //    Name = "Sam",
            //    Father = new() { Name = "Luis", Age = 50 }
            //};

            //if (obj is Student {
            //    Father.Name: "Luis",
            //    Father.Age: 50
            //} d)
            //{
            //    Console.WriteLine(d.Id);
            //}
            //else Console.WriteLine("Hola");


            //var parse = (string s) => int.Parse(s);
            //Console.WriteLine(parse("5"));

            //var square = [Obsolete] double ( int s) => s*s + 1.5;
            //square(5);

            //var pow = () => square(5);
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