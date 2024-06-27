interface IAddition
{
    void Add(int a, int b);
}
interface ISubtraction: IAddition
{
    void Sub(int a, int b);
}
class TestInterface: ISubtraction
{
    public void Add(int a, int b)
    {
        Console.WriteLine(a + b);
    }

    public void Sub(int a, int b)
    {
        Console.WriteLine(a - b);
    }
    
    static void Main()
    {
        TestInterface obj = new();
        obj.Add(411, -6);
        obj.Sub(21, 3);
    }
}