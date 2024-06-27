public abstract class Figure
{
    public double Width, Height, Radius;
    public const float PI = 3.14f;

    public abstract double GetArea();
}

class Rectangle : Figure
{
    public Rectangle(double Width, double Height)
    {
        this.Width = Width;
        this.Height = Height;
    }

    public override double GetArea()
    {
        return Width * Height;
    }
}
class Circle : Figure
{
    public Circle(double Radius)
    {
        this.Radius = Radius;
    }
    public override double GetArea()
    {
        return PI * Radius * Radius;
    }
}
class Cone : Figure
{
    public Cone(double Radius, double Height)
    {
        this.Radius=Radius;
        this.Height=Height;
    }
    public override double GetArea()
    {
        return PI*Radius*(Radius + Math.Sqrt(Height*Height + Radius*Radius));
    }
}
class TestFigure
{
    static void Main()
    {
        Circle c = new(5);
        Rectangle R = new(4, 5);
        Cone cn = new(6, 9);
        Console.WriteLine(c.GetArea());
        Console.WriteLine(R.GetArea());
        Console.WriteLine(cn.GetArea());
    }
}