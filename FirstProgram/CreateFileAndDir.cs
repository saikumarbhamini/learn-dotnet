
class CreateFileAndDir
{
    public static DirectoryInfo CreateDir(string dirLocation, string name)
    {

       return Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), dirLocation, name));
    }

    public static void CreateFiles(string location, string fileName, string fileContent)
    {
        File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), location, fileName), fileContent);
    }
}
