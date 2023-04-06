namespace Lab1.File;

//utils class is bad
public static class FileExtensions
{
    public static T[,] ReadMatrix<T>(string filePath, Func<string, T> converter)
    {
        var fileReader = new FileReader();
        return ReadMatrix(filePath, fileReader, converter);
    }

    //can use Stream instead of file reader
    public static T[,] ReadMatrix<T>(
        string filePath,
        IFileReader fileReader,
        Func<string, T> converter,
        char elementSeparator = ' ')
    {
        if (string.IsNullOrEmpty(filePath))
            throw new ArgumentException("File path is null or empty.", nameof(filePath));

        if (!fileReader.Exists(filePath))
            throw new FileNotFoundException("File not found.", filePath);

        var lines = fileReader.ReadAllLines(filePath);

        var rowCount = lines.Length;
        var strings = lines[0].Trim().Split(elementSeparator);
        var colCount = strings.Length;

        if (rowCount != colCount)
            throw new ArgumentException("Matrix is not square.");

        var matrix = new T[rowCount, colCount];

        for (var i = 0; i < rowCount; i++)
        {
            var rowElements = lines[i].Split(elementSeparator);
            for (var j = 0; j < colCount; j++) 
                matrix[i, j] = converter(rowElements[j]);
        }

        return matrix;
    }
}