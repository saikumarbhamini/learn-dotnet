public class Person
{
    readonly int id;
    readonly string Name, Address, Phone;
    public Person(int id, string Name, string Address, string Phone)
    {
        this.id = id;
        this.Name = Name;
        this.Address = Address;
        this.Phone = Phone;
    }
}
public class Student : Person
{
    readonly int Class;
    private readonly float Marks;
    private float Fees;
    char Grade;
    public Student(int id, string Name, string Address, string Phone, int Class, float Marks, float Fees, char Grade): base(id, Name, Address, Phone)
    {
        this.Class = Class;
        this.Marks = Marks;
        this.Fees = Fees;
        this.Grade = Grade;

    }

    public void AddOrUpdateStudent(Student student)
    {
        // Method to Add or update a student info here.
        Console.WriteLine($"{student.Fees} {student.Grade}");
    }
}
public class Staff : Person
{
    public double Salary;
    public string Designation;

    public Staff(int id, string Name, string Address, string Phone, double Salary, string Designation): base(id, Name, Address, Phone)
    {
        this.Salary=Salary;
        this.Designation=Designation;
    }
}

public class Teaching : Staff
{
    string Qualification, Subject;
    Teaching(int id, string Name, string Address, string Phone, double Salary, string Designation, string Qualification, string Subject): base(id, Name, Address, Phone, Salary, Designation)
    {
        this.Qualification=Qualification;
        this.Subject=Subject;
    }
}

public class NonTeaching : Staff
{
    readonly int MgrId;
    readonly string Dname;

    NonTeaching(int id, string Name, string Address, string Phone, double Salary, string Designation, int MgrId, string Dname): base(id, Name, Address, Phone, Salary, Designation)
    {
        this.MgrId=MgrId;
        this.Dname=Dname;
    }
}

class Program
{
    static void Main()
    {
        Student s = new(1, "saikumar", "HYD", "8464923590", 10, 89.6F, 34000, 'A');
        // Add more code to create instances for all classes and try to store them in memory.
    }
}