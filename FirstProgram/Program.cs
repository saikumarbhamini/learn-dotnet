using System;
using System.Diagnostics;
using Humanizer;

class Program
{
    static void Main()
    {
        Console.WriteLine("Quantities:");
        // HumanizeQuantites();

        Console.WriteLine("\nDate/Time Manipulation:");
        // HumanizeDates();
        static void HumanizeQuantites()
        {
            Console.WriteLine("case".ToQuantity(0));
            Console.WriteLine("case".ToQuantity(1));
            Console.WriteLine("case".ToQuantity(5));
        }

        static void HumanizeDates()
        {
            Console.WriteLine(DateTime.UtcNow.AddHours(-24).Humanize());
            Console.WriteLine(DateTime.UtcNow.AddHours(-2).Humanize());
            Console.WriteLine(TimeSpan.FromDays(1).Humanize());
            Console.WriteLine(TimeSpan.FromDays(16).Humanize());
        }

        Console.WriteLine("Generating invoices for customer \"Contoso Corp\" ... \n");
        Console.WriteLine("Invoice: 1021\t\tComplete!");
        Console.WriteLine("Invoice: 1022\t\tComplete!");
        Console.WriteLine("\nOutput Directory:\t");
        Console.WriteLine(@"c:\invoices");
        // Kon'nichiwa World
        // Console.WriteLine("\u3053\u3093\u306B\u3061\u306F World!");
        string firstName = "Sai";
        string lastName = "Kumar";
        Console.WriteLine(firstName + " " + lastName);
        Console.WriteLine($"Hello! {firstName} {lastName}");

        int version = 11;
        string updateText = "Update to windows" + @"\";
        Console.WriteLine($"{updateText} {version}");

        int result = Fibonacci(6);
        Console.WriteLine(result);


        static int Fibonacci(int n)
        {
            Debug.WriteLine($"Entering {nameof(Fibonacci)} method");
            Debug.WriteLine($"We are lookinh for the {n}th");
            int n1 = 0;
            int n2 = 1;
            int sum;

            for (int i = 2; i <= n; i++)
            {
                sum = n1 + n2;
                n1 = n2;
                n2 = sum;
                Debug.WriteLineIf(sum == 1, $"sum is 1, n1 is {n1}, n2 is {n2}");
            }
            Debug.Assert(n2 == 5, "return value is not 5 and it should be");
            return n == 0 ? n1 : n2;
        }
    }
}