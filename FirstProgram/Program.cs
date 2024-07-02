namespace FirstProgram
{
    class Program
    {
        public void Test1()
        {
            Console.WriteLine("Method 1");
        }
        public void Test2()
        {
            Console.WriteLine("Method 2");
        }
        static void Main(string[] args)
        {
            Program p = new();
            p.Test1(); p.Test2();
        }
    }

    static class ExtendMethod
    {
        public static void Test3(this Program p)
        {
            Console.WriteLine("Method 3");
        }

        public static long Fact(this Int32 x)
        {
            if (x == 1)
                return 1;
            if (x == 2)
                return 2;
            else
                return x * Fact(x - 1);
        }

        public static string ToProper(this String OldStr)
        {
            String? NewStr = null;
            if (OldStr.Trim().Length > 0)
            {
                OldStr = OldStr.ToLower();
                string[] words = OldStr.Split(' ');
                foreach (string word in words)
                {
                    char[] charArr = word.ToCharArray();
                    charArr[0] = Char.ToUpper(charArr[0]);
                    if (NewStr == null)
                        NewStr = new string(charArr);
                    else
                        NewStr += " " + new string(charArr);
                }
                return NewStr;
            }
            return OldStr;

        }
    }

    class TestExtensionMethod
    {
        static void Main()
        {
            Program p = new();
            p.Test1(); p.Test2(); p.Test3();
            int i = 5;
            long factorialValue = i.Fact();
            Console.WriteLine($"Factorial of {i} is {factorialValue}");
            string greeting = "heLLo hOw arE YoU!";
            Console.WriteLine($"String: {greeting}");
            Console.WriteLine($"ProperCase : {greeting.ToProper()}");
        }
    }
}