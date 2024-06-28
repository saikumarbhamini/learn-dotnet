class Customer
{
    readonly int _CustId;
    string _Cname;
    bool _Status;
    double _Balance;

    public Customer(int CustId, bool Status, string Cname, double Balance)
    {
        _CustId = CustId;
        _Cname = Cname;
        _Status = Status;
        _Balance = Balance;
    }

    public int CustId
    {
        get { return _CustId; }
    }
    public string Cname
    {
        get { return _Cname; }
        set { _Cname = value; }
    }
    public bool Status
    {
        get { return _Status; }
        set { _Status = value; }
    }
    public double Balance
    {
        get { return _Balance; }
        set {
            Console.WriteLine("...Requested to change balance");
            if(_Status==true && value >= 500)
            {
                _Balance = value;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("..Passed");
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("..Failed");
                Console.ForegroundColor = ConsoleColor.Black;

            }

        }
    }
}

class Program
{
    static void Main()
    {
        Customer Cust = new(100, true, "Saikumar", 43000);
        Console.WriteLine($"{Cust.Cname}");
        Console.WriteLine($"Initial Balance: {Cust.Balance}");
        Cust.Balance -= 2021;
        Console.WriteLine(Cust.Balance);
        Cust.Status=false;
        Cust.Balance -= 1100;
        Console.WriteLine(Cust.Balance);
        Cust.Status=true;
        Cust.Balance -= 44000;
        Console.WriteLine(Cust.Balance);
    }
    
}