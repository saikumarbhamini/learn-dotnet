using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Reflection.Metadata.Ecma335;

namespace FirstProgram
{

    public class Customer : IComparable<Customer>
    {
        public int Custid { get; set; }
        public required string Name { get; set; }
        public required string City { get; set; }
        public double Balance { get; set; }

        public int CompareTo(Customer other)
        {
            if (this.Custid > other.Custid)
                return 1;
            else if (this.Custid < other.Custid)
                return -1;
            else
                return 0;
        }
    }

    public class CompareCustomers : IComparer<Customer>
    {
        public int Compare(Customer? x, Customer? y)
        {
            if (x?.Balance > y?.Balance)
                return 1;
            else if (x?.Balance < y?.Balance)
                return -1;
            else
                return 0;
        }
    }

    public class GenericCollection<T>
    {
        public void Add(T a, T b)
        {
            if (a != null && b != null)
            {
                dynamic d1 = a;
                dynamic d2 = b;
                Console.WriteLine(d1 + d2);
            }

        }
        public void Sub(T a, T b)
        {
            if (a != null && b != null)
            {
                dynamic d1 = a;
                dynamic d2 = b;
                Console.WriteLine(d1 - d2);
            }

        }
        public void Multi(T a, T b)
        {
            if (a != null && b != null)
            {
                dynamic d1 = a;
                dynamic d2 = b;
                Console.WriteLine(d1 * d2);
            }

        }
        public void Div(T a, T b)
        {
            if (a != null && b != null)
            {
                dynamic d1 = a;
                dynamic d2 = b;
                Console.WriteLine(d1 / d2);
            }

        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Job { get; set; }
        public double Salary { get; set; }
    }

    public class OrganizationEnumerator : IEnumerator
    {
        readonly Organization OrgColl;
        int currentIndex;
        Employee currentEmployee;
        public OrganizationEnumerator(Organization org)
        {
            OrgColl = org;
            currentIndex = -1;
        }

        
        public object Current => currentEmployee;

        public bool MoveNext()
        {
            if (++currentIndex >= OrgColl.Count)
                return false;
            else
                currentEmployee = OrgColl[currentIndex];
            return true;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }

    public class Organization
    {
        readonly List<Employee> Emp = [];

        public void Add(Employee emp)
        {
            Emp.Add(emp);
        }

        public int Count
        {
            get { return Emp.Count; }
        }

        public IEnumerator GetEnumerator()
        {
            return new OrganizationEnumerator(this);
        }

        public Employee this[int index]
        {
            get { return Emp[index]; }
        }


    }

    public class Program
    {
        public static void Print(Array arr)
        {
            foreach (int value in arr)
            {
                Console.Write(value + " ");
            }
        }
        public static void Print(ArrayList arr)
        {
            foreach (int value in arr)
            {
                Console.Write(value + " ");
            }
        }

        public static void Print(Hashtable ht)
        {
            foreach (object key in ht.Keys)
            {
                Console.WriteLine(key + ": " + ht[key]);
            }
        }
        public static void Print(List<int> array)
        {
            foreach (int value in array)
            {
                Console.Write(value + " ");
            }
        }

        public static void Print(Dictionary<string, object> dict)
        {
            foreach (string key in dict.Keys)
            {
                Console.WriteLine(key + ": " + dict[key]);
            }
        }
        public static void Print(List<Customer> Customers)
        {
            foreach (Customer obj in Customers)
            {
                Console.WriteLine($"{obj.Custid} {obj.Name} {obj.City} {obj.Balance}");
            }
        }

        public static void Print(Organization employees)
        {
            foreach (Employee obj in employees)
            {
                Console.WriteLine($"{obj.Id} {obj.Name} {obj.Job} {obj.Salary}");
            }
        }

        public static bool Compare<T>(T a, T b)

        {
            if (a.Equals(b))
            {
                return true;
            }
            return false;
        }

        public static int CompareNames(Customer C1, Customer C2)
        {
            return C1.Name.CompareTo(C2.Name);
        }

        static void Main()
        {
            Program p = new();
            int[] arr = [10, 20, 30];
            Print(arr);
            arr[2] = 40;
            Array.Resize(ref arr, 5);
            Print(arr);
            Console.WriteLine("\n********Array-List**********");
            ArrayList arrayMarks = new()
            {
                121, 200
            };
            Print(arrayMarks);
            Console.WriteLine("\n- Add into array list.");
            arrayMarks.Add(250);
            Print(arrayMarks);

            Console.WriteLine("\n- Insert into array list.");
            arrayMarks.Insert(2, 231);
            Print(arrayMarks);

            arrayMarks.Add(200);
            Console.WriteLine($"\n- Remove item from array list {200} and at index {1}");
            arrayMarks.Remove(200);
            arrayMarks.RemoveAt(1);
            Print(arrayMarks);

            Console.WriteLine("***********Hash-table**********");
            Hashtable ht = new()
            {
                { "EId", 101 },
                {"Ename", "Saikumar"},
                {"Job", "Software Engineer"},
                {"Salary", 40000},
                {"MgrId", 056},
                {"Phone", 8179066548},
                {"Email", "saikumar.bhamini@innovasolutions.com"},
                {"Dname", "Opensource Technologies"},
                {"Location", "HYD"},
                {"Did", 123}
            };
            Print(ht);
            Console.WriteLine("********Generic collections*************");
            List<int> idx = new()
            {
                10, 20, 30
            };
            Print(idx);
            Console.WriteLine("\n*********Insertion******");
            idx.Insert(3, 21);
            Print(idx);
            Console.WriteLine("\n*********Sorted******");
            idx.Sort();
            Print(idx);
            Console.WriteLine("\n*********Deletion******");
            idx.RemoveAt(3);
            Print(idx);
            bool result1 = Compare<float>(12.5f, 25.4f);
            Console.WriteLine(result1);
            bool result2 = Compare<string>("Sai", "Sai");
            Console.WriteLine(result2);

            GenericCollection<int> gc = new();
            gc.Add(5, 10);
            gc.Sub(5, 10);
            gc.Multi(5, 10);
            gc.Div(15, 10);
            Console.WriteLine("**********Dictionary collection**********");

            Dictionary<string, object> dt = new()
            {
                { "EId", 101 },
                {"Ename", "Saikumar"},
                {"Job", "Software Engineer"},
                {"Salary", 40000},
                {"MgrId", 056},
                {"Phone", 8179066548},
                {"Email", "saikumar.bhamini@innovasolutions.com"},
                {"Dname", "Opensource Technologies"},
                {"Location", "HYD"},
                {"Did", 123}
            };
            Print(dt);
            Console.WriteLine("*****List with user defined type values*****");

            Customer c1 = new()
            {
                Custid = 120,
                Name = "saikumar",
                City = "HYD",
                Balance = 52000
            };
            Customer c2 = new()
            {
                Custid = 127,
                Name = "Rohit",
                City = "Chennai",
                Balance = 49000
            };

            List<Customer> Customers = [c1, c2];

            Customer c3 = new()
            {
                Custid = 110,
                Name = "pavani",
                City = "HYD",
                Balance = 55000
            };
            Customer c4 = new()
            {
                Custid = 141,
                Name = "jayadev",
                City = "Banglore",
                Balance = 62000
            };
            Customers.Add(c3);
            Customers.Add(c4);
            Print(Customers);
            Console.WriteLine("***Sort Customers List***");
            Customers.Sort();
            Print(Customers);
            Console.WriteLine("***Sort Customers List with Balance when \nyou don't have impl of Customer class***");
            CompareCustomers compCust = new();
            Customers.Sort(1, 3, compCust);
            Print(Customers);

            Comparison<Customer> Cn = new(CompareNames);
            Customers.Sort(Cn);
            Print(Customers);

            // IEnumerable Interface
            Organization Employees = new();
            Employees.Add(
               new Employee {Id=101, Name="Rajesh", Job="Manager", Salary=25000.0}
            );
            Employees.Add(new Employee {Id=121, Name="Harsha", Job="TL", Salary=24600.0});
            Employees.Add(new Employee {Id=134, Name="Sreeja", Job="Developer", Salary=23100.0});
            Employees.Add(new Employee {Id=225, Name="Prakash", Job="QA", Salary=26300.0});
            Employees.Add(new Employee {Id=363, Name="Bharath", Job="Junior Dev", Salary=20020.0});
            Console.WriteLine("*****IEnumerable interface");
            Print(Employees);
        }
    }
}
