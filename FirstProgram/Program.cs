namespace FirstProgram
{

    public class DividedByOddNumberException : ApplicationException
    {
        public override string Message
        {
            get
            {
                return "Attempted to divide by odd number";
            }
        }
    }
    class Program
    {
        static void Main()
        {
            int x, y;
            try
            {
                Console.Write("Enter first number:");
                x = int.Parse(Console.ReadLine());
                Console.Write("Enter second number:");
                y = int.Parse(Console.ReadLine());
                if (y % 2 != 0)
                    // throw new ApplicationException("Attempted to divide by odd number.");
                    throw new DividedByOddNumberException();
                int z = x / y;
                Console.WriteLine("Result:" + z);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (DividedByOddNumberException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("End of the program");
            }

        }
    }
}