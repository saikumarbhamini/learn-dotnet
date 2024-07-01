namespace FirstProgram
{
    public class Employee
    {
        int EmpNo;
        double Salary;
        string EmpName, Job, DeptName, Location;

        public Employee(int EmpNo, string EmpName, string Job, string DeptName, string Location, double Salary)
        {
            this.EmpNo = EmpNo;
            this.EmpName = EmpName;
            this.Job = Job;
            this.DeptName = DeptName;
            this.Location = Location;
            this.Salary = Salary;
        }

        public object this[int index]
        {
            get
            {
                if (index == 0)
                    return EmpNo;
                else if (index == 1)
                    return EmpName;
                else if (index == 2)
                    return Job;
                else if (index == 3)
                    return DeptName;
                else if (index == 4)
                    return Location;
                else if (index == 5)
                    return Salary;
                return null;
            }
            set{
                if(index == 0)
                EmpNo= (int)value;
                else if(index == 1)
                EmpName = (string)value;
                else if(index == 2)
                Job = (string)value;
                else if(index == 3)
                DeptName = (string)value;
                else if(index == 4)
                Location = (string)value;
                else if(index == 5)
                Salary = (double)value;
                
            }
        }
        public object this[string index]
        {
            get
            {
                if (index.ToLower() == "empno")
                    return EmpNo;
                else if (index.ToLower() == "empname")
                    return EmpName;
                else if (index.ToLower() == "job")
                    return Job;
                else if (index.ToLower() == "deptname")
                    return DeptName;
                else if (index.ToLower() == "location")
                    return Location;
                else if (index.ToLower() == "salary")
                    return Salary;
                return null;
            }
            set{
                if(index.ToLower() == "empno")
                EmpNo= (int)value;
                else if(index.ToLower() == "empname")
                EmpName = (string)value;
                else if(index.ToLower() == "job")
                Job = (string)value;
                else if(index.ToLower() == "deptname")
                DeptName = (string)value;
                else if(index.ToLower() == "location")
                Location = (string)value;
                else if(index.ToLower() == "salary")
                Salary = (double)value;
                
            }
        }
    }


    public class TestEmployee
    {
        static void Main()
        {
            Employee emp = new(100, "Saikumar", "Jr Developer", "OS technologies", "GAR", 40000.00);
            Console.WriteLine($"EmpNo: {emp[0]}");
            Console.WriteLine($"EmpName: {emp[1]}");
            Console.WriteLine($"Job: {emp[2]}");
            Console.WriteLine($"DeptName: {emp[3]}");
            Console.WriteLine($"Location: {emp[4]}");
            Console.WriteLine($"Salary: {emp[5]}");

            emp[2] = "Associate Developer";
            emp[5] = 50000.0;
            Console.WriteLine($"\nJob: {emp[2]}");
            Console.WriteLine($"Salary: {emp[5]}");

            emp["deptname"] = "Delivery";
            emp["location"] = "Raheja";
            Console.WriteLine($"\nDeptName: {emp[3]}");
            Console.WriteLine($"Location: {emp[4]}");
        }
    }
}
