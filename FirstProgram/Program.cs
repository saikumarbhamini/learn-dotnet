public enum Days
{
    Monday = 1, Tuesday, Wednesday, Thursday, Friday
}
class Program
{
    public static Days MeetingDay
    {
        get; set;
    } = Days.Wednesday;
    static void Main()
    {
        foreach (int i in Enum.GetValues(typeof(Days)))
        {
            Console.WriteLine(i + ": " + (Days)i);
        }
        foreach (string s in Enum.GetNames(typeof(Days)))
        {
            Console.WriteLine(s);
        }
        Console.WriteLine(MeetingDay);
    }
}
