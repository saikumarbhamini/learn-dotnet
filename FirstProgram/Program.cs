/*
Difference b/w structure and class:
1) Class is reference type and Struct is value type.
2) Memory allocation for instances of class is by heap, and for structure its by stack.
3) We use class for representing entities with larger volumes of data, and structure for 
 smaller volumes of data.
4) We can create an instance of struct without new, but its different when you have fields in structure.
5) There's always a default parameterless constructure in structure, and we can't explicitly 
 create parameterless constructor only parameterized.
6) A structure can't be inherited by another structure, but only an interface. 
*/
struct Arithmetic
{
    public int a, b;
    public Arithmetic(int a, int b)
    {
        this.a = a;
        this.b = b;
    }
    public void Add()
    {
        Console.WriteLine(a + b);
    }
    public void Multiply()
    {
        Console.WriteLine(a * b);
    }
    static void Main()
    {
        Arithmetic obj = new(4, 5);
        obj.Add();
        Arithmetic objm;
        objm.a = 5;
        objm.b = -3;
        objm.Multiply();
    }
}
