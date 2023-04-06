namespace Lab1.File;

public interface IFileReader
{
    string[] ReadAllLines(string filePath);
    bool Exists(string filePath);
}