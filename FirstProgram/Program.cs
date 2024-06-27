class Matrix
{
    readonly public int a, b, c, d;
    public Matrix(int a, int b, int c, int d)
    {
        this.a = a;
        this.b = b;
        this.c = c;
        this.d = d;
    }

    public static Matrix operator +(Matrix A, Matrix B)
    {
        Matrix C = new(A.a + B.a, A.b + B.b, A.c + B.c, A.d + B.d);
        return C;
    }
    public static Matrix operator -(Matrix A, Matrix B)
    {
        Matrix C = new(A.a - B.a, A.b - B.b, A.c - B.c, A.d - B.d);
        return C;
    }
    
    public override string ToString()
    {
        return $"{this.a} {this.b}\n{this.c} {this.d}\n";
    }
    
}
class TestMatrix
{
    static void Main()
    {
        Matrix m1 = new(4, 5, 7, 3);
        Matrix m2 = new(-6, 2, 11, 13);
        Matrix sum = m1 + m2;
        Matrix difference = m1 - m2;
        Console.WriteLine(sum);
        Console.WriteLine(difference);
    }
}