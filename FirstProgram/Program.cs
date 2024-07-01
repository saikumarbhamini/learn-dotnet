using System.Linq;

public enum Cities
{
    Hyderabad = 1, Mumbai, Bangalore, Chennai, Delhi
}

class Customer
{
    readonly int _CustId;
    string _Cname;
    bool _Status;
    double _Balance;
    Cities _City;

    public Customer(int CustId, bool Status, string Cname, double Balance, Cities City, string Country)
    {
        _CustId = CustId;
        _Cname = Cname;
        _Status = Status;
        _Balance = Balance;
        _City = City;
        this.Country=Country;
    }

    public int CustId
    {
        get { return _CustId; }
    }
    public string Cname
    {
        get { return _Cname; }
        set
        {
            if (_Status == true)
                _Cname = value;
        }
    }
    public bool Status
    {
        get { return _Status; }
        set { _Status = value; }
    }
    public double Balance
    {
        get { return _Balance; }
        set
        {
            Console.WriteLine("...Requested to change balance");
            if (_Status == true && value >= 500)
            {
                _Balance = value;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("..Passed");
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("..Failed");
                Console.ForegroundColor = ConsoleColor.Black;

            }

        }
    }

    public Cities City
    {
        get { return _City; }
        set
        {
            if (_Status == true)
                _City = value;
        }
    }

    public string Country  // Auto implemented or automatic property
    {
        get;
        set;
    }
}

class Program
{
    static void Main()
    {
        Customer Cust = new(100, true, "Saikumar", 43000, Cities.Hyderabad, "India");
        Console.WriteLine($"{Cust.Cname}");
        Console.WriteLine($"City: {Cust.City}");
        Console.WriteLine($"Initial Balance: {Cust.Balance}");
        Cust.Balance -= 2021;
        Cust.City = Cities.Bangalore;
        Console.WriteLine(Cust.Balance);
        Cust.Status = false;
        Cust.Balance -= 1100;
        Console.WriteLine(Cust.Balance);
        Cust.Status = true;
        Cust.Balance -= 44000;
        Console.WriteLine(Cust.Balance);
        Console.WriteLine(Cust.City);
        Console.WriteLine(Cust.Country);
    }

}