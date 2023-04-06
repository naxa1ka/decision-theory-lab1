namespace Lab1.File;

public class FileReader : IFileReader
{
    public string[] ReadAllLines(string filePath)
    {
        return System.IO.File.ReadAllLines(filePath);
    }

    public bool Exists(string filePath)
    {
        return System.IO.File.Exists(filePath);
    }
}