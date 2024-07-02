namespace FirstProgram
{
    // Define a delegate
    public delegate void AddDelegate(int a, int b);
    public delegate string SayDelegate(string name);

    public delegate void RectDelegate(double x, double y);

    public delegate string GreetingsDelegate(string name);

    public delegate double Delegate1(int x, float y, double z);
    public delegate void Delegate2(int x, float y, double z);
    public delegate bool Delegate3(string str);

    /*
    For multicast deligate we get only output of one method and 
    that is the last method, so we use only void type methods with multicast deligates.
    */
    public class DelegateProgram
    {
        public static void GetArea(double width, double height)
        {
            Console.WriteLine($"Area of Rectangle: {width*height}");
        }

        public static void GetPerimeter(double width, double height)
        {
            Console.WriteLine($"Perimeter of Rectangle: {2*(width + height)}");
        }
    }

    public class AnonymousMethods
    {
        public static string Greetings(string name){
            return "Hello " + name + " a very good morning.";
        }
    }

    class GenericDelegates
    {
        public static double AddNums1(int x, float y, double z)
        {
            return x+y+z; 
        }
        public static void AddNums2(int x, float y, double z)
        {
            Console.WriteLine(x+y+z); 
        }
        public static bool CheckLength(string str)
        {
            if(str.Length > 5)
                return true;
            return false;
        }
    }
    
    public class Program
    {
        public void AddNums(int a, int b)
        {
            Console.WriteLine(a + b);
        }
        public static string SayHello(string name){
            return "Hello " + name;
        }
        static void Main()
        {
            Program p = new();
            // Instantiate delegate.
            AddDelegate ad = new(p.AddNums);
            ad(45, 6);
            SayDelegate sd = new(SayHello);
            sd("Bhamini");
            p.AddNums(5, 79);
            string str = SayHello("Saikumar");
            Console.WriteLine(str);

            RectDelegate calRect = DelegateProgram.GetArea;
            calRect += DelegateProgram.GetPerimeter;
            calRect(45.3, 5.6);

            // Anonymous methods
            GreetingsDelegate greetDelegate = delegate(string name){
                return "Hello " + name + " a very good morning.";
            };
            string greetStr = greetDelegate("Saikumar");
            Console.WriteLine(greetStr);

            // lambda expressions
            GreetingsDelegate greetLambda = (name) => 
            {
                return "Hello " + name + " a very good morning.";
            };
            string greetLambdaMsg = greetLambda("Bhamini");
            Console.WriteLine(greetLambdaMsg);

            // Generic delegates
            Func<int, float, double, double> obj1 = (x, y, z) =>x + y + z;  // func delegate with lambda expression.
            double res = obj1(100, 3.14f, 6.33);
            Console.WriteLine(res);

            Action<int, float, double> obj2 = GenericDelegates.AddNums2;
            obj2(100, 3.14f, 6.33);
            Predicate<string> obj3 = GenericDelegates.CheckLength;
            bool res1 = obj3("Welcome");
            Console.WriteLine(res1);
        }
    }

}
