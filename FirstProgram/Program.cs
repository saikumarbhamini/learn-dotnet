using Newtonsoft.Json;
using static CreateFileAndDir;

class Program
{
    // Working with files and directories.
    static List<string> FindFiles(string folderName)
    {
        List<string> salesFiles = [];

        var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

        foreach (var file in foundFiles)
        {
            var extension = Path.GetExtension(file);

            if (extension == ".json")
            {
                salesFiles.Add(file);
            }
        }
        return salesFiles;
    }

    static void InitialWorkOnDirAndFiles(string storesDir)
    {
        // get everythin you need to know about a file or path
        string fileName = $"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales{Path.DirectorySeparatorChar}sales.json";

        FileInfo info = new(fileName);
        Console.WriteLine($"Full Name: {info.FullName}{Environment.NewLine}Directory: {info.Directory}{Environment.NewLine}Extension: {info.Extension}{Environment.NewLine}Create Date: {info.CreationTime}");

        var salesFiles = FindFiles(storesDir);
        
        Console.WriteLine($"Total no of files: {salesFiles.Count}");

        var resultDirPath = CreateDir(Path.Combine("stores", "201"), "Created");
        Console.WriteLine($"Created At: {resultDirPath}");
        CreateFiles(resultDirPath.ToString(), "created_on.txt", $"This file created on {DateTime.Now.ToString()}");
    }

    static void CalculateSalesTotal(){
        var salesJson = File.ReadAllText($"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales.json");
        var salesData = JsonConvert.DeserializeObject<SalesTotal>(salesJson);
        Console.WriteLine(salesData?.Total);
    }

    class SalesTotal
    {
        public double Total { get; set;}
    }

    static void Main()
    {
        // var salesFiles = FindFiles("stores");
        // foreach (var file in salesFiles)
        // {
        //     Console.WriteLine(file);
        // }
        Console.WriteLine(Directory.GetCurrentDirectory());
        string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        Console.WriteLine(docPath);
        Console.WriteLine($"stores{Path.DirectorySeparatorChar}201");
        Console.WriteLine(Path.Combine("stores", "202"));

        var currentDir = Directory.GetCurrentDirectory();

        var storesDir = Path.Combine(currentDir, "stores");
        InitialWorkOnDirAndFiles(storesDir);
        var salesTotalDirPath = Path.Combine(currentDir, "stores");
        var resultPath = CreateDir(salesTotalDirPath, "salesTotalDir");
        var salesFiles = FindFiles(storesDir);

        File.WriteAllText(Path.Combine(resultPath.ToString(), "totals.txt"), string.Empty);
        CalculateSalesTotal();
    }
}
