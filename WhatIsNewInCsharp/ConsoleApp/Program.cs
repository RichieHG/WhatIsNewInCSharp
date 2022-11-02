using ConsoleApp.v10;
using ConsoleApp.v7;
using ConsoleApp.v7._1;
using ConsoleApp.v7._2;
using ConsoleApp.v8;
using ConsoleApp.v9;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml.Schema;

namespace ConsoleApp
{
    public class Program
    {

        #region V7.1 - Async Main
        private static string url = "http://google.com/robots.txt";
        #endregion

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
            return (a + b, a * b, Math.Pow(a, b));
        }
        #endregion

        #region V7 - ThrowExpressions
        public string Name { get; set; }

        //public Program(string _name)
        //{
        //    //if(_name == null)
        //    //{
        //    //    throw new ArgumentNullException(paramName: nameof(_name));
        //    //}
        //    //Name = _name;

        //    Name = _name ?? throw new ArgumentNullException(paramName: nameof(_name)); 
        //}

        int GetValue(int n)
        {
            return n > 0 ? n + 1 : throw new Exception();
        }
        #endregion

        #region V7 - Generalized Async Return Types

        public static async Task<long> GetDirSize(string dir)
        {
            if (!Directory.EnumerateFileSystemEntries(dir).Any())
                return 0;

            return await Task.Run(() =>
            {
                return Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories)
                .Sum(f => new FileInfo(f).Length);
            });
        }

        public static async ValueTask<long> GetDirSize2(string dir)
        {
            if (!Directory.EnumerateFileSystemEntries(dir).Any())
                return 0;

            return await Task.Run(() =>
            {
                return Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories)
                .Sum(f => new FileInfo(f).Length);
            });
        }

        #endregion

        #region V7.1 - AsyncMain

        //private static async Task MainAsync(string s)
        //{
        //    Console.WriteLine(await new HttpClient().GetStringAsync(s));
        //}

        //static async Task Main(string[] args) // or ()
        //{
        //    Console.WriteLine(await new HttpClient().GetStringAsync(url));

        //}

        #endregion

        #region V7.1 - DefaultExpressions
        public static DateTime GetTimestamps(List<int> items = default)
        {
            return default;
        }
        #endregion

        #region V7.1 - PatternMatchingGenerics
        //public static void Cook<T>(T animal) where T : Animal
        //{
        //   if(animal is  Pig pig) { }

        //    switch (animal)
        //    {
        //        case Pig pork:
        //            break;
        //        default:
        //            break;
        //    }
        //}
        #endregion

        #region V7.2 - NonTrailingNamedArgs
        static void doSomething(int foo, int bar)
        {

        }
        #endregion

        #region V7.2 - InParams
        double MeasureDistance(in v7._2.Point p1, in v7._2.Point p2)
        {
            //p1.X = 1;
            //ChangeMe(ref p1);
            p1.Reset();

            var dx = p1.X - p2.X;
            var dy = p1.Y - p2.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        double MeasureDistance(v7._2.Point p1, v7._2.Point p2)
        {
            //p1.X = 1;
            //ChangeMe(ref p1);
            p1.Reset();

            var dx = p1.X - p2.X;
            var dy = p1.Y - p2.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        void ChangeMe(ref v7._2.Point p)
        {
            p.X++;
        }
        public Program()
        {
            v7._2.Point p1 = new(1, 1);
            v7._2.Point p2 = new() { X = 4, Y = 5 };

            var distance = MeasureDistance(in p1, in p2);

            Console.WriteLine($"Distance between p1: {p1} and p2:{p2} is {distance:f2}");

            var distanceFromOrigin = MeasureDistance(p1, v7._2.Point.Origin);
            Console.WriteLine($"Distance from Origin is {distanceFromOrigin:f2}");

            var copyOfOrigin = v7._2.Point.Origin; //by-value

            //ref var messWithOrigin = ref v7._2.Point.Origin; //Doesnt work because Origin is a readonly

            ref readonly var originRef = ref v7._2.Point.Origin;
        }
        #endregion

        #region V8 - PatternMatching

        static IEnumerable<int> GetMainOfficeNumbers()
        {
            var numbers = new ExtendedPhoneNumber[] { 
                new() { Code = 5, Number = 354, Office = "TI"}, 
                new() { Code = 5, Number = 4812, Office = "TI"}, 
                new() { Code = 47, Number = 440, Office = "PMO"}, 
                new() { Code = 47, Number = 785, Office = "PMO"}, 
                new() { Code = 75, Number = 1278, Office = "Infra"}

            };

            foreach(var pn in numbers)
            {
                if(pn is not ExtendedPhoneNumber { Office: "PMO" })
                {
                    yield return pn.Number;
                }
            }
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

            #region V7 - ExpressionBodiedMembers
            //var sodas = new Soda(2, "Cocacola");
            //Console.WriteLine(sodas.Name);
            #endregion

            #region V7 - ThrowExceptions

            //int a = -1;
            //try
            //{
            //    var p = new Program("");
            //    a = p.GetValue(a);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.ToString());
            //}
            //finally
            //{
            //    Console.WriteLine(a);
            //}


            #endregion

            #region V7 - GeneralizedAsyncReturnTypes

            //Console.WriteLine(GetDirSize2(@"C:\tempGen").Result);

            #endregion

            #region V7 - LiteralImprovements

            //Underscore '_' allow us to separate big numbers to see it more organized
            //It also works with Hexa an binaries
            //int a = 1_735;
            //int b = 1_42_1;

            //Console.WriteLine(a);
            //Console.WriteLine(b);

            #endregion

            #region V7.1 - Async Main
            //Console.WriteLine(await new HttpClient().GetStringAsync(url));

            //MainAsync(url).GetAwaiter().GetResult();

            #endregion

            #region V7.1 - DefaultExpressions

            ////In other days
            //int a = default(int);
            //const int b = default;
            ////const int? d = default; //Doesnt works because is a constant
            //int? d = default;
            //Console.WriteLine($"a = {a}  b = {b}  d ={d}");

            //var e = new[] { default, 33, default };
            //Console.WriteLine(string.Join(",", e));

            //int[] e2 = new int[] { default, default, default };
            //Console.WriteLine(string.Join(",", e2));

            //string s = default;
            //Console.WriteLine(s);

            //if(s == default)
            //{

            //}

            //var x = a > 0 ? default : 1.5;


            //Console.WriteLine(GetTimestamps());
            #endregion

            #region V7.1 - Infer TuplesNames
            //var me = (name: "Nefta", age: 26);
            //Console.WriteLine(me);

            //var alsoMe = (me.age, me.name, "Male");
            //Console.WriteLine(alsoMe.age);

            //var months = new[] { "March", "April", "June" };

            //var result = months.Select( x => 
            //(x.Length, FirstChar: x[0])).Where(x => x.Length == 5);

            //Console.WriteLine(String.Join(",", result));

            //var now = DateTime.Now;
            //var u = (now.Hour, now.Minute);
            //var v = (u.Hour, u.Minute) = (7, 23);

            //Console.WriteLine(v.Minute.ToString());
            #endregion

            #region V7.2 - LeadingDigitSeparator
            //var x = 0b_11_000000;
            //var y = 0x_baad_f00d;

            //Console.WriteLine(x);
            //Console.WriteLine(y);
            #endregion

            #region V7.2 - PrivateProtected

            //Base b = new Base();

            //Console.WriteLine(b.b);
            #endregion

            #region V7.2 -  NonTrailingNamedArgs

            //doSomething(bar: 13, foo: 12);
            //doSomething(foo: 13, 12);
            #endregion

            #region V7.2 - InParams

            //new Program();

            #endregion

            #region V7.2 - Span<T>

            //unsafe
            //{
            //    byte* ptr = stackalloc byte[100];
            //    Span<byte> memory = new Span<byte>(ptr, 100);

            //    IntPtr unmanagedPtr = Marshal.AllocHGlobal(123);
            //    Span<byte> unmanagedMemory = new Span<byte>(unmanagedPtr.ToPointer(), 123);

            //    Marshal.FreeHGlobal(unmanagedPtr);

            //    char[] stuff = "hello".ToCharArray();

            //    Span<char> arrayMemory = stuff;

            //    ReadOnlySpan<char> more = "hi there!".AsSpan();

            //    Console.WriteLine($"Out span has {more.Length} elements");

            //    arrayMemory.Fill('x');
            //    Console.WriteLine(stuff);
            //    arrayMemory.Clear();
            //    Console.WriteLine(stuff);

            //}

            #endregion

            #region V8 - Nullable Reference Type

            //var p = new v8.Person("Ricardo", "Hernandez", "Neftali");

            //Console.WriteLine(p.FullName);

            ////var a = (null as v8.Person)!.FullName; // This symbol ! help us to let know to compiler
            ////                                       // that we are pretty sure that that thing woun't be null
            ////Console.WriteLine(a);

            //var b = (null as v8.Person)!?.FullName;
            //Console.WriteLine(b);

            #endregion

            #region V8 - Indices and Range

            //Index i0 = 2;
            //Index i1 = new Index(0, false); //false indicate is fromBegining
            //var i2 = ^2; // Index (0, true)
            //                // -1 is not last

            //var items = new[] { 1,2,3,4,5 };
            //Console.WriteLine(string.Join(',', items));

            //Console.WriteLine(string.Join(',', items[0..4]));
            //Console.WriteLine(string.Join(',', items[0..^1]));
            //Console.WriteLine(items[^0]);

            //items[^2] = 33;
            //Console.WriteLine(string.Join(',', items));

            //var a = i1..i2; // Range(i1,i2)
            //var b = i1..; // Range(i1, new Index(0,true))
            //var c = ..i2; // Range(new Index(0, false), i2)
            //var e = ..; //Entire range
            //Range.EndAt(2);
            #endregion

            #region V8 - DefaultInterfaceMembers

            //Human human = new() { Name = "Ricardo" };
            //IHuman human = new Human() { Name = "Ricardo" };
            //human.SayHello();
            //((IHuman) new Human { Name = "Luis" }).SayHello();

            //((IFriendlyHuman) new Human { Name = "Luis" }).SayHello();

            //DualNational person = new DualNational { Name = "Ricardo Neftali" };
            //((IHuman)person).SayHello();

            //person.Greet();

            //IAmBritish bp = person;
            //bp.Greet();

            #endregion

            #region V8 - PatternMatching

            //var phoneNumber = new PhoneNumber();

            //phoneNumber.Code = 44;
            //var origin = phoneNumber switch
            //{
            //    { Number: 112 } => "Emergency",
            //    { Code: 44 } => "UK",
            //    _ => "Unknown"
            //    //{ }=> "Unknown"
            //};
            //Console.WriteLine(origin);

            //v8.Person person = new( "Luis", "Hernandez", "Neftali", new() { Code= 52, Number=5578} );

            //var personOrigin = person switch
            //{
            //    { FirstName: "Ricardo" } => "México",
            //    { PhoneNumber: { Code: 52 } } => "Spain",
            //    { FirstName: var name} => $"No idea where {name} lives"
            //};

            //Console.WriteLine(personOrigin);

            //person = new("Luis", "Hernandez", "Neftali", new() { Code = 52, Number = 578 });

            //var error = person switch
            //{
            //    null => "Object missing",
            //    { PhoneNumber: null } => "Phone number missing entirely",
            //    { PhoneNumber: { Number: 0} } => "Actual number missing",
            //    { PhoneNumber: { Code: var code} } when code < 0 => "WTF?",
            //    { } => null //no error
            //};

            //if(error != null)
            //    throw new ArgumentException(error);

            //var numbers = GetMainOfficeNumbers();

            //Console.WriteLine(String.Join(',', numbers));

            //object shape = new Rectangle() { Coordinate = (0,0), Height = 0, Width = 0};
            //object shape = new Circle() { Coordinate = (0,0), Radius = 10};
            //object shape = new Rectangle() { Coordinate = (0, 0), Height = 10, Width = 10 };
            object shape = new Rectangle() { Coordinate = (0, 0), Height = 6, Width = 10 };

            var type = shape switch
            {
                Rectangle((0,0),0,0) => "Point at origin",
                Circle((0, 0), _) => "Circle at origin",
                Rectangle(_, var w, var h) when w == h => "Square",
                Rectangle((var x, var y), var w, var h) =>
                $"A {w}x{h} rectangle at ({x},{y})",
                _ => "Something else"
            };

            Console.WriteLine(type);
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